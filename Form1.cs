using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace thermal_conductivity
{
    public partial class Form1 : Form
    {
        double x1 = 2, x2 = 2, x3 = 2, y1 = 3, y2 = 3, dx, dy, dt, a, p, q, tmax;
        double[,] U;
        int iMax, jMax, kMax, k = 0, ix1, ix2, jy1, cond, ps = 3;
        Stopwatch time;
        Socket _serverSocket;
        const string _serverHost = "localhost";
        const int _serverPort = 9933;
        byte[] fromServer;
        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
            Glut.glutInit();
            connect();
        }
        private void connect()
        {
            try
            {
                IPHostEntry ipHost = Dns.GetHostEntry(_serverHost);
                IPAddress ipAddress = ipHost.AddressList[0];
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, _serverPort);
                _serverSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                _serverSocket.Connect(ipEndPoint);
            }
            catch { _serverSocket.Close(); MessageBox.Show("Сервер недоступен!"); }
        }
        private void button_figure_Click(object sender, EventArgs e)
        {
            Draw_Zone();
        }
        private void button_watch_Click(object sender, EventArgs e)
        {
            Start_cond();
        }
        private void Draw_Zone()
        {
            timer.Stop();
            x1 = double.Parse(tB_X1.Text);
            x2 = x1 + double.Parse(tB_X2.Text);
            x3 = x2 + double.Parse(tB_X3.Text);
            y1 = double.Parse(tB_Y1.Text);
            y2 = y1 + double.Parse(tB_Y2.Text);
            ps = int.Parse(tB_PS.Text);
            iMax = AnT.Width / ps + (AnT.Width % ps != 0 ? 1 : 0);
            jMax = AnT.Height / ps + (AnT.Height % ps != 0 ? 1 : 0);
            dx = x3 / iMax;
            dy = y2 / jMax;
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);
            Gl.glClearColor(0, 0, 0, 1);
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();            
            Glu.gluOrtho2D(-dx/2, x3, -dy/2, y2);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();
            Gl.glPushMatrix();
            Parallel.For(0, iMax, i =>
            {
                for (int j = 0; j <= jMax; ++j)
                {
                    if (Math.Abs(j * dy - y1) < dy)
                        jy1 = j;
                    if (Math.Abs(i * dx - x1) < dx)
                        ix1 = i;
                    if (Math.Abs(i * dx - x2) < dx)
                        ix2 = i;
                }
            });           
            Gl.glPointSize(ps);
            Gl.glBegin(Gl.GL_POINTS);
            for (int i = 0; i <= iMax; ++i)
                for (int j = 0; j <= jMax; ++j)
                    if (i >= ix1 && i <= ix2 || j <= jy1)
                    {
                        Gl.glColor3d(1, 1, 1);
                        Gl.glVertex2d(i * dx, j * dy);
                    }
            Gl.glEnd();
            Gl.glPopMatrix();
            Gl.glFlush();
            AnT.Invalidate();
        }
        private void Start_cond()
        {
            Draw_Zone();
            k = 0;
            fromServer = new byte[(iMax + 1) * (jMax + 1) * sizeof(double) / sizeof(byte)];
            U = new double[iMax + 1, jMax + 1];
            cond = cB_condition.SelectedIndex;
            time = new Stopwatch();
            if(send("#null" + cond.ToString() + "|" + iMax.ToString() + "|" + jMax.ToString() + "|" + ix1.ToString() + "|" + ix2.ToString() + "|" + jy1.ToString() + "|"
                + dx.ToString() + "|" + dy.ToString() + "|") != 0)
            {
                receive();
                Draw_temperature();
            }            
        }
        private void button_apply_Click(object sender, EventArgs e)
        {
            Start_cond();
            a = double.Parse(tB_A.Text);
            tmax = double.Parse(tB_time.Text);
            dt = dy * dy * dx * dx / (2 * a * (dx * dx + dy * dy));
            kMax = (int)(tmax / dt);
            p = a * dt / (dx * dx * dy * dy);
            q = 1 - 2 * (dx * dx + dy * dy) * p;            
            label_TimeWork.Text = k.ToString();
            ++k;
            if (send("#init" + dt.ToString() + "|" + p.ToString() + "|" + q.ToString()) != 0)
            {
                time.Start();
                timer.Start();
            }                   
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (k == kMax) {
                timer.Stop();
                time.Stop();                           
                MessageBox.Show("Расчёт окончен!!!"); 
            }
            else
            {
                label_Current_layer.Text = k.ToString();
                if(send("#calc" + k.ToString()) != 0)
                    receive();                
                Draw_temperature();
                ++k;                
                TimeSpan ts = time.Elapsed;
                string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                label_TimeWork.Text = elapsedTime;
            }        
        }
        private void Draw_temperature()
        {
            Gl.glPointSize(ps);
            Gl.glBegin(Gl.GL_POINTS);
            for (int i = 0; i <= ix1; ++i)
                for (int j = 0; j <= jy1; ++j)
                {
                    Gl.glColor3d(U[i, j], 0, 1 - U[i, j]);
                    Gl.glVertex2d(i * dx, j * dy);
                }
            for (int i = ix1; i <= ix2; ++i)
                for (int j = 0; j <= jMax; ++j)
                {
                    Gl.glColor3d(U[i, j], 0, 1 - U[i, j]);
                    Gl.glVertex2d(i * dx, j * dy);
                }
            for (int i = ix2; i <= iMax; ++i)
                for (int j = 0; j <= jy1; ++j)
                {
                    Gl.glColor3d(U[i, j], 0, 1 - U[i, j]);
                    Gl.glVertex2d(i * dx, j * dy);
                }
            Gl.glEnd();
            Gl.glPopMatrix();
            Gl.glFlush();
            AnT.Invalidate();
        }   
        private int receive()
        {
            try
            {                
                int result = _serverSocket.Receive(fromServer);
                Parallel.For(0, iMax, i =>
                {
                    for (int j = 0; j <= jMax; ++j)
                        U[i, j] = BitConverter.ToDouble(fromServer,
                            (i * (jMax + 1) + j) * sizeof(double) / sizeof(byte));
                });
                return result;
            }
            catch { timer.Stop(); time.Stop(); MessageBox.Show("Связь с сервером прервалась..."); _serverSocket.Close(); }
            return 0;
        }
        private int send(string data)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                return _serverSocket.Send(buffer);
            }
            catch { timer.Stop(); time.Stop(); MessageBox.Show("Связь с сервером прервалась..."); _serverSocket.Close();  }
            return 0;
        }
    }
}

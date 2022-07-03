using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;

namespace ServerForum
{
    class Client
    {
        private Socket _handler;
        private Thread _userThread;
        double dx, dy, dt, p, q;
        double[,] U, U1;
        int iMax, jMax, ix1, ix2, jy1, cond, k;
        byte[] toClient;
        public Client(Socket socket)
        {
            _handler = socket;
            _userThread = new Thread(listner);
            _userThread.IsBackground = true;
            _userThread.Start();
        }
        public Socket UserHandler
        {
            get { return _handler; }
        }
        private double mu1(double y, double t) { return 10; }
        private double mu2(double y, double t) { return 0; }
        private double mu3(double y, double t) { return 0; }
        private double mu4(double y, double t) { return 0; }
        private double mu5(double x, double t) { return 0; }
        private double mu6(double x, double t) { return 0; }
        private double mu7(double x, double t) { return 0; }
        private double mu8(double x, double t) { return 0; }
        private double nu2(double y, double t) { return 0; }
        private double nu3(double y, double t) { return 0; }
        private double nu4(double y, double t) { return 0; }
        private double nu5(double x, double t) { return 0; }
        private double nu6(double x, double t) { return 0; }
        private double nu7(double x, double t) { return 0; }
        private double nu8(double x, double t) { return 0; }
        private double phi(double x, double y) { return 0; }
        private void listner()
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024];
                    int bytesRec = _handler.Receive(buffer);
                    string data = Encoding.UTF8.GetString(buffer, 0, bytesRec);
                    handleCommand(data);
                }
                catch { Server.EndClient(this); return; }
            }
        }
        public void End()
        {
            try
            {
                _handler.Close();
                try
                {
                    _userThread.Abort();
                }
                catch { }
            }
            catch (Exception exp) { Console.WriteLine("Error with end: {0}.", exp.Message); }
        }
        private void handleCommand(string data)
        {
            if (data.Contains("#null"))
            {
                data = data.Remove(0, 5);
                int cp = 0;
                string str = null;
                for (int i = 0; i < data.Length; ++i)
                    if (data[i] == '|')
                    {
                        switch (cp)
                        {
                            case 0: cond = int.Parse(str); break;
                            case 1: iMax = int.Parse(str); break;
                            case 2: jMax = int.Parse(str); break;
                            case 3: ix1 = int.Parse(str); break;
                            case 4: ix2 = int.Parse(str); break;
                            case 5: jy1 = int.Parse(str); break;
                            case 6: dx = double.Parse(str); break;
                            case 7: dy = double.Parse(str); break;
                        }
                        ++cp;
                        str = null;
                    }
                    else str += data[i];
                U = new double[iMax + 1, jMax + 1];
                Parallel.For(0, iMax + 1, i =>
                {
                    for (int j = 0; j <= jMax; ++j)
                        if (i <= ix1 && j <= jy1 || i >= ix1 && i <= ix2 || i >= ix2 && j <= jy1)
                            U[i, j] = phi(i * dx, j * dy);
                });
                condition(U);
                toClient = new byte[(iMax + 1) * (jMax + 1) * sizeof(double) / sizeof(byte)];
                Send();
                return;
            }
            if (data.Contains("#init"))
            {
                data = data.Remove(0, 5);
                int cp = 0;
                string str = null;
                for (int i = 0; i < data.Length; ++i)
                    if (data[i] == '|')
                    {
                        switch (cp)
                        {
                            case 0: dt = double.Parse(str); break;
                            case 1: p = double.Parse(str); break;
                            case 2: q = double.Parse(str); break;
                        }
                        ++cp;
                        str = null;
                    }
                    else str += data[i];
                U1 = new double[iMax + 1, jMax + 1];
                return;
            }
            if (data.Contains("#calc"))
            {
                data = data.Remove(0, 5);
                k = int.Parse(data);
                Parallel.For(1, ix1 + 1, i =>
                {
                    for (int j = 1; j <= jy1; ++j)
                        U1[i, j] = U[i, j] * q + p * ((dy * dy) * (U[i + 1, j] + U[i - 1, j]) + (dx * dx) * (U[i, j - 1] + U[i, j + 1]));
                });
                Parallel.For(ix1 + 1, ix2 + 1, i =>
                {
                    for (int j = 1; j <= jMax - 1; ++j)
                        U1[i, j] = U[i, j] * q + p * ((dy * dy) * (U[i + 1, j] + U[i - 1, j]) + (dx * dx) * (U[i, j - 1] + U[i, j + 1]));
                });
                Parallel.For(ix2 + 1, iMax, i =>
                {
                    for (int j = 1; j <= jy1; ++j)
                        U1[i, j] = U[i, j] * q + p * ((dy * dy) * (U[i + 1, j] + U[i - 1, j]) + (dx * dx) * (U[i, j - 1] + U[i, j + 1]));
                });
                condition(U1);
                U = U1;
                Send();
                return;
            }
        }
        private void Send()
        {
            Parallel.For(0, iMax + 1, i =>
            {
                for (int j = 0; j <= jMax; ++j)
                {
                    byte[] Uij = BitConverter.GetBytes(U[i, j]);
                    for (int b = 0; b < sizeof(double) / sizeof(byte); ++b)
                        toClient[(i * (jMax + 1) + j) * sizeof(double) / sizeof(byte) + b] = Uij[b];
                }
            });
            _handler.Send(toClient);
        }
        private void condition(double[,] U)
        {
            Parallel.For(0, iMax + 1, i => {
                switch (cond)
                {
                    case 0: U[i, 0] = mu5(i * dx, k * dt); break;
                    case 1: U[i, 0] = (4 * U[i, 1] - 2 * dy * nu5(i * dx, k * dt) - U[i, 2]) / 3; break;
                }
                if (i >= ix1 && i <= ix2)
                    switch (cond)
                    {
                        case 0: U[i, jMax] = mu8(i * dx, k * dt); break;
                        case 1: U[i, jMax] = (2 * dy * nu8(i * dx, k * dt) + 4 * U[i, jMax - 1] - U[i, jMax - 2]) / 3; break;
                    }
                if (i < ix1)
                    switch (cond)
                    {
                        case 0: U[i, jy1] = mu6(i * dx, k * dt); break;
                        case 1: U[i, jy1] = (2 * dy * nu6(i * dx, k * dt) + 4 * U[i, jy1 - 1] - U[i, jy1 - 2]) / 3; break;
                    }
                if (i > ix2)
                    switch (cond)
                    {
                        case 0: U[i, jy1] = mu7(i * dx, k * dt); break;
                        case 1: U[i, jy1] = (2 * dy * nu7(i * dx, k * dt) + 4 * U[i, jy1 - 1] - U[i, jy1 - 2]) / 3; break;
                    }
            });
            Parallel.For(0, jMax + 1, j =>
            {
                if (j < jy1)
                {
                    U[0, j] = mu1(j * dy, k * dt);
                    switch (cond)
                    {
                        case 0: U[iMax, j] = mu4(j * dy, k * dt); break;
                        case 1: U[iMax, j] = (2 * dx * nu4(j * dy, k * dt) + 4 * U[iMax - 1, j] - U[iMax - 2, j]) / 3; break;
                    }
                }
                else
                    switch (cond)
                    {
                        case 0:
                            U[ix1, j] = mu2(j * dy, k * dt);
                            U[ix2, j] = mu3(j * dy, k * dt); break;
                        case 1:
                            U[ix1, j] = (-2 * dx * nu2(j * dy, k * dt) + 4 * U[ix1 + 1, j] - U[ix1 + 2, j]) / 3;
                            U[ix2, j] = (2 * dx * nu3(j * dy, k * dt) + 4 * U[ix2 - 1, j] - U[ix2 - 2, j]) / 3; break;
                    }
            });
            U[0, jy1] = mu1(jy1 * dy, k * dt);
        }
    }

}




namespace thermal_conductivity
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gB_Input = new System.Windows.Forms.GroupBox();
            this.tB_PS = new System.Windows.Forms.TextBox();
            this.label_PS = new System.Windows.Forms.Label();
            this.cB_condition = new System.Windows.Forms.ComboBox();
            this.button_figure = new System.Windows.Forms.Button();
            this.tB_time = new System.Windows.Forms.TextBox();
            this.button_apply = new System.Windows.Forms.Button();
            this.label_t1 = new System.Windows.Forms.Label();
            this.button_watch = new System.Windows.Forms.Button();
            this.tB_A = new System.Windows.Forms.TextBox();
            this.label_A = new System.Windows.Forms.Label();
            this.tB_Y2 = new System.Windows.Forms.TextBox();
            this.tB_Y1 = new System.Windows.Forms.TextBox();
            this.label_Y2 = new System.Windows.Forms.Label();
            this.label_Y1 = new System.Windows.Forms.Label();
            this.tB_X3 = new System.Windows.Forms.TextBox();
            this.tB_X2 = new System.Windows.Forms.TextBox();
            this.tB_X1 = new System.Windows.Forms.TextBox();
            this.label_X3 = new System.Windows.Forms.Label();
            this.label_X2 = new System.Windows.Forms.Label();
            this.label_x1 = new System.Windows.Forms.Label();
            this.AnT = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label_TimeWork = new System.Windows.Forms.Label();
            this.gB_Output = new System.Windows.Forms.GroupBox();
            this.label_Layer = new System.Windows.Forms.Label();
            this.label_Current_layer = new System.Windows.Forms.Label();
            this.label_Time = new System.Windows.Forms.Label();
            this.gB_Input.SuspendLayout();
            this.gB_Output.SuspendLayout();
            this.SuspendLayout();
            // 
            // gB_Input
            // 
            this.gB_Input.Controls.Add(this.tB_PS);
            this.gB_Input.Controls.Add(this.label_PS);
            this.gB_Input.Controls.Add(this.cB_condition);
            this.gB_Input.Controls.Add(this.button_figure);
            this.gB_Input.Controls.Add(this.tB_time);
            this.gB_Input.Controls.Add(this.button_apply);
            this.gB_Input.Controls.Add(this.label_t1);
            this.gB_Input.Controls.Add(this.button_watch);
            this.gB_Input.Controls.Add(this.tB_A);
            this.gB_Input.Controls.Add(this.label_A);
            this.gB_Input.Controls.Add(this.tB_Y2);
            this.gB_Input.Controls.Add(this.tB_Y1);
            this.gB_Input.Controls.Add(this.label_Y2);
            this.gB_Input.Controls.Add(this.label_Y1);
            this.gB_Input.Controls.Add(this.tB_X3);
            this.gB_Input.Controls.Add(this.tB_X2);
            this.gB_Input.Controls.Add(this.tB_X1);
            this.gB_Input.Controls.Add(this.label_X3);
            this.gB_Input.Controls.Add(this.label_X2);
            this.gB_Input.Controls.Add(this.label_x1);
            this.gB_Input.Location = new System.Drawing.Point(406, 1);
            this.gB_Input.Name = "gB_Input";
            this.gB_Input.Size = new System.Drawing.Size(174, 268);
            this.gB_Input.TabIndex = 5;
            this.gB_Input.TabStop = false;
            this.gB_Input.Text = "Входные параметры:";
            // 
            // tB_PS
            // 
            this.tB_PS.Location = new System.Drawing.Point(114, 71);
            this.tB_PS.Name = "tB_PS";
            this.tB_PS.Size = new System.Drawing.Size(54, 20);
            this.tB_PS.TabIndex = 23;
            this.tB_PS.Text = "3";
            // 
            // label_PS
            // 
            this.label_PS.AutoSize = true;
            this.label_PS.Location = new System.Drawing.Point(90, 74);
            this.label_PS.Name = "label_PS";
            this.label_PS.Size = new System.Drawing.Size(21, 13);
            this.label_PS.TabIndex = 22;
            this.label_PS.Text = "ps:";
            // 
            // cB_condition
            // 
            this.cB_condition.FormattingEnabled = true;
            this.cB_condition.Items.AddRange(new object[] {
            "U",
            "dU/dn"});
            this.cB_condition.Location = new System.Drawing.Point(9, 126);
            this.cB_condition.Name = "cB_condition";
            this.cB_condition.Size = new System.Drawing.Size(159, 21);
            this.cB_condition.TabIndex = 21;
            this.cB_condition.Text = "U";
            // 
            // button_figure
            // 
            this.button_figure.Location = new System.Drawing.Point(9, 97);
            this.button_figure.Name = "button_figure";
            this.button_figure.Size = new System.Drawing.Size(159, 23);
            this.button_figure.TabIndex = 20;
            this.button_figure.Text = "Фигура";
            this.button_figure.UseVisualStyleBackColor = true;
            this.button_figure.Click += new System.EventHandler(this.button_figure_Click);
            // 
            // tB_time
            // 
            this.tB_time.Location = new System.Drawing.Point(30, 208);
            this.tB_time.Name = "tB_time";
            this.tB_time.Size = new System.Drawing.Size(138, 20);
            this.tB_time.TabIndex = 18;
            this.tB_time.Text = "1";
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(9, 234);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(159, 23);
            this.button_apply.TabIndex = 1;
            this.button_apply.Text = "Применить";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // label_t1
            // 
            this.label_t1.AutoSize = true;
            this.label_t1.Location = new System.Drawing.Point(6, 211);
            this.label_t1.Name = "label_t1";
            this.label_t1.Size = new System.Drawing.Size(19, 13);
            this.label_t1.TabIndex = 17;
            this.label_t1.Text = "t1:";
            // 
            // button_watch
            // 
            this.button_watch.Location = new System.Drawing.Point(9, 153);
            this.button_watch.Name = "button_watch";
            this.button_watch.Size = new System.Drawing.Size(159, 23);
            this.button_watch.TabIndex = 2;
            this.button_watch.Text = "Посмотреть";
            this.button_watch.UseVisualStyleBackColor = true;
            this.button_watch.Click += new System.EventHandler(this.button_watch_Click);
            // 
            // tB_A
            // 
            this.tB_A.Location = new System.Drawing.Point(30, 182);
            this.tB_A.Name = "tB_A";
            this.tB_A.Size = new System.Drawing.Size(138, 20);
            this.tB_A.TabIndex = 16;
            this.tB_A.Text = "1";
            // 
            // label_A
            // 
            this.label_A.AutoSize = true;
            this.label_A.Location = new System.Drawing.Point(6, 185);
            this.label_A.Name = "label_A";
            this.label_A.Size = new System.Drawing.Size(16, 13);
            this.label_A.TabIndex = 15;
            this.label_A.Text = "a:";
            // 
            // tB_Y2
            // 
            this.tB_Y2.Location = new System.Drawing.Point(114, 45);
            this.tB_Y2.Name = "tB_Y2";
            this.tB_Y2.Size = new System.Drawing.Size(54, 20);
            this.tB_Y2.TabIndex = 12;
            this.tB_Y2.Text = "3";
            // 
            // tB_Y1
            // 
            this.tB_Y1.Location = new System.Drawing.Point(114, 19);
            this.tB_Y1.Name = "tB_Y1";
            this.tB_Y1.Size = new System.Drawing.Size(54, 20);
            this.tB_Y1.TabIndex = 11;
            this.tB_Y1.Text = "3";
            // 
            // label_Y2
            // 
            this.label_Y2.AutoSize = true;
            this.label_Y2.Location = new System.Drawing.Point(90, 48);
            this.label_Y2.Name = "label_Y2";
            this.label_Y2.Size = new System.Drawing.Size(21, 13);
            this.label_Y2.TabIndex = 10;
            this.label_Y2.Text = "y2:";
            // 
            // label_Y1
            // 
            this.label_Y1.AutoSize = true;
            this.label_Y1.Location = new System.Drawing.Point(90, 22);
            this.label_Y1.Name = "label_Y1";
            this.label_Y1.Size = new System.Drawing.Size(21, 13);
            this.label_Y1.TabIndex = 9;
            this.label_Y1.Text = "y1:";
            // 
            // tB_X3
            // 
            this.tB_X3.Location = new System.Drawing.Point(30, 71);
            this.tB_X3.Name = "tB_X3";
            this.tB_X3.Size = new System.Drawing.Size(54, 20);
            this.tB_X3.TabIndex = 8;
            this.tB_X3.Text = "2";
            // 
            // tB_X2
            // 
            this.tB_X2.Location = new System.Drawing.Point(30, 45);
            this.tB_X2.Name = "tB_X2";
            this.tB_X2.Size = new System.Drawing.Size(54, 20);
            this.tB_X2.TabIndex = 7;
            this.tB_X2.Text = "2";
            // 
            // tB_X1
            // 
            this.tB_X1.Location = new System.Drawing.Point(30, 19);
            this.tB_X1.Name = "tB_X1";
            this.tB_X1.Size = new System.Drawing.Size(54, 20);
            this.tB_X1.TabIndex = 6;
            this.tB_X1.Text = "2";
            // 
            // label_X3
            // 
            this.label_X3.AutoSize = true;
            this.label_X3.Location = new System.Drawing.Point(6, 74);
            this.label_X3.Name = "label_X3";
            this.label_X3.Size = new System.Drawing.Size(21, 13);
            this.label_X3.TabIndex = 5;
            this.label_X3.Text = "x3:";
            // 
            // label_X2
            // 
            this.label_X2.AutoSize = true;
            this.label_X2.Location = new System.Drawing.Point(6, 48);
            this.label_X2.Name = "label_X2";
            this.label_X2.Size = new System.Drawing.Size(21, 13);
            this.label_X2.TabIndex = 4;
            this.label_X2.Text = "x2:";
            // 
            // label_x1
            // 
            this.label_x1.AutoSize = true;
            this.label_x1.Location = new System.Drawing.Point(6, 22);
            this.label_x1.Name = "label_x1";
            this.label_x1.Size = new System.Drawing.Size(21, 13);
            this.label_x1.TabIndex = 3;
            this.label_x1.Text = "x1:";
            // 
            // AnT
            // 
            this.AnT.AccumBits = ((byte)(0));
            this.AnT.AutoCheckErrors = false;
            this.AnT.AutoFinish = false;
            this.AnT.AutoMakeCurrent = true;
            this.AnT.AutoSwapBuffers = true;
            this.AnT.BackColor = System.Drawing.Color.Black;
            this.AnT.ColorBits = ((byte)(32));
            this.AnT.DepthBits = ((byte)(16));
            this.AnT.Location = new System.Drawing.Point(0, 1);
            this.AnT.Name = "AnT";
            this.AnT.Size = new System.Drawing.Size(400, 400);
            this.AnT.StencilBits = ((byte)(0));
            this.AnT.TabIndex = 4;
            // 
            // timer
            // 
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label_TimeWork
            // 
            this.label_TimeWork.AutoSize = true;
            this.label_TimeWork.Location = new System.Drawing.Point(55, 16);
            this.label_TimeWork.Name = "label_TimeWork";
            this.label_TimeWork.Size = new System.Drawing.Size(13, 13);
            this.label_TimeWork.TabIndex = 6;
            this.label_TimeWork.Text = "0";
            // 
            // gB_Output
            // 
            this.gB_Output.Controls.Add(this.label_Layer);
            this.gB_Output.Controls.Add(this.label_Current_layer);
            this.gB_Output.Controls.Add(this.label_Time);
            this.gB_Output.Controls.Add(this.label_TimeWork);
            this.gB_Output.Location = new System.Drawing.Point(406, 275);
            this.gB_Output.Name = "gB_Output";
            this.gB_Output.Size = new System.Drawing.Size(174, 63);
            this.gB_Output.TabIndex = 8;
            this.gB_Output.TabStop = false;
            this.gB_Output.Text = "Выходные параметры:";
            // 
            // label_Layer
            // 
            this.label_Layer.AutoSize = true;
            this.label_Layer.Location = new System.Drawing.Point(6, 38);
            this.label_Layer.Name = "label_Layer";
            this.label_Layer.Size = new System.Drawing.Size(35, 13);
            this.label_Layer.TabIndex = 9;
            this.label_Layer.Text = "Слой:";
            // 
            // label_Current_layer
            // 
            this.label_Current_layer.AutoSize = true;
            this.label_Current_layer.Location = new System.Drawing.Point(55, 38);
            this.label_Current_layer.Name = "label_Current_layer";
            this.label_Current_layer.Size = new System.Drawing.Size(13, 13);
            this.label_Current_layer.TabIndex = 8;
            this.label_Current_layer.Text = "0";
            // 
            // label_Time
            // 
            this.label_Time.AutoSize = true;
            this.label_Time.Location = new System.Drawing.Point(6, 16);
            this.label_Time.Name = "label_Time";
            this.label_Time.Size = new System.Drawing.Size(43, 13);
            this.label_Time.TabIndex = 7;
            this.label_Time.Text = "Время:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 401);
            this.Controls.Add(this.gB_Output);
            this.Controls.Add(this.gB_Input);
            this.Controls.Add(this.AnT);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gB_Input.ResumeLayout(false);
            this.gB_Input.PerformLayout();
            this.gB_Output.ResumeLayout(false);
            this.gB_Output.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gB_Input;
        private System.Windows.Forms.TextBox tB_time;
        private System.Windows.Forms.Label label_t1;
        private System.Windows.Forms.TextBox tB_A;
        private System.Windows.Forms.Label label_A;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.TextBox tB_Y2;
        private System.Windows.Forms.TextBox tB_Y1;
        private System.Windows.Forms.Label label_Y2;
        private System.Windows.Forms.Label label_Y1;
        private System.Windows.Forms.TextBox tB_X3;
        private System.Windows.Forms.TextBox tB_X2;
        private System.Windows.Forms.TextBox tB_X1;
        private System.Windows.Forms.Label label_X3;
        private System.Windows.Forms.Label label_X2;
        private System.Windows.Forms.Label label_x1;
        private System.Windows.Forms.Button button_watch;
        private Tao.Platform.Windows.SimpleOpenGlControl AnT;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button button_figure;
        private System.Windows.Forms.ComboBox cB_condition;
        private System.Windows.Forms.Label label_TimeWork;
        private System.Windows.Forms.TextBox tB_PS;
        private System.Windows.Forms.Label label_PS;
        private System.Windows.Forms.GroupBox gB_Output;
        private System.Windows.Forms.Label label_Time;
        private System.Windows.Forms.Label label_Layer;
        private System.Windows.Forms.Label label_Current_layer;
    }
}


namespace Exercise2_Lab03
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_tcp_listener = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // btn_tcp_listener
            // 
            btn_tcp_listener.BackColor = Color.LightSteelBlue;
            btn_tcp_listener.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btn_tcp_listener.Location = new Point(100, 120);
            btn_tcp_listener.Name = "btn_tcp_listener";
            btn_tcp_listener.Size = new Size(250, 70);
            btn_tcp_listener.TabIndex = 0;
            btn_tcp_listener.Text = "TCP Telnet Listener";
            btn_tcp_listener.UseVisualStyleBackColor = false;
            btn_tcp_listener.Click += btn_tcp_listener_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(90, 30);
            label1.Name = "label1";
            label1.Size = new Size(270, 41);
            label1.TabIndex = 1;
            label1.Text = "Lab 03 - Bài 02";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(50, 220);
            label2.Name = "label2";
            label2.Size = new Size(350, 23);
            label2.TabIndex = 2;
            label2.Text = "Lắng nghe dữ liệu từ Telnet qua TCP Socket";
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(450, 300);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_tcp_listener);
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard - Bài 02";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_tcp_listener;
        private Label label1;
        private Label label2;
    }
}

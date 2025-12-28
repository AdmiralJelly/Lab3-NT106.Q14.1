namespace Exercise3_Lab03
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
            label1 = new Label();
            label2 = new Label();
            btn_open_server = new Button();
            btn_open_client = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(120, 30);
            label1.Name = "label1";
            label1.Size = new Size(360, 41);
            label1.TabIndex = 0;
            label1.Text = "Lab 03 - Bài 03 (TCP)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(80, 80);
            label2.Name = "label2";
            label2.Size = new Size(440, 25);
            label2.TabIndex = 1;
            label2.Text = "Giao tiếp giữa TCP Server và TCP Client (1 vs 1)";
            // 
            // btn_open_server
            // 
            btn_open_server.BackColor = Color.LightSteelBlue;
            btn_open_server.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btn_open_server.Location = new Point(80, 140);
            btn_open_server.Name = "btn_open_server";
            btn_open_server.Size = new Size(200, 80);
            btn_open_server.TabIndex = 2;
            btn_open_server.Text = "Open TCP Server";
            btn_open_server.UseVisualStyleBackColor = false;
            btn_open_server.Click += btn_open_server_Click;
            // 
            // btn_open_client
            // 
            btn_open_client.BackColor = Color.LightGreen;
            btn_open_client.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btn_open_client.Location = new Point(320, 140);
            btn_open_client.Name = "btn_open_client";
            btn_open_client.Size = new Size(200, 80);
            btn_open_client.TabIndex = 3;
            btn_open_client.Text = "Open TCP Client";
            btn_open_client.UseVisualStyleBackColor = false;
            btn_open_client.Click += btn_open_client_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(50, 250);
            label3.Name = "label3";
            label3.Size = new Size(500, 60);
            label3.TabIndex = 4;
            label3.Text = "Hướng dẫn:\r\n1. Mở Server trước, nhấn Listen\r\n2. Mở Client, nhập IP và Port của Server, nhấn Connect\r\n3. Gửi tin nhắn từ Client đến Server";
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(600, 350);
            Controls.Add(label3);
            Controls.Add(btn_open_client);
            Controls.Add(btn_open_server);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard - Bài 03";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btn_open_server;
        private Button btn_open_client;
        private Label label3;
    }
}

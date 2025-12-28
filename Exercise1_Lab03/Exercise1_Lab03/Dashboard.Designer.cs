namespace Exercise1_Lab03
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
            btn_udp_server = new Button();
            btn_udp_client = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btn_udp_server
            // 
            btn_udp_server.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btn_udp_server.Location = new Point(100, 120);
            btn_udp_server.Name = "btn_udp_server";
            btn_udp_server.Size = new Size(200, 60);
            btn_udp_server.TabIndex = 0;
            btn_udp_server.Text = "UDP Server";
            btn_udp_server.UseVisualStyleBackColor = true;
            btn_udp_server.Click += btn_udp_server_Click;
            // 
            // btn_udp_client
            // 
            btn_udp_client.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btn_udp_client.Location = new Point(100, 200);
            btn_udp_client.Name = "btn_udp_client";
            btn_udp_client.Size = new Size(200, 60);
            btn_udp_client.TabIndex = 1;
            btn_udp_client.Text = "UDP Client";
            btn_udp_client.UseVisualStyleBackColor = true;
            btn_udp_client.Click += btn_udp_client_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(80, 40);
            label1.Name = "label1";
            label1.Size = new Size(240, 37);
            label1.TabIndex = 2;
            label1.Text = "Lab 03 - Bài 01";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 350);
            Controls.Add(label1);
            Controls.Add(btn_udp_client);
            Controls.Add(btn_udp_server);
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard - UDP Client/Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_udp_server;
        private Button btn_udp_client;
        private Label label1;
    }
}
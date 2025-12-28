namespace Exercise3_Lab03
{
    partial class TCPClientForm
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
            txt_server_ip = new TextBox();
            label2 = new Label();
            txt_server_port = new TextBox();
            btn_connect = new Button();
            btn_disconnect = new Button();
            label3 = new Label();
            txt_message = new TextBox();
            btn_send = new Button();
            txt_log = new TextBox();
            label4 = new Label();
            lbl_status = new Label();
            btn_clear_log = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 30);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 0;
            label1.Text = "Server IP:";
            // 
            // txt_server_ip
            // 
            txt_server_ip.Font = new Font("Consolas", 10F);
            txt_server_ip.Location = new Point(120, 27);
            txt_server_ip.Name = "txt_server_ip";
            txt_server_ip.Size = new Size(180, 27);
            txt_server_ip.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(320, 30);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 2;
            label2.Text = "Port:";
            // 
            // txt_server_port
            // 
            txt_server_port.Font = new Font("Consolas", 10F);
            txt_server_port.Location = new Point(370, 27);
            txt_server_port.Name = "txt_server_port";
            txt_server_port.Size = new Size(100, 27);
            txt_server_port.TabIndex = 3;
            // 
            // btn_connect
            // 
            btn_connect.BackColor = Color.LightGreen;
            btn_connect.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_connect.Location = new Point(490, 22);
            btn_connect.Name = "btn_connect";
            btn_connect.Size = new Size(120, 38);
            btn_connect.TabIndex = 4;
            btn_connect.Text = "Connect";
            btn_connect.UseVisualStyleBackColor = false;
            btn_connect.Click += btn_connect_Click;
            // 
            // btn_disconnect
            // 
            btn_disconnect.BackColor = Color.LightCoral;
            btn_disconnect.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_disconnect.Location = new Point(625, 22);
            btn_disconnect.Name = "btn_disconnect";
            btn_disconnect.Size = new Size(120, 38);
            btn_disconnect.TabIndex = 5;
            btn_disconnect.Text = "Disconnect";
            btn_disconnect.UseVisualStyleBackColor = false;
            btn_disconnect.Click += btn_disconnect_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 35);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 6;
            label3.Text = "Message:";
            // 
            // txt_message
            // 
            txt_message.Font = new Font("Segoe UI", 10F);
            txt_message.Location = new Point(15, 60);
            txt_message.Multiline = true;
            txt_message.Name = "txt_message";
            txt_message.ScrollBars = ScrollBars.Vertical;
            txt_message.Size = new Size(600, 80);
            txt_message.TabIndex = 7;
            txt_message.KeyDown += txt_message_KeyDown;
            // 
            // btn_send
            // 
            btn_send.BackColor = Color.LightSkyBlue;
            btn_send.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_send.Location = new Point(630, 60);
            btn_send.Name = "btn_send";
            btn_send.Size = new Size(120, 80);
            btn_send.TabIndex = 8;
            btn_send.Text = "Send";
            btn_send.UseVisualStyleBackColor = false;
            btn_send.Click += btn_send_Click;
            // 
            // txt_log
            // 
            txt_log.BackColor = SystemColors.Info;
            txt_log.Font = new Font("Consolas", 9F);
            txt_log.Location = new Point(20, 370);
            txt_log.Multiline = true;
            txt_log.Name = "txt_log";
            txt_log.ReadOnly = true;
            txt_log.ScrollBars = ScrollBars.Vertical;
            txt_log.Size = new Size(760, 180);
            txt_log.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(20, 342);
            label4.Name = "label4";
            label4.Size = new Size(106, 23);
            label4.TabIndex = 10;
            label4.Text = "Activity Log";
            // 
            // lbl_status
            // 
            lbl_status.AutoSize = true;
            lbl_status.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbl_status.ForeColor = Color.Red;
            lbl_status.Location = new Point(20, 560);
            lbl_status.Name = "lbl_status";
            lbl_status.Size = new Size(210, 23);
            lbl_status.TabIndex = 11;
            lbl_status.Text = "Trạng thái: Chưa kết nối";
            // 
            // btn_clear_log
            // 
            btn_clear_log.BackColor = Color.LightGray;
            btn_clear_log.Location = new Point(680, 335);
            btn_clear_log.Name = "btn_clear_log";
            btn_clear_log.Size = new Size(100, 30);
            btn_clear_log.TabIndex = 12;
            btn_clear_log.Text = "Clear Log";
            btn_clear_log.UseVisualStyleBackColor = false;
            btn_clear_log.Click += btn_clear_log_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txt_server_ip);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btn_disconnect);
            groupBox1.Controls.Add(txt_server_port);
            groupBox1.Controls.Add(btn_connect);
            groupBox1.Location = new Point(20, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(760, 75);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Connection Settings";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(txt_message);
            groupBox2.Controls.Add(btn_send);
            groupBox2.Location = new Point(20, 110);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(760, 160);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "Send Message";
            // 
            // TCPClientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btn_clear_log);
            Controls.Add(lbl_status);
            Controls.Add(label4);
            Controls.Add(txt_log);
            Name = "TCPClientForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TCP Client - Bài 03";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txt_server_ip;
        private Label label2;
        private TextBox txt_server_port;
        private Button btn_connect;
        private Button btn_disconnect;
        private Label label3;
        private TextBox txt_message;
        private Button btn_send;
        private TextBox txt_log;
        private Label label4;
        private Label lbl_status;
        private Button btn_clear_log;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}

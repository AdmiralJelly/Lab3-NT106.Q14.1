namespace Exercise3_Lab03
{
    partial class TCPServerForm
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
            txt_port = new TextBox();
            btn_listen = new Button();
            btn_stop = new Button();
            txt_chat = new TextBox();
            label2 = new Label();
            lbl_status = new Label();
            btn_clear = new Button();
            lbl_client_info = new Label();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 35);
            label1.Name = "label1";
            label1.Size = new Size(93, 20);
            label1.TabIndex = 0;
            label1.Text = "Listen Port:";
            // 
            // txt_port
            // 
            txt_port.Font = new Font("Consolas", 10F);
            txt_port.Location = new Point(125, 32);
            txt_port.Name = "txt_port";
            txt_port.Size = new Size(120, 27);
            txt_port.TabIndex = 1;
            // 
            // btn_listen
            // 
            btn_listen.BackColor = Color.LightGreen;
            btn_listen.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_listen.Location = new Point(270, 25);
            btn_listen.Name = "btn_listen";
            btn_listen.Size = new Size(120, 40);
            btn_listen.TabIndex = 2;
            btn_listen.Text = "Listen";
            btn_listen.UseVisualStyleBackColor = false;
            btn_listen.Click += btn_listen_Click;
            // 
            // btn_stop
            // 
            btn_stop.BackColor = Color.LightCoral;
            btn_stop.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_stop.Location = new Point(410, 25);
            btn_stop.Name = "btn_stop";
            btn_stop.Size = new Size(120, 40);
            btn_stop.TabIndex = 3;
            btn_stop.Text = "Stop";
            btn_stop.UseVisualStyleBackColor = false;
            btn_stop.Click += btn_stop_Click;
            // 
            // txt_chat
            // 
            txt_chat.BackColor = SystemColors.Info;
            txt_chat.Font = new Font("Consolas", 9F);
            txt_chat.Location = new Point(20, 170);
            txt_chat.Multiline = true;
            txt_chat.Name = "txt_chat";
            txt_chat.ReadOnly = true;
            txt_chat.ScrollBars = ScrollBars.Vertical;
            txt_chat.Size = new Size(760, 340);
            txt_chat.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(20, 142);
            label2.Name = "label2";
            label2.Size = new Size(137, 23);
            label2.TabIndex = 5;
            label2.Text = "Server Chat Log";
            // 
            // lbl_status
            // 
            lbl_status.AutoSize = true;
            lbl_status.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbl_status.ForeColor = Color.Red;
            lbl_status.Location = new Point(20, 520);
            lbl_status.Name = "lbl_status";
            lbl_status.Size = new Size(231, 23);
            lbl_status.TabIndex = 6;
            lbl_status.Text = "Trạng thái: Chưa lắng nghe";
            // 
            // btn_clear
            // 
            btn_clear.BackColor = Color.LightGray;
            btn_clear.Location = new Point(680, 135);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(100, 30);
            btn_clear.TabIndex = 7;
            btn_clear.Text = "Clear";
            btn_clear.UseVisualStyleBackColor = false;
            btn_clear.Click += btn_clear_Click;
            // 
            // lbl_client_info
            // 
            lbl_client_info.AutoSize = true;
            lbl_client_info.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbl_client_info.ForeColor = Color.Gray;
            lbl_client_info.Location = new Point(400, 520);
            lbl_client_info.Name = "lbl_client_info";
            lbl_client_info.Size = new Size(143, 23);
            lbl_client_info.TabIndex = 8;
            lbl_client_info.Text = "Client: Không có";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txt_port);
            groupBox1.Controls.Add(btn_stop);
            groupBox1.Controls.Add(btn_listen);
            groupBox1.Location = new Point(20, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(760, 80);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Server Settings";
            // 
            // TCPServerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 560);
            Controls.Add(groupBox1);
            Controls.Add(lbl_client_info);
            Controls.Add(btn_clear);
            Controls.Add(lbl_status);
            Controls.Add(label2);
            Controls.Add(txt_chat);
            Name = "TCPServerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TCP Server - Bài 03";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txt_port;
        private Button btn_listen;
        private Button btn_stop;
        private TextBox txt_chat;
        private Label label2;
        private Label lbl_status;
        private Button btn_clear;
        private Label lbl_client_info;
        private GroupBox groupBox1;
    }
}

namespace Exercise1_Lab03
{
    partial class Server
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
            lb_port = new Label();
            txt_show_mes = new RichTextBox();
            txt_send = new TextBox();
            txt_port = new TextBox();
            btn_send = new Button();
            btn_connect = new Button();
            btn_close = new Button();
            SuspendLayout();
            // 
            // lb_port
            // 
            lb_port.AutoSize = true;
            lb_port.Location = new Point(26, 53);
            lb_port.Name = "lb_port";
            lb_port.Size = new Size(48, 25);
            lb_port.TabIndex = 12;
            lb_port.Text = "Port:";
            // 
            // txt_show_mes
            // 
            txt_show_mes.Location = new Point(26, 101);
            txt_show_mes.Name = "txt_show_mes";
            txt_show_mes.ReadOnly = true;
            txt_show_mes.Size = new Size(748, 230);
            txt_show_mes.TabIndex = 10;
            txt_show_mes.Text = "";
            // 
            // txt_send
            // 
            txt_send.Location = new Point(26, 375);
            txt_send.Name = "txt_send";
            txt_send.Size = new Size(622, 31);
            txt_send.TabIndex = 9;
            // 
            // txt_port
            // 
            txt_port.Location = new Point(128, 47);
            txt_port.Name = "txt_port";
            txt_port.Size = new Size(100, 31);
            txt_port.TabIndex = 13;
            // 
            // btn_send
            // 
            btn_send.Location = new Point(662, 372);
            btn_send.Name = "btn_send";
            btn_send.Size = new Size(112, 34);
            btn_send.TabIndex = 7;
            btn_send.Text = "Send";
            btn_send.UseVisualStyleBackColor = true;
            btn_send.Click += btn_send_Click;
            // 
            // btn_connect
            // 
            btn_connect.Location = new Point(530, 95); 
            // Wait, txt_port is at 128, 47. 
            // Let's check original coordinates.
            // txt_port was 128, 47, size 100. ends at 228.
            // btn_connect at 590, 44.
            // I'll put btn_close at 240, 44 for easy access? No.
            // I'll put it next to Listen.
            
            btn_connect.Location = new Point(590, 44);
            btn_connect.Name = "btn_connect";
            btn_connect.Size = new Size(112, 34);
            btn_connect.TabIndex = 6;
            btn_connect.Text = "Listen";
            btn_connect.UseVisualStyleBackColor = true;
            btn_connect.Click += btn_connect_Click;
            // 
            // btn_close
            // 
            btn_close.Location = new Point(710, 44);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(80, 34); // Reduce width slightly if needed to fit comfortably or keep 110 if 800 width allows. 710+112 = 822 > 800. 
            // Wait, 590 + 112 = 702. 
            // If I put at 710, and width 112, it goes to 822. Off screen.
            // Client Width 800.
            // I should reduce width or move it left.
            // Space between Port box (ends 228) and Connect (590) is huge (362 pixels).
            // Let's put Stop button to the LEFT of Connect button?
            // Connect at 590. Stop at 590 - 120 = 470.
            // 470 is safe ( > 228).
            // Let's put Stop at 470, 44.
            // Or better, move Connect to right?
            // Let's just put Stop at 470, 44.
            btn_close.Location = new Point(470, 44);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(112, 34);
            btn_close.TabIndex = 14;
            btn_close.Text = "Stop";
            btn_close.UseVisualStyleBackColor = true;
            btn_close.Click += btn_close_Click;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lb_port);
            Controls.Add(txt_port);
            Controls.Add(txt_show_mes);
            Controls.Add(txt_send);
            Controls.Add(btn_send);
            Controls.Add(btn_connect);
            Controls.Add(btn_close);
            Name = "Server";
            Text = "Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lb_port;
        private RichTextBox txt_show_mes;
        private TextBox txt_send;
        private TextBox txt_port;
        private Button btn_send;
        private Button btn_connect;
        private Button btn_close;
    }
}
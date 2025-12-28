namespace Exercise2_Lab03
{
    partial class TCPListener
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
            btn_listen = new Button();
            listView_messages = new ListView();
            columnHeader1 = new ColumnHeader();
            btn_clear = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // btn_listen
            // 
            btn_listen.BackColor = SystemColors.ControlLight;
            btn_listen.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btn_listen.Location = new Point(500, 30);
            btn_listen.Name = "btn_listen";
            btn_listen.Size = new Size(120, 45);
            btn_listen.TabIndex = 0;
            btn_listen.Text = "Listen";
            btn_listen.UseVisualStyleBackColor = false;
            btn_listen.Click += btn_listen_Click;
            // 
            // listView_messages
            // 
            listView_messages.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            listView_messages.Font = new Font("Consolas", 10F);
            listView_messages.FullRowSelect = true;
            listView_messages.GridLines = true;
            listView_messages.HeaderStyle = ColumnHeaderStyle.None;
            listView_messages.Location = new Point(20, 100);
            listView_messages.Name = "listView_messages";
            listView_messages.Size = new Size(760, 400);
            listView_messages.TabIndex = 1;
            listView_messages.UseCompatibleStateImageBehavior = false;
            listView_messages.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Messages";
            columnHeader1.Width = 750;
            // 
            // btn_clear
            // 
            btn_clear.BackColor = SystemColors.ControlLight;
            btn_clear.Font = new Font("Segoe UI", 10F);
            btn_clear.Location = new Point(640, 30);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(100, 45);
            btn_clear.TabIndex = 2;
            btn_clear.Text = "Clear";
            btn_clear.UseVisualStyleBackColor = false;
            btn_clear.Click += btn_clear_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(221, 32);
            label1.TabIndex = 3;
            label1.Text = "TCP Telnet Listener";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(20, 52);
            label2.Name = "label2";
            label2.Size = new Size(395, 23);
            label2.TabIndex = 4;
            label2.Text = "Listening on port 8080 - Use: telnet <IP> 8080";
            // 
            // TCPListener
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 530);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_clear);
            Controls.Add(listView_messages);
            Controls.Add(btn_listen);
            Name = "TCPListener";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 02 - TCP Listener for Telnet";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_listen;
        private ListView listView_messages;
        private ColumnHeader columnHeader1;
        private Button btn_clear;
        private Label label1;
        private Label label2;
    }
}

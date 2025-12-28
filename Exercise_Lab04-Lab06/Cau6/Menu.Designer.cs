namespace Cau6
{
    partial class Menu
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
            this.btn_client = new System.Windows.Forms.Button();
            this.btn_server = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_client
            // 
            this.btn_client.Font = new System.Drawing.Font("Cascadia Code SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_client.Location = new System.Drawing.Point(245, 195);
            this.btn_client.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_client.Name = "btn_client";
            this.btn_client.Size = new System.Drawing.Size(228, 40);
            this.btn_client.TabIndex = 3;
            this.btn_client.Text = "New Client";
            this.btn_client.UseVisualStyleBackColor = true;
            this.btn_client.Click += new System.EventHandler(this.btn_client_Click);
            // 
            // btn_server
            // 
            this.btn_server.Font = new System.Drawing.Font("Cascadia Code SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_server.Location = new System.Drawing.Point(289, 123);
            this.btn_server.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_server.Name = "btn_server";
            this.btn_server.Size = new System.Drawing.Size(133, 40);
            this.btn_server.TabIndex = 2;
            this.btn_server.Text = "Server";
            this.btn_server.UseVisualStyleBackColor = true;
            this.btn_server.Click += new System.EventHandler(this.btn_server_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.btn_client);
            this.Controls.Add(this.btn_server);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_client;
        private System.Windows.Forms.Button btn_server;
    }
}
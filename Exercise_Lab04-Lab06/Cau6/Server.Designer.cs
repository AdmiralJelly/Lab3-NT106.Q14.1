namespace Cau6
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
            this.btn_listen = new System.Windows.Forms.Button();
            this.lw_log = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btn_listen
            // 
            this.btn_listen.Font = new System.Drawing.Font("Cascadia Code SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listen.ForeColor = System.Drawing.Color.DarkBlue;
            this.btn_listen.Location = new System.Drawing.Point(468, 24);
            this.btn_listen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_listen.Name = "btn_listen";
            this.btn_listen.Size = new System.Drawing.Size(109, 32);
            this.btn_listen.TabIndex = 5;
            this.btn_listen.Text = "Listen";
            this.btn_listen.UseVisualStyleBackColor = true;
            this.btn_listen.Click += new System.EventHandler(this.btn_listen_Click);
            // 
            // lw_log
            // 
            this.lw_log.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lw_log.HideSelection = false;
            this.lw_log.Location = new System.Drawing.Point(134, 79);
            this.lw_log.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lw_log.Name = "lw_log";
            this.lw_log.Size = new System.Drawing.Size(443, 258);
            this.lw_log.TabIndex = 4;
            this.lw_log.UseCompatibleStateImageBehavior = false;
            this.lw_log.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 498;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.btn_listen);
            this.Controls.Add(this.lw_log);
            this.ForeColor = System.Drawing.Color.Cornsilk;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Server";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_listen;
        private System.Windows.Forms.ListView lw_log;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}


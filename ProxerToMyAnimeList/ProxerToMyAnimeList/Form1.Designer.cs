namespace ProxerToMyAnimeList
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_proxerWatchlist = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.tb_username = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bn_export = new System.Windows.Forms.Button();
            this.lb_status = new System.Windows.Forms.Label();
            this.bn_delete_wholeList = new System.Windows.Forms.Button();
            this.cb_overwritte = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_proxerWatchlist
            // 
            this.tb_proxerWatchlist.Location = new System.Drawing.Point(155, 12);
            this.tb_proxerWatchlist.Name = "tb_proxerWatchlist";
            this.tb_proxerWatchlist.Size = new System.Drawing.Size(610, 20);
            this.tb_proxerWatchlist.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Proxer Account Seite";
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(157, 64);
            this.tb_password.Name = "tb_password";
            this.tb_password.PasswordChar = '*';
            this.tb_password.Size = new System.Drawing.Size(148, 20);
            this.tb_password.TabIndex = 3;
            // 
            // tb_username
            // 
            this.tb_username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_username.Location = new System.Drawing.Point(157, 26);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(148, 20);
            this.tb_username.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_password);
            this.groupBox1.Controls.Add(this.tb_username);
            this.groupBox1.Location = new System.Drawing.Point(47, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MyAnimeList Account Daten";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Passwort";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Benutzername";
            // 
            // bn_export
            // 
            this.bn_export.Location = new System.Drawing.Point(690, 271);
            this.bn_export.Name = "bn_export";
            this.bn_export.Size = new System.Drawing.Size(75, 23);
            this.bn_export.TabIndex = 6;
            this.bn_export.Text = "Exportieren";
            this.bn_export.UseVisualStyleBackColor = true;
            this.bn_export.Click += new System.EventHandler(this.bn_export_Click);
            // 
            // lb_status
            // 
            this.lb_status.AutoSize = true;
            this.lb_status.Location = new System.Drawing.Point(47, 48);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(35, 13);
            this.lb_status.TabIndex = 7;
            this.lb_status.Text = "label4";
            // 
            // bn_delete_wholeList
            // 
            this.bn_delete_wholeList.Location = new System.Drawing.Point(477, 270);
            this.bn_delete_wholeList.Name = "bn_delete_wholeList";
            this.bn_delete_wholeList.Size = new System.Drawing.Size(75, 23);
            this.bn_delete_wholeList.TabIndex = 8;
            this.bn_delete_wholeList.Text = "bn_delete_wholeList";
            this.bn_delete_wholeList.UseVisualStyleBackColor = true;
            this.bn_delete_wholeList.Click += new System.EventHandler(this.bn_delete_wholeList_Click);
            // 
            // cb_overwritte
            // 
            this.cb_overwritte.AutoSize = true;
            this.cb_overwritte.Location = new System.Drawing.Point(47, 78);
            this.cb_overwritte.Name = "cb_overwritte";
            this.cb_overwritte.Size = new System.Drawing.Size(213, 17);
            this.cb_overwritte.TabIndex = 9;
            this.cb_overwritte.Text = "Die List von myAnimeList überschreiben";
            this.cb_overwritte.UseVisualStyleBackColor = true;
            this.cb_overwritte.CheckedChanged += new System.EventHandler(this.cb_overwritte_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 321);
            this.Controls.Add(this.cb_overwritte);
            this.Controls.Add(this.bn_delete_wholeList);
            this.Controls.Add(this.lb_status);
            this.Controls.Add(this.bn_export);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_proxerWatchlist);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_proxerWatchlist;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.TextBox tb_username;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bn_export;
        private System.Windows.Forms.Label lb_status;
        private System.Windows.Forms.Button bn_delete_wholeList;
        private System.Windows.Forms.CheckBox cb_overwritte;
    }
}


namespace ImageToASCIIconverter
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnConvertToAscii = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ñïðàâêàToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.îÏðîãðàììåToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.browserMain = new System.Windows.Forms.WebBrowser();
            this.gffgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gfgfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConvertToAscii
            // 
            this.btnConvertToAscii.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConvertToAscii.Location = new System.Drawing.Point(243, 105);
            this.btnConvertToAscii.Name = "btnConvertToAscii";
            this.btnConvertToAscii.Size = new System.Drawing.Size(187, 23);
            this.btnConvertToAscii.TabIndex = 3;
            this.btnConvertToAscii.Text = "Ïðåîáðàçîâàòü â ASCII";
            this.btnConvertToAscii.UseVisualStyleBackColor = true;
            this.btnConvertToAscii.Click += new System.EventHandler(this.btnConvertToAscii_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse.Location = new System.Drawing.Point(356, 47);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(74, 23);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "Îòêðûòü";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtPath
            // 
            this.txtPath.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtPath.Location = new System.Drawing.Point(12, 49);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(338, 20);
            this.txtPath.TabIndex = 6;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(441, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem,
            this.ñïðàâêàToolStripMenuItem,
            this.îÏðîãðàììåToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Ôàèë";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Ñîõðàíèòü êàê";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // ñïðàâêàToolStripMenuItem
            // 
            this.ñïðàâêàToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ñïðàâêàToolStripMenuItem.Name = "ñïðàâêàToolStripMenuItem";
            this.ñïðàâêàToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ñïðàâêàToolStripMenuItem.Text = "Ñïðàâêà";
            this.ñïðàâêàToolStripMenuItem.Click += new System.EventHandler(this.ñïðàâêàToolStripMenuItem_Click);
            // 
            // îÏðîãðàììåToolStripMenuItem
            // 
            this.îÏðîãðàììåToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.îÏðîãðàììåToolStripMenuItem.Name = "îÏðîãðàììåToolStripMenuItem";
            this.îÏðîãðàììåToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.îÏðîãðàììåToolStripMenuItem.Text = "Î ïðîãðàììå";
            this.îÏðîãðàììåToolStripMenuItem.Click += new System.EventHandler(this.îÏðîãðàììåToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Âûõîä";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click_1);
            // 
            // trackBar
            // 
            this.trackBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBar.Location = new System.Drawing.Point(12, 95);
            this.trackBar.Maximum = 400;
            this.trackBar.Minimum = 1;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(214, 45);
            this.trackBar.TabIndex = 9;
            this.trackBar.TickFrequency = 20;
            this.trackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar.Value = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ïóòü ê êàðòèíêè:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(72, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Ðàçìåð êàðòèíêè:";
            // 
            // browserMain
            // 
            this.browserMain.AllowWebBrowserDrop = false;
            this.browserMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.browserMain.IsWebBrowserContextMenuEnabled = false;
            this.browserMain.Location = new System.Drawing.Point(12, 162);
            this.browserMain.MinimumSize = new System.Drawing.Size(20, 20);
            this.browserMain.Name = "browserMain";
            this.browserMain.Size = new System.Drawing.Size(417, 278);
            this.browserMain.TabIndex = 7;
            // 
            // gffgToolStripMenuItem
            // 
            this.gffgToolStripMenuItem.Name = "gffgToolStripMenuItem";
            this.gffgToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // gfgfToolStripMenuItem
            // 
            this.gfgfToolStripMenuItem.Name = "gfgfToolStripMenuItem";
            this.gfgfToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(441, 449);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.browserMain);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnConvertToAscii);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "ASCII Art  Ãåíåðàòîð";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

     
      
        #endregion

        private System.Windows.Forms.Button btnConvertToAscii;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.WebBrowser browserMain;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem îÏðîãðàììåToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ñïðàâêàToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gffgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gfgfToolStripMenuItem;
    }
}


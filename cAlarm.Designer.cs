namespace cAlarm
{
    partial class cAlarm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cAlarm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnPluss = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.playlistOperationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportFilesToFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alarmsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openAlarmlistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAlarmListToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Controls.Add(this.btnPause);
            this.groupBox1.Controls.Add(this.btnPlay);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 252);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Playlist:  (drag files to list)  ";
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPause.BackgroundImage = global::cAlarm.Properties.Resources.stop;
            this.btnPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPause.Location = new System.Drawing.Point(298, 225);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(40, 23);
            this.btnPause.TabIndex = 1;
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPlay.BackgroundImage = global::cAlarm.Properties.Resources.play1;
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPlay.Location = new System.Drawing.Point(251, 225);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(41, 23);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(7, 20);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(339, 199);
            this.listBox1.TabIndex = 0;
            this.listBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox1_DragDrop);
            this.listBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox1_DragEnter);
            this.listBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listBox1_KeyPress);
            this.listBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyUp);
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox2.Controls.Add(this.btnMinus);
            this.groupBox2.Controls.Add(this.btnPluss);
            this.groupBox2.Controls.Add(this.checkedListBox1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(370, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(202, 252);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Alarms:";
            // 
            // btnMinus
            // 
            this.btnMinus.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMinus.BackgroundImage = global::cAlarm.Properties.Resources.minus;
            this.btnMinus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMinus.Location = new System.Drawing.Point(142, 225);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(41, 23);
            this.btnMinus.TabIndex = 2;
            this.btnMinus.Text = "-";
            this.btnMinus.UseVisualStyleBackColor = false;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnPluss
            // 
            this.btnPluss.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPluss.BackgroundImage = global::cAlarm.Properties.Resources.pluss;
            this.btnPluss.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPluss.Location = new System.Drawing.Point(95, 225);
            this.btnPluss.Name = "btnPluss";
            this.btnPluss.Size = new System.Drawing.Size(41, 23);
            this.btnPluss.TabIndex = 1;
            this.btnPluss.UseVisualStyleBackColor = false;
            this.btnPluss.Click += new System.EventHandler(this.btnPluss_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(6, 20);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(183, 199);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            this.checkedListBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkedListBox1_KeyUp);
            this.checkedListBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.checkedListBox1_MouseDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SkyBlue;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playlistOperationsToolStripMenuItem,
            this.alarmsToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(585, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // playlistOperationsToolStripMenuItem
            // 
            this.playlistOperationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPlaylistToolStripMenuItem,
            this.savePlaylistToolStripMenuItem,
            this.exportFilesToFolderToolStripMenuItem,
            this.clearPlaylistToolStripMenuItem});
            this.playlistOperationsToolStripMenuItem.Name = "playlistOperationsToolStripMenuItem";
            this.playlistOperationsToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.playlistOperationsToolStripMenuItem.Text = "Playlist operations";
            // 
            // openPlaylistToolStripMenuItem
            // 
            this.openPlaylistToolStripMenuItem.Name = "openPlaylistToolStripMenuItem";
            this.openPlaylistToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.openPlaylistToolStripMenuItem.Text = "Open playlist";
            this.openPlaylistToolStripMenuItem.Click += new System.EventHandler(this.openPlaylistToolStripMenuItem_Click);
            // 
            // savePlaylistToolStripMenuItem
            // 
            this.savePlaylistToolStripMenuItem.Name = "savePlaylistToolStripMenuItem";
            this.savePlaylistToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.savePlaylistToolStripMenuItem.Text = "Save playlist";
            this.savePlaylistToolStripMenuItem.Click += new System.EventHandler(this.savePlaylistToolStripMenuItem_Click);
            // 
            // exportFilesToFolderToolStripMenuItem
            // 
            this.exportFilesToFolderToolStripMenuItem.Name = "exportFilesToFolderToolStripMenuItem";
            this.exportFilesToFolderToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.exportFilesToFolderToolStripMenuItem.Text = "Export files to folder";
            this.exportFilesToFolderToolStripMenuItem.Click += new System.EventHandler(this.exportFilesToFolderToolStripMenuItem_Click);
            // 
            // clearPlaylistToolStripMenuItem
            // 
            this.clearPlaylistToolStripMenuItem.Name = "clearPlaylistToolStripMenuItem";
            this.clearPlaylistToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.clearPlaylistToolStripMenuItem.Text = "Clear playlist";
            this.clearPlaylistToolStripMenuItem.Click += new System.EventHandler(this.clearPlaylistToolStripMenuItem_Click);
            // 
            // alarmsToolStripMenuItem
            // 
            this.alarmsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openAlarmlistToolStripMenuItem,
            this.saveAlarmListToolStripMenuItem1});
            this.alarmsToolStripMenuItem.Name = "alarmsToolStripMenuItem";
            this.alarmsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.alarmsToolStripMenuItem.Text = "Alarms";
            // 
            // openAlarmlistToolStripMenuItem
            // 
            this.openAlarmlistToolStripMenuItem.Name = "openAlarmlistToolStripMenuItem";
            this.openAlarmlistToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.openAlarmlistToolStripMenuItem.Text = "Open alarm list";
            this.openAlarmlistToolStripMenuItem.Click += new System.EventHandler(this.openAlarmlistToolStripMenuItem_Click);
            // 
            // saveAlarmListToolStripMenuItem1
            // 
            this.saveAlarmListToolStripMenuItem1.Name = "saveAlarmListToolStripMenuItem1";
            this.saveAlarmListToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.saveAlarmListToolStripMenuItem1.Text = "Save alarm list";
            this.saveAlarmListToolStripMenuItem1.Click += new System.EventHandler(this.saveAlarmListToolStripMenuItem1_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem,
            this.randomToolStripMenuItem});
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.colorToolStripMenuItem.Text = "Color";
            // 
            // defaultToolStripMenuItem
            // 
            this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            this.defaultToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.defaultToolStripMenuItem.Text = "Default";
            this.defaultToolStripMenuItem.Click += new System.EventHandler(this.defaultToolStripMenuItem_Click);
            // 
            // randomToolStripMenuItem
            // 
            this.randomToolStripMenuItem.Name = "randomToolStripMenuItem";
            this.randomToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.randomToolStripMenuItem.Text = "Random";
            this.randomToolStripMenuItem.Click += new System.EventHandler(this.randomToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // cAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(585, 292);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "cAlarm";
            this.Text = "cAlarm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.cAlarm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.cAlarm_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnPluss;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem playlistOperationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savePlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportFilesToFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alarmsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openAlarmlistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAlarmListToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;


    }
}


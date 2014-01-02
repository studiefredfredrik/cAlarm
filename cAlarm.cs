using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;


namespace cAlarm
{
    public partial class cAlarm : Form
    {
        // Version 1.00
        public const string VERSION = "Version 1.10 - 05-june-2013";
        // notifyicon
        private NotifyIcon m_notifyicon = new NotifyIcon();
        private ContextMenu m_menu = new ContextMenu();      

        private List<alarm> alarmList = new List<alarm>();
        private List<string> playList = new List<string>();
        private bool playerHasBeenStopped = true;
        Media player = new Media();

        public cAlarm()
        {
            // create form
            InitializeComponent();
            // create trayicon
            makeTrayIcon();
        }

        // ----------------TRAY ICON RELATED----------------------------------------------
        // PNG converted to icon using http://convertico.com/
        private void makeTrayIcon()
        {
            try
            {
                this.m_menu.MenuItems.Add(0,
                    new MenuItem("Show", new System.EventHandler(Show_Click)));
                this.m_menu.MenuItems.Add(1,
                    new MenuItem("Hide", new System.EventHandler(Hide_Click)));
                this.m_menu.MenuItems.Add(2,
                    new MenuItem("Exit", new System.EventHandler(Exit_Click)));

                this.m_notifyicon.Text = "Right click for context menu";
                this.m_notifyicon.Visible = true;
                this.m_notifyicon.Icon = new Icon("4highres.ico");
                this.m_notifyicon.ContextMenu = m_menu;
                this.m_notifyicon.DoubleClick += new EventHandler(notifyIconDoubbleClicked);
                this.SizeChanged += new System.EventHandler(this.cAlarm_SizeChanged);
            }
            catch (Exception)
            {
            }
        }

        private void cAlarm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.m_notifyicon.ShowBalloonTip(500, "Program running in the background", "Click the icon to open form", ToolTipIcon.Info);
                Hide();
                this.ShowInTaskbar = false;
            }
        }

        protected void notifyIconDoubbleClicked(Object sender, System.EventArgs e)
        {
            if (this.Visible != true)
            {
                Show();
                this.WindowState = FormWindowState.Normal;
            }
            else if (this.Visible)
            {
                Hide();
            }
        }

        protected void Exit_Click(Object sender, System.EventArgs e)
        {
            Close();
        }
        protected void Hide_Click(Object sender, System.EventArgs e)
        {
            Hide();
        }
        protected void Show_Click(Object sender, System.EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        // --------------end trayicon related------------------------------------------

        //Override the WndProc function in the form
        //to receive the notify message when the playback complete
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Media.MM_MCINOTIFY)
            {
                // The file is done playing, do whatever
                // Play next item:
                if (listBox1.SelectedIndex >= 0 && listBox1.SelectedIndex <= listBox1.Items.Count - 2)
                {
                    if (!playerHasBeenStopped)
                    {
                        listBox1.SelectedIndex++;
                        player.Stop();
                        player.Play(playList[listBox1.SelectedIndex], this);
                    }
                }
            }
            base.WndProc(ref m);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // retrieve alarms and playlist from last time
            Serializer opener = new Serializer();
            alarmList.Clear();
            alarmList = opener.openAlarms();
            update_alarmIndex();
            playList = opener.openPlaylist();
            update_playlistIndex();
            
            // Dont allow the user to resize the form (it's perfect as is)
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            // This goes for maximize button as well
            this.MaximizeBox = false;
            // get color if custom
            currentBackColor = opener.openColor();
            menuStrip1.BackColor = currentBackColor;
            this.BackColor = currentBackColor;

            // create timer
            Timer mainTimer = new Timer();
            mainTimer.Interval = 1000;
            mainTimer.Enabled = true;
            mainTimer.Tick +=new EventHandler(mainTimer_Tick);
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            if (checkAlarms(alarmList))
            {
                playerHasBeenStopped = false;
                player.Stop();
                player.Play(playList[0], this);
            }
        }

        private void saveToDisk_Alarms(List<alarm> alarmlist)
        {

        }
        private void saveToDisk_Playlist(List<string> playlist)
        {

        }

        private bool checkAlarms(List<alarm> alarmList) // any alarms going off this second?
        {
            DateTime rightNow = DateTime.Now;
            foreach (alarm s in alarmList) // ready alarms for repeat if selected
            {
                if (Convert.ToInt32(s.hour) == rightNow.Hour &&
                    Convert.ToInt32(s.minute) == rightNow.Minute &&
                    s.activated == true &&
                    s.once != true)
                {
                    s.activated = false;
                }
            }
            foreach (alarm s in alarmList)
            {
                if (Convert.ToInt32(s.hour) == rightNow.Hour &&
                    Convert.ToInt32(s.minute) == rightNow.Minute &&
                    s.activated == false &&
                    s.active == true)
                {
                    if (s.once)
                    {
                        s.activated = true;
                        return true;
                    }
                    if (rightNow.DayOfWeek.Equals("Monday") && s.repeat[1] == 1)
                    {
                        s.activated = true;
                        return true;
                    }
                    if (rightNow.DayOfWeek.Equals("Tuesday") && s.repeat[2] == 1)
                    {
                        s.activated = true;
                        return true;
                    }
                    if (rightNow.DayOfWeek.Equals("Wednesday") && s.repeat[3] == 1)
                    {
                        s.activated = true;
                        return true;
                    }
                    if (rightNow.DayOfWeek.Equals("Thursday") && s.repeat[4] == 1)
                    {
                        s.activated = true;
                        return true;
                    }
                    if (rightNow.DayOfWeek.Equals("Friday") && s.repeat[5] == 1)
                    {
                        s.activated = true;
                        return true;
                    }
                    if (rightNow.DayOfWeek.Equals("Saturday") && s.repeat[6] == 1)
                    {
                        s.activated = true;
                        return true;
                    }
                    if (rightNow.DayOfWeek.Equals("Sunday") && s.repeat[7] == 1)
                    {
                        s.activated = true;
                        return true;
                    }
                }
            }
            return false;
        }

        private void btnPluss_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.Items.Count <= 10)
            {
                addAlarm popup = new addAlarm();
                popup.backColor = currentBackColor;
                popup.ShowDialog();
                if (popup.alarmCreated)
                {
                    alarmList.Add(popup.newAlarm);
                    update_alarmIndex();
                }
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedIndex >= 0)
            {
                alarmList.RemoveAt(checkedListBox1.SelectedIndex);
                update_alarmIndex();
            }
        }

        private void update_alarmIndex()
        {
            checkedListBox1.Items.Clear();
            foreach (alarm s in alarmList)
            {
                string alarmtext = s.hour + ":" + s.minute + " ";
                for(int i = 0; i <= 7; i++) 
                {
                    string[] days = { "", "M", "Tu", "W", "Th", "F", "Sa", "Su" };
                    if (s.repeat[i] == 1)
                        alarmtext += days[i] + ",";
                }
                checkedListBox1.Items.Add(alarmtext, s.active);
            }
        }

        //update the playlist view
        private void update_playlistIndex()
        {
            listBox1.Items.Clear();

            foreach(string s in playList)
            {
                listBox1.Items.Add(Path.GetFileName(s));
            }
        }

        private void checkedListBox1_MouseDoubleClick(object sender, MouseEventArgs e) // edit alarm
        {
            if (checkedListBox1.Items.Count > 0)
            {
                addAlarm popup = new addAlarm();
                popup.backColor = currentBackColor;
                popup.newAlarm = alarmList[checkedListBox1.SelectedIndex];
                popup.ShowDialog();
                if (popup.alarmCreated)
                {
                    alarmList[checkedListBox1.SelectedIndex] = popup.newAlarm;
                    update_alarmIndex();
                }
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e) 
        {

                alarmList[e.Index].active = Convert.ToBoolean(e.NewValue);
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if(file.EndsWith(".mp3") || file.EndsWith(".wav")) // add more
                    playList.Add(file);
                if (file.EndsWith(".m3u"))
                {
                    string[] m3ulist = File.ReadAllLines(file);
                    foreach (string s in m3ulist)
                    {
                        playList.Add(s);
                    }
                }
            }
            update_playlistIndex();
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                player.Stop();
                player.Play(playList[listBox1.SelectedIndex], this);
            }
        }

        private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void listBox1_KeyUp(object sender, KeyEventArgs e) // if delete key pressed
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (listBox1.SelectedIndex >= 0)
                {
                    int selected = listBox1.SelectedIndex;
                    playList.RemoveAt(selected);
                    listBox1.Items.RemoveAt(selected);
                    listBox1.SelectedIndex = selected - 1;
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                playerHasBeenStopped = false;
                player.Stop();
                player.Play(playList[listBox1.SelectedIndex], this);
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            playerHasBeenStopped = true;
            player.Stop();
        }

        private void PlayerDone(object sender, EventArgs e)
        {
            listBox1.SelectedIndex++;
            player.Play(playList[listBox1.SelectedIndex], this);
        }

        private void openPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            OpenFileDialog diag = new OpenFileDialog();
            diag.Filter = "Playlist (*.m3u) | *.m3u";
            DialogResult result = diag.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                Serializer open = new Serializer();
                playList = open.openPlaylist(diag.FileName);
            }
        }

        private void savePlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog diag = new SaveFileDialog();
            diag.Filter = "Playlist (*.m3u) | *.m3u";
            DialogResult result = diag.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                Serializer saver = new Serializer();
                saver.savePlaylist(playList, diag.FileName);
            }
        }

        private void exportFilesToFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlaylistExport expdialog = new PlaylistExport();
            expdialog.backColor = currentBackColor;
            expdialog.Playlist = playList;
            expdialog.ShowDialog();
        }

        private void saveAlarmListToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            SaveFileDialog diag = new SaveFileDialog();
            diag.Filter = "Alarmlist (*.lrm) | *.lrm";
            DialogResult result = diag.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                Serializer saver = new Serializer();
                saver.saveAlarms_force(alarmList, diag.FileName);
            }
        }

        private void openAlarmlistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            OpenFileDialog diag = new OpenFileDialog();
            diag.Filter = "Alarmlist (*.lrm) | *.lrm";
            DialogResult result = diag.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                Serializer opener = new Serializer();
                alarmList.Clear();
                alarmList = opener.openAlarms(diag.FileName);
                update_alarmIndex();
            }
        }

        // before closing, save current status
        private void cAlarm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Serializer saver = new Serializer();
            saver.saveAlarms(alarmList);
            saver.savePlaylist(playList);
            saver.saveColor(currentBackColor);
            // dispose trayIcon
            m_notifyicon.Dispose();
        }

        // clear playlist
        private void clearPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playList.Clear();
            update_playlistIndex();
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentBackColor = Color.SkyBlue;
            menuStrip1.BackColor = currentBackColor;
            cAlarm.ActiveForm.BackColor = currentBackColor;
        }

        private void randomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorGenerator rd = new ColorGenerator();
            currentBackColor = rd.newRandomColor();
            menuStrip1.BackColor = currentBackColor;
            cAlarm.ActiveForm.BackColor = currentBackColor;
        }
        private Color currentBackColor = Color.SkyBlue;


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDialog diag = new AboutDialog();
            diag.backColor = currentBackColor;
            diag.ShowDialog();
        }

        private void checkedListBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (checkedListBox1.SelectedIndex >= 0)
                {
                    int selected = checkedListBox1.SelectedIndex;
                    alarmList.RemoveAt(selected);
                    checkedListBox1.Items.RemoveAt(selected);
                    checkedListBox1.SelectedIndex = selected - 1;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace cAlarm
{
    public partial class PlaylistExport : Form
    {
        private List<string> playlist = new List<string>();
        public int exceptions = 0;
        public string path = "";

        public PlaylistExport()
        {
            InitializeComponent();
        }

        public Color backColor = Color.SkyBlue;

        private void PlaylistExport_Load(object sender, EventArgs e)
        {
            this.BackColor = backColor;
            btnViewFolder.Visible = false;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(update_progress);
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            DialogResult result = folderBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 100;
                label1.Text = "Copying files...";
                path = folderBrowser.SelectedPath;
                backgroundWorker1.RunWorkerAsync(path);
            }
            else
                this.Close();
        }
        private void update_progress(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            if (e.ProgressPercentage == 100)
            {
                if (exceptions != 0)
                    label1.Text = "Not all files could be processed: " + exceptions + " exceptions ocurred";
                if (exceptions == 0)
                    label1.Text = "All files copied without exceptions";
                btnViewFolder.Visible = true;
            }
        }
        public List<string> Playlist
        {
            set
            {
                playlist = value;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string path = (string)e.Argument;
            int fileWorked = 0;
            
            foreach (string s in playlist)
            {
                try
                {
                    // Some playlist entries dont use full paths
                    // if the file is on the Desktop it will use that as the root folder, 
                    // causing an invalid path exception. And so we need to check for this
                    if (s.Contains(":\\")) // Path starts with a driveletter, assume valid path
                    {
                        if(File.Exists(s))
                        {
                        string sfilename = Path.GetFileName(s);
                        File.Copy(s, path + "\\" + sfilename);
                        fileWorked++;
                        float percent = (float)(fileWorked * 100) / playlist.Count;
                        backgroundWorker1.ReportProgress(Convert.ToInt32(percent));
                        }
                        else
                        {
                            // File not found exception
                            fileWorked++;
                            float percent = (float)(fileWorked * 100) / playlist.Count;
                            backgroundWorker1.ReportProgress(Convert.ToInt32(percent));
                            exceptions++;
                        }
                    }
                    else // Incomplete path detected, check user Desktop
                    {
                        string dPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + s;
                        if (File.Exists(dPath))
                        {
                            string sfilename = Path.GetFileName(s);
                            File.Copy(dPath, path + "\\" + sfilename);
                            fileWorked++;
                            float percent = (float)(fileWorked * 100) / playlist.Count;
                            backgroundWorker1.ReportProgress(Convert.ToInt32(percent));
                        }
                        else
                        {
                            // File not found exception
                            fileWorked++;
                            float percent = (float)(fileWorked * 100) / playlist.Count;
                            backgroundWorker1.ReportProgress(Convert.ToInt32(percent));
                            exceptions++;
                        }
                    }
                }
                catch (Exception)
                {
                    exceptions++;
                }
            }
        }

        private void btnViewFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", path);
        }
    }
}
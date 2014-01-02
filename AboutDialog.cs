using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cAlarm
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();
        }
        public Color backColor = Color.SkyBlue;

        private void AboutDialog_Load(object sender, EventArgs e)
        {
            linkLabel1.Links.Add(0, 33, "http://newfreshpeace.blogspot.com");
            this.BackColor = backColor;
            label2.Text = cAlarm.VERSION;
            label1.Text = "Made in C#, open source.\n" +
                "Distribute freely.\n" +
                "Steal, code and visit my blog:";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }
    }
}

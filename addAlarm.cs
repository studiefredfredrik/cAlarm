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
    public partial class addAlarm : Form
    {
        public alarm newAlarm = new alarm("", "");
        public bool alarmCreated = false;
        private string[] hours = new string[24];
        private string[] minutes = new string[60];
        public addAlarm()
        {
            InitializeComponent();
        }

        private void readAlarmToForm()
        {
            // check if the form has recieved a alarm for edit
            if (newAlarm.hour != "")
            {
                alarmCreated = true;
                if (newAlarm.repeat[1] == 1)
                    cboM.Checked = true;
                if (newAlarm.repeat[2] == 1)
                    cboTu.Checked = true;
                if (newAlarm.repeat[3] == 1)
                    cboW.Checked = true;
                if (newAlarm.repeat[4] == 1)
                    cboTh.Checked = true;
                if (newAlarm.repeat[5] == 1)
                    cboF.Checked = true;
                if (newAlarm.repeat[6] == 1)
                    cboSa.Checked = true;
                if (newAlarm.repeat[7] == 1)
                    cboSu.Checked = true;
                if (newAlarm.once)
                    rdoOnce.Checked = true;
                if (!newAlarm.once)
                    rdoRepeat.Checked = true;
                cboHour.Text = newAlarm.hour;
                cboMinute.Text = newAlarm.minute;
            }
        }


        public Color backColor = Color.SkyBlue;

        private void addAlarm_Load(object sender, EventArgs e)
        {
            this.BackColor = backColor;
            rdoOnce.Checked = true;
            readAlarmToForm();
            for(int i = 0; i <= 23; i++)
            {
                if (Convert.ToString(i).Length == 1)
                {
                    hours[i] = "0" + Convert.ToString(i);
                }
                if(Convert.ToString(i).Length == 2)
                {
                    hours[i] = Convert.ToString(i);
                }
                cboHour.Items.Add(Convert.ToString(hours[i]));
            }
            for (int i = 0; i <= 59; i++)
            {
                if (Convert.ToString(i).Length == 1)
                {
                    minutes[i] = "0" + Convert.ToString(i);
                }
                if (Convert.ToString(i).Length == 2)
                {
                    minutes[i] = Convert.ToString(i);
                }
                cboMinute.Items.Add(Convert.ToString(minutes[i]));
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool hourOk = false;
            bool minuteOk = false;
            foreach (string s in hours)
            {
                if (cboHour.Text == s)
                    hourOk = true;
            }
            foreach (string s in minutes)
            {
                if (cboMinute.Text == s)
                    minuteOk = true;
            }

            if (hourOk && minuteOk)
            {
                if (rdoOnce.Checked)
                {
                    newAlarm = new alarm(cboHour.Text,
                        cboMinute.Text, new int[]{0,0,0,0,0,0,0,0});
                    newAlarm.once = true;
                    alarmCreated = true;
                    this.Close();
                }
                if (rdoRepeat.Checked)
                {
                    newAlarm = new alarm(cboHour.Text,
                        cboMinute.Text, createWeekArray());
                    newAlarm.once = false;
                    alarmCreated = true;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Time not correct");
            }
        }

        private int[] createWeekArray()
        {
            int[] repeat = { 0, 0, 0, 0, 0, 0, 0, 0 };

            if(cboM.Checked)
                repeat[1] = 1;

            if(cboTu.Checked)
                repeat[2] = 1;

            if(cboW.Checked)
                repeat[3] = 1;

            if(cboTh.Checked)
                repeat[4] = 1;

            if(cboF.Checked)
                repeat[5] = 1;

            if(cboSa.Checked)
                repeat[6] = 1;

            if(cboSu.Checked)
                repeat[7] = 1;

            return repeat;

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoOnce_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOnce.Checked)
            {
                foreach (Control s in this.Controls)
                {
                    if (s is CheckBox)
                        s.Enabled = false;
                }
            }
            if (!rdoOnce.Checked)
            {
                foreach (Control s in this.Controls)
                {
                    if (s is CheckBox)
                        s.Enabled = true;
                }
            }
        }
    }
}

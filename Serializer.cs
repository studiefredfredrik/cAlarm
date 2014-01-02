using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Drawing;

namespace cAlarm
{
    class Serializer
    {
        public string PROGRAMPATH = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public string ALARMSPATH = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\alarmlist.lrm";
        public string PLAYLISTPATH = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\playlist.m3u";
        public string COLORPATH= Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\custom.color";

        FileStream output;
        FileStream input;
        BinaryFormatter reader = new BinaryFormatter();
        BinaryFormatter formatter = new BinaryFormatter();

        // standard path
        public void savePlaylist(List<string> playlist)
        {
            try
            {
            if (File.Exists(PLAYLISTPATH))
                File.Delete(PLAYLISTPATH);
            File.WriteAllLines(PLAYLISTPATH, playlist, Encoding.ASCII);
            }
            catch (Exception)
            {
            }
        }
        public void savePlaylist(List<string> playlist, string filename)
        {
            try
            {
                if (File.Exists(filename))
                    File.Delete(filename);
                File.WriteAllLines(filename, playlist, Encoding.ASCII);
            }
            catch (Exception)
            {
            }
        }

        // standard path
        public void saveAlarms(List<alarm> alarms)
        {
            try
            {
                // override if exists
                if (File.Exists(ALARMSPATH))
                    File.Delete(ALARMSPATH);
                output = new FileStream(ALARMSPATH, FileMode.OpenOrCreate, FileAccess.Write);
                formatter.Serialize(output, alarms);
            }
            catch (Exception)
            {
            }
        }
        // custom path
        public bool saveAlarms_ifnotexist(List<alarm> alarms, string filename)
        {
            // dont allow overrides
            if (File.Exists(filename))
                return false;
            output = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
            formatter.Serialize(output, alarms);
            return true;
        }

        //overrides existing files
        public void saveAlarms_force(List<alarm> alarms, string filename)
        {
            // override
            if (File.Exists(filename))
                File.Delete(filename);
            output = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
            formatter.Serialize(output, alarms);
        }

        // default path
        public List<alarm> openAlarms()
        {
            if(File.Exists(ALARMSPATH))
            {
            input = new FileStream(ALARMSPATH, FileMode.Open, FileAccess.Read);
            List<alarm> alarmlist = (List<alarm>)reader.Deserialize(input);
            return alarmlist;
            }
            else
                return new List<alarm>();
        }
        public List<alarm> openAlarms(string filename)
        {
            input = new FileStream(filename, FileMode.Open, FileAccess.Read);
            List<alarm> alarmlist = (List<alarm>)reader.Deserialize(input);
            return alarmlist;
        }

        public List<string> openPlaylist()
        {
            List<string> list = new List<string>();
            if (File.Exists(PLAYLISTPATH))
            {
                string[] s = File.ReadAllLines(PLAYLISTPATH);
                foreach (string i in s)
                    list.Add(i);
            }
            return list;
        }
        public List<string> openPlaylist(string filename)
        {
            List<string> list = new List<string>();
            if (File.Exists(filename))
            {
                string[] s = File.ReadAllLines(filename);
                foreach (string i in s)
                    list.Add(i);
            }
            return list;
        }

        public void saveColor(Color aColor)
        {
            try
            {
                if (File.Exists(COLORPATH))
                    File.Delete(COLORPATH);
                output = new FileStream(COLORPATH, FileMode.OpenOrCreate, FileAccess.Write);
                formatter.Serialize(output, aColor);
            }
            catch (Exception)
            {
            }
        }
        public Color openColor()
        {
            try
            {
            if (File.Exists(COLORPATH))
            {
                input = new FileStream(COLORPATH, FileMode.Open, FileAccess.Read);
                Color custom = (Color)reader.Deserialize(input);
                return custom;
            }
            else
                return Color.SkyBlue;
            }
            catch (Exception)
            {
                return Color.SkyBlue;
            }
        }
    }
}

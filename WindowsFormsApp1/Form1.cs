using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace SecurityPanel
{
    public partial class SecurityPanel : Form
    {
        string pass = "1703";
        string path = @"D:\Login_Log.txt";
        public SecurityPanel()
        {
            InitializeComponent();
            if (!File.Exists(path)) // file chua ton tai -> tao moi
            {
                using(StreamWriter wr = File.CreateText(path))
                {
                    wr.WriteLine("");
                }
            }
            ShowAccessLog();
        }
        private void getNumber(object o, EventArgs e)
        {
            if (Screen.TextLength < 4)
                Screen.Text += ((Button)o).Text;
        }
        private void getpressNumber(object o, KeyPressEventArgs e)
        {
            if (Screen.TextLength < 4 && e.KeyChar >= '0' && e.KeyChar <= '9')
                Screen.Text += e.KeyChar.ToString();
        }
        private void buttonC_Click(object o, EventArgs e)
        {
            Screen.Text = "";
        }
        private void buttonOK_Click(object o, EventArgs e)
        {
            if (Screen.Text == pass)
            {
                using (StreamWriter wr = File.AppendText(path))
                {
                    DateTime time = DateTime.Now;
                    wr.WriteLine(time + "\tGranted");
                    wr.Dispose();
                }
            }
            else
            {
                using (StreamWriter wr = File.AppendText(path))
                {
                    DateTime time = DateTime.Now;
                    wr.WriteLine(time + "\tDenied");
                    wr.Dispose();
                }
            }
            ShowAccessLog();
            Screen.Text = "";
        }

        private void ShowAccessLog()
        {
            listBox1.Items.Clear();
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                listBox1.Items.Add(line);
            }
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        private void SecurityPanel_KeyDown(object sender, KeyEventArgs e)
        {
            string s = e.KeyCode.ToString();
            switch(s)
            {
                case "D0": button1.PerformClick(); break;
                case "D1": button1.PerformClick(); break;
                case "D2": button1.PerformClick(); break;
                case "D3": button1.PerformClick(); break;
                case "D4": button1.PerformClick(); break;
                case "D5": button1.PerformClick(); break;
                case "D6": button1.PerformClick(); break;
                case "D7": button1.PerformClick(); break;
                case "D8": button1.PerformClick(); break;
                case "D9": button1.PerformClick(); break;
                case "Back": buttonC.PerformClick(); break;
                case "Return": buttonOK.PerformClick(); break;
            }
        }
    }
}
                
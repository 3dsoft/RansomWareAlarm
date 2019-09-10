using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RWAlarm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 1) { MessageBox.Show("Select Drive !"); return; }

            string root = comboBox1.Text;

            if(!Directory.Exists(Path.Combine(root, "_a")))
            {
                Directory.CreateDirectory(Path.Combine(root, "_a"));
            }

            int count = 0;
            if( int.TryParse(textBox1.Text, out count))
            {
                for (int i = 1; i <= count; i++)
                {
                    string data = Guid.NewGuid().ToString();
                    File.WriteAllText(Path.Combine(root, "_a") + @"\File_" + i.ToString("00000") + ".txt", data);
                }

                MessageBox.Show(Path.Combine(root, "_a") + " : OK");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("SELECT");

            foreach (var item in DriveInfo.GetDrives())
            {
                comboBox1.Items.Add(item);
            }

            comboBox1.SelectedIndex = 0;
        }
    }
}

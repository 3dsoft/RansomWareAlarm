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
            if(!Directory.Exists(@"c:\_a"))
            {
                Directory.CreateDirectory(@"c:\_a");
            }

            int count = 0;
            if( int.TryParse(textBox1.Text, out count))
            {
                for (int i = 1; i <= count; i++)
                {
                    string data = Guid.NewGuid().ToString();
                    File.WriteAllText(@"C:\_a\File_" + i.ToString("00000") + ".txt", data);
                }

                MessageBox.Show("OK");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

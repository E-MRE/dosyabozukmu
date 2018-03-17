using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace Dosyam_Bozuk_Mu
{

    public partial class Form1 : Form
    {
        

       
        public Form1()
        {
            InitializeComponent();

        }
        int boy=0, en=0;
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("MD5");
            comboBox1.Items.Add("SHA1");
            comboBox1.Items.Add("SHA256");
            comboBox1.SelectedIndex=0;
            panel1.Size = new Size(0,0);
            panel1.Height = 281;
            timer1.Start();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=string.Empty)
            Process.Start("cmd.exe","/k"+"cd c:/ & cd Windows & cd System32 & certutil -hashfile"+" "+textBox1.Text+" "+comboBox1.SelectedItem.ToString()); 
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string dosyaYolu = openFileDialog1.FileName;
                textBox1.Text = Path.GetFullPath(dosyaYolu);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != string.Empty && textBox3.Text != string.Empty)
            {
                if (string.Compare(textBox2.Text, textBox3.Text) == 0)
                {
                    MessageBox.Show("Dosyanız Bozuk Değil Sorunsuz Şekilde Kullanabilirsiniz.!");
                }
                else { MessageBox.Show("Dosyanız Bozulmuş. Lütfen Tekrar Yükleyin"); }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Size = new Size(0,panel1.Height);
            en = 0;
            panel1.Visible = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (en >= 400) { en = 400; } else { en += 10; }
            panel1.Width = en;
            if(en>= 398 && boy>= 281) { timer1.Stop(); }            
        }
    }
}

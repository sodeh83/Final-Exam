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

namespace finalexam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
            }
            

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                groupBox2.Enabled = true;
                groupBox1.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Toyota");
            comboBox1.Items.Add("Hyoda");
            comboBox1.Items.Add("Honda");

            //combobox3
            comboBox3.Items.Add(2015);
            comboBox3.Items.Add(2016);
            comboBox3.Items.Add(2017);
            comboBox3.Items.Add(2018);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            if (comboBox1.SelectedIndex == 0)
            {
                comboBox2.Items.Add("Rav4");
                comboBox2.Items.Add("Camary");
                comboBox2.Items.Add("Corola");
            }
           
            if (comboBox1.SelectedIndex == 1)
            {
                comboBox2.Items.Add("as");
                comboBox2.Items.Add("ad");
                comboBox2.Items.Add("af");
            }
          
            if (comboBox1.SelectedIndex == 2)
            {
                comboBox2.Items.Add("ba");
                comboBox2.Items.Add("bs");
                comboBox2.Items.Add("bg");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.ResetText();
            comboBox2.ResetText();
            comboBox3.ResetText();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string family = textBox2.Text;
            string tel = textBox3.Text;
            if (name.Length == 0 || family.Length == 0 || tel.Length == 0 || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Please Fill all items");
            }
            else
            {
                SaveFileDialog dialog = new SaveFileDialog();
               // DialogResult result = dialog.ShowDialog();

               // dialog.InitialDirectory = "C:\\";      
                dialog.Title = "Save text Files";
                dialog.CheckFileExists = true;
                dialog.CheckPathExists = true;
                dialog.DefaultExt = "txt";
                dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                dialog.FilterIndex = 2;
                dialog.RestoreDirectory = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FileStream stream = new FileStream("C:\\Users\\1896358\\Desktop\\save.txt", FileMode.Append);
                    using(StreamWriter write = new StreamWriter(stream))
                    {
                        write.WriteLine(" Owner Info: " + textBox1.Text + textBox2.Text + textBox3.Text +
                                         "\n Car Info:" + comboBox1.SelectedItem.ToString() + comboBox2.SelectedItem.ToString() + comboBox3.SelectedItem.ToString());
                    }
                    MessageBox.Show("save was successful ");
                }
            }
          
        }
    }
}

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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BestOil___Again
{
    public partial class Form1 : Form
    {
        MainMenu MyMenu;
        MenuItem file_item, reset_item, exit_item, sub1_write;
        ContextMenuStrip m;
        public double OilSumm { get; set; }
        public double CafeSumm { get; set; }
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0.00";

            MyMenu = new MainMenu();

            file_item= new MenuItem("File");
            MyMenu.MenuItems.Add(file_item);
            sub1_write = new MenuItem("Запись в файл");
            sub1_write.Click += new EventHandler(WriteToFile);
            file_item.MenuItems.Add(sub1_write);

            reset_item = new MenuItem("Reset");
            reset_item.Click += new EventHandler(Reset);
            MyMenu.MenuItems.Add(reset_item);

            exit_item = new MenuItem("Exit");
            exit_item.Click += new EventHandler(Quit);
            MyMenu.MenuItems.Add(exit_item);

            m = new ContextMenuStrip();
            m.Items.Add("Записать в файл");
            m.Items.Add("Reset");
            m.Items.Add("Quit");

            m.Items[0].Click += new EventHandler(WriteToFile);
            m.Items[0].Padding = new Padding(7);
            m.Items[1].Click += new EventHandler(Reset);
            m.Items[2].Click += new EventHandler(Quit);

            ContextMenuStrip = m;
            Menu = MyMenu;
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                textBox1.Text = "6.40";
            else if (comboBox1.SelectedIndex == 1)
                textBox1.Text = "5.90";
            else if (comboBox1.SelectedIndex == 2)
                textBox1.Text = "7.20";
            else
                textBox1.Text = "5.00";
            numericUpDown1_ValueChanged(sender, e);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked) {
                numericUpDown2.Text = "0";
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = false;
            }
            else if (radioButton2.Checked)
            {
                numericUpDown1.Text = "0";
                numericUpDown2.Enabled = true;
                numericUpDown1.Enabled = false;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double result = Convert.ToDouble(textBox1.Text);
            if (numericUpDown1.Enabled)
                result *= Convert.ToInt32(numericUpDown1.Value);
            else
                result = Convert.ToInt32(numericUpDown2.Value);
            OilSumm = result;

           label6.Text = result.ToString();
           SetSumm();

        }

        private void SetSumm()
        {
            label12.Text = Convert.ToString(OilSumm + CafeSumm);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) numericUpDown3.Enabled = true;
            else
            {
                numericUpDown3.Text = "0";
                numericUpDown3.Enabled = false;
            }

            if (checkBox2.Checked) numericUpDown4.Enabled = true;
            else
            {
                numericUpDown4.Text = "0";
                numericUpDown4.Enabled = false;
            }

            if (checkBox3.Checked) numericUpDown5.Enabled = true;
            else
            {
                numericUpDown5.Text = "0";
                numericUpDown5.Enabled = false;
            }

            if (checkBox4.Checked) numericUpDown6.Enabled = true;
            else
            {
                numericUpDown6.Text = "0";
                numericUpDown6.Enabled = false;
            }
            numericUpDown3_ValueChanged(sender, e);

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
           
            double result = Convert.ToDouble(textBox4.Text) * Convert.ToDouble(numericUpDown3.Value);
            result += Convert.ToDouble(textBox5.Text) * Convert.ToDouble(numericUpDown4.Value);
            result += Convert.ToDouble(textBox6.Text) * Convert.ToDouble(numericUpDown5.Value);
            result += Convert.ToDouble(textBox7.Text) * Convert.ToDouble(numericUpDown6.Value);
            label11.Text = Convert.ToString(result);

            CafeSumm = result;
            SetSumm();
        }

        private void Quit(object sender, EventArgs e)
        {
            Close();
        }
        private void Reset(object sender, EventArgs e)
        {
            checkBox1.Checked= false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            radioButton1.Checked = false; 
            radioButton2.Checked = false;
            numericUpDown1.Text = "0";
            numericUpDown2.Text = "0";
        }
        private void WriteToFile(object sender, EventArgs e)
        {
            string str = DateTime.Now.ToString() + ". Всего - " + label12.Text + " грн.";
            if(comboBox1.SelectedIndex != -1 && (numericUpDown1.Value > 0 || numericUpDown2.Value > 0))
                str += "\n" + comboBox1.Text + " - " + label6.Text + " грн.";
            if (numericUpDown3.Value > 0)
                str += "\nХот-дог - " + numericUpDown3.Value + " шт. - " + (Convert.ToDouble(textBox4.Text) * Convert.ToInt32(numericUpDown3.Value)) + " грн.";
            if (numericUpDown4.Value > 0)
                str += "\nГамбургер - " + numericUpDown4.Value + "шт. - " + (Convert.ToDouble(textBox5.Text) * Convert.ToInt32(numericUpDown4.Value)) + " грн.";
            if (numericUpDown5.Value > 0)
                str += "\nКартошка-фри - " + numericUpDown5.Value + "шт. - " + (Convert.ToDouble(textBox6.Text) * Convert.ToInt32(numericUpDown5.Value)) + " грн.";
            if (numericUpDown6.Value > 0)
                str += "\nКола - " + numericUpDown6.Value + "шт. - " + (Convert.ToDouble(textBox7.Text) * Convert.ToInt32(numericUpDown6.Value)) + " грн.";

            StreamWriter writer = new StreamWriter("transactions.txt", true);
            writer.Write(str+"\n\n");
            writer.Close();

        }
    }
}

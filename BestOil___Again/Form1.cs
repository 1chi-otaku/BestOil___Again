using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BestOil___Again
{
    public partial class Form1 : Form
    {
        public double OilSumm { get; set; }
        public double CafeSumm { get; set; }
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0.00";
          
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
    }
}

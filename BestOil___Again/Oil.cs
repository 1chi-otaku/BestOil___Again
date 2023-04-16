using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestOil___Again
{
    public partial class Oil : Form
    {
        public double OilSumm { get; set; }
        public Form1 mainMenu { get; set; }
        public Oil()
        {
            InitializeComponent();
            OilSumm = 0;
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
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double result = Convert.ToDouble(textBox1.Text);
            if (numericUpDown1.Enabled)
                result *= Convert.ToInt32(numericUpDown1.Value);
            else
                result = Convert.ToInt32(numericUpDown2.Value);

            label6.Text = result.ToString();
            OilSumm = result;
            SetSumm();

        }
        private void SetSumm()
        {
            label6.Text = Convert.ToString(OilSumm);
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
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
    }
}

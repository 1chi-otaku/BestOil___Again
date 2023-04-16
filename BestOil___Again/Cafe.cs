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
    public partial class Cafe : Form
    {
        public double CafeSumm { get; set; }
        public Form1 mainMenu { get; set; }
        public Cafe()
        {
            InitializeComponent();
            CafeSumm = 0;
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
        private void SetSumm()
        {
            label11.Text = Convert.ToString(CafeSumm);
        }
    }
}

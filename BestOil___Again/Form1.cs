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
        public double OilSumm { get; set; }
        public double CafeSumm { get; set; }

        Oil oil_form;
        Cafe cafe_form;

        public Form1()
        {
            InitializeComponent();
            oil_form = new Oil();
            cafe_form= new Cafe(); 
        }


        private void button1_Click(object sender, EventArgs e)
        {
            oil_form = new Oil();
            oil_form.mainMenu = this;
            DialogResult res = oil_form.ShowDialog();
            if (res == DialogResult.OK)
            {
                OilSumm = oil_form.OilSumm;
                SummChanged();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            cafe_form = new Cafe();
            cafe_form.mainMenu = this;
            DialogResult res = cafe_form.ShowDialog();
            if (res == DialogResult.OK)
            {
                CafeSumm = cafe_form.CafeSumm;
                SummChanged();
            }
        }
        public void SummChanged()
        {
            label12.Text = (OilSumm + CafeSumm).ToString();
        }

        private void Quit(object sender, EventArgs e)
        {
            Close();
        }

       

       
    }
}

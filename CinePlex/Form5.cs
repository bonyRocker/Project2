using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinePlex
{
    public partial class Form5 : Form
    {
        int i = 0;
        public Form5()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                 i = 1;
                 this.Hide();
            }

            if (i == 1)
            {
                Form3 f3 = new Form3();
                f3.ShowDialog();
            }
        }
    }
}

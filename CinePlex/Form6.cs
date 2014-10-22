using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CinePlex
{
    public partial class Form6 : Form
        
    {
        string[] p= new string[5];
        string connection = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True";

        public Form6()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            
           // label1.Text = DateTime.Now.ToString("hh:mm:ss tt");
            label1.Text = dt.ToString();
          
            // if()

         //   SqlConnection con = new SqlConnection(connection);
           // con.Open();
            //DateTime time1 = DateTime.
           /* TimeSpan ts1 = new TimeSpan(9, 00, 00);
            TimeSpan ts2 = new TimeSpan(11, 59, 00);
            TimeSpan ts3 = new TimeSpan(12, 00, 00);
            TimeSpan ts4 = new TimeSpan(14, 59, 00);
            TimeSpan ts5 = new TimeSpan(15, 00, 00);
            TimeSpan ts6 = new TimeSpan(17, 59, 00);
            TimeSpan ts7 = new TimeSpan(21, 00, 00);
            TimeSpan ts8 = new TimeSpan(23, 59, 00);
           // int i = ts1.CompareTo(dt);
           // int j = ts1.CompareTo(DateTime.Now);
            double i = ts7.Hours - dt.Hour;
            double j = ts8.Hours - dt.Hour;
            if (i > -3 && j < 3)
            {
                int l=2;
                string s = string.Format("Select * from time4 where date='{0}'",dt.Date);
                SqlDataAdapter da= new SqlDataAdapter(s,con);
                DataTable t1= new DataTable();
                da.Fill(t1);
                foreach(DataRow row in t1.Rows)
                {
                    //p[l] = row[];
                }
                
            }
         //   string s = i.ToString();
          //  MessageBox.Show(s);*/
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            DateTime nowdate= DateTime.Now.Date;
            
            string compare1 = "SELECT Stat date from Movie";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(compare1, con);
            DataTable t = new DataTable();
            da.Fill(t);
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

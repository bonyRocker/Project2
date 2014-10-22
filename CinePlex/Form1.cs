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
    public partial class Form1 : Form
    {

        string connection="Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True";
        string user, pass;
        public Form1()
        {
            InitializeComponent();
            
        }

       
        private void timer1_Tick(object sender, EventArgs e)
        {
            
        } 

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void signupbutton_Click(object sender, EventArgs e)
        {
           

            string dob;
         /*   if (DateTime.IsLeapYear(Convert.ToInt32(yearCombo.Text)) && monthCombo.Text == "February")
            {
                
            }*/
            

            dob = dateCombo.Text + "-" + monthCombo.Text + "-" + yearCombo.Text;


            if (password.Text != confirm.Text)
            {
                MessageBox.Show("Password Mismatch");
                return;
            }
            else if (userName.Text == string.Empty || emailfield.Text == string.Empty || ((checkBox1.Checked == true && checkBox2.Checked == true) || (checkBox1.Checked == false && checkBox2.Checked == false)))
            {
                MessageBox.Show("Invalid Input");
                return;
            }

            string gnd="";
            if(checkBox1.Checked==true)
                gnd="Male";
            else
                gnd="Female";

            SqlConnection con = new SqlConnection(connection);

            con.Open();

            string inscmd = string.Format("Insert into [Employee] ([Username], [Password], [Email], [Dob], [Gender]) values ('{0}','{1}','{2}','{3}', '{4}')", userName.Text, password.Text, emailfield.Text, dob, gnd);
            
            SqlCommand cmd = new SqlCommand(inscmd, con);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Registration is successful","Messege",MessageBoxButtons.OK,MessageBoxIcon.Information);
           


            con.Close();





            



            
            

           











        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(connection);
            con.Open();
           // string u = string.Format("SELECT [Username] from Employee where [Username]='{0}'",textBox1.Text);
            //string p = string.Format("SELECT [Password] from Employee where [Password]='{0}'", textBox2.Text);
            string str = string.Format("select * from Employee where Username='{0}' and Password='{1}' ", textBox1.Text, textBox2.Text);
            SqlCommand cmd= new SqlCommand(str,con);
            SqlDataReader dr = cmd.ExecuteReader();
         //   string u2 = dr["Username"].ToString();
           // SqlCommand cmd2 = new SqlCommand(p,con);
          //  SqlDataReader dr2 = cmd2.ExecuteReader();
           // string p2 = dr2["Password"].ToString();
            while (dr.Read())
            {
                if (dr["Username"].ToString() == textBox1.Text && dr["Password"].ToString()==textBox2.Text)
                {
                    MessageBox.Show("Successfully Logged in", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    // Form3 f3=new Form3();
                    Form5 f5 = new Form5();
                    f5.ShowDialog();

                    Close();
                    //  f3.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }

            
            
        }

        private void dateCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
          //  DateTime.IsLeapYear();
        }
    }
}

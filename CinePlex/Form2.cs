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
    public partial class Form2 : Form
    {
        string connection = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True";
        
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            
          
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();

           // string date1 = DateTime.Now.Date.ToString("dd-MMM-yy");
         //   string date2 = DateTime.Now.Date.ToString("dd-MMM-yy");
          //  string date1 = maskedTextBox1.Text;
           // string date2 = maskedTextBox2.Text;
            string strcmd=string.Format("Insert into Movie ([Movie id],[movie title],[movie type],[Start date],[End date]) values('{0}','{1}','{2}','{3}','{4}')", textBox2.Text, textBox1.Text, textBox3.Text, dateTimePicker1.Value,dateTimePicker2.Value);


            SqlCommand cmd = new SqlCommand(strcmd, con);
            cmd.ExecuteNonQuery();
          /*  SqlDataAdapter s = new SqlDataAdapter("Select * from Movie",con);
            DataTable t1 = new DataTable();
            s.Fill(t1);*/
         //   dataGridView1.DataSource = t1;
           // con.Close();

           // string box = "";
            
            TimeSpan ts =dateTimePicker2.Value-dateTimePicker1.Value;
            int day = ts.Days;
          //  MessageBox.Show(day.ToString());
            for (int k = 0; k <= day; k++)
            {
               
                if (checkBox1.Checked == true)
                {
                    if (checkBox5.Checked == true || checkBox6.Checked == true || checkBox7.Checked == true || checkBox8.Checked == true)
                    {
                        SqlCommand cmd1 = new SqlCommand(String.Format("Insert into time1 ([date]) values('{0}')", dateTimePicker1.Value.AddDays(Convert.ToDouble(k))), con);
                        cmd1.ExecuteNonQuery();
                        
                        //checkBox1.Checked = false;
                    }
                    else
                        MessageBox.Show("Enter a Theater No.");
                    if (checkBox5.Checked == true)
                    {
                        
                            //   dateTimePicker1.Value = new DateTime(DateTimePicker1.Value.Year, DateTimePicker1.Value.Month + 1, DateTimePicker1.Value.Day);
                            SqlCommand cmd1 = new SqlCommand(String.Format("Update  time1 set [th_1]= '{0}'", textBox1.Text), con);
                            cmd1.ExecuteNonQuery();
                            /*SqlDataAdapter da = new SqlDataAdapter("select * from time1", con);
                            DataTable t2 = new DataTable();
                            da.Fill(t2);
                            dataGridView2.DataSource = t2;*/
                        
                    }
                    if (checkBox6.Checked == true)
                    {

                        SqlCommand cmd1 = new SqlCommand(String.Format("Update  time1 set [th_2]= '{0}'", textBox1.Text), con);
                            cmd1.ExecuteNonQuery();
                            /* SqlDataAdapter da = new SqlDataAdapter("select * from time1", con);
                             DataTable t2 = new DataTable();
                             da.Fill(t2);
                             dataGridView2.DataSource = t2;*/
                        
                    }
                    if (checkBox7.Checked == true)
                    {

                        SqlCommand cmd1 = new SqlCommand(String.Format("Update  time1 set [th_3]= '{0}'", textBox1.Text), con);
                            cmd1.ExecuteNonQuery();
                        
                    }
                    if (checkBox8.Checked == true)
                    {

                        SqlCommand cmd1 = new SqlCommand(String.Format("Update  time1 set [th_4]= '{0}'", textBox1.Text), con);
                        cmd1.ExecuteNonQuery();
                        
                    }
                }
                if (checkBox2.Checked == true)
                {
                    if (checkBox5.Checked == true || checkBox6.Checked == true || checkBox7.Checked == true || checkBox8.Checked == true)
                    {
                        SqlCommand cmd1 = new SqlCommand(String.Format("Insert into time2 ([date]) values('{0}')", dateTimePicker1.Value.AddDays(Convert.ToDouble(k))), con);
                        cmd1.ExecuteNonQuery();
                    }
                    if (checkBox5.Checked == true)
                    {
                        SqlCommand cmd1 = new SqlCommand(String.Format("Update  time2 set [th_1]= '{0}'", textBox1.Text), con);
                            cmd1.ExecuteNonQuery();
                            /*  SqlDataAdapter da = new SqlDataAdapter("select * from time2", con);
                              DataTable t2 = new DataTable();
                              da.Fill(t2);
                              dataGridView2.DataSource = t2;*/
                        
                    }
                    if (checkBox6.Checked == true)
                    {
                        SqlCommand cmd1 = new SqlCommand(String.Format("Update  time2 set [th_2]= '{0}'", textBox1.Text), con);
                        cmd1.ExecuteNonQuery();
                    }
                    if (checkBox7.Checked == true)
                    {
                        SqlCommand cmd1 = new SqlCommand(String.Format("Update  time2 set [th_3]= '{0}'", textBox1.Text), con);
                        cmd1.ExecuteNonQuery();
                    }
                    if (checkBox8.Checked == true)
                    {
                        SqlCommand cmd1 = new SqlCommand(String.Format("Update  time2 set [th_4]= '{0}'", textBox1.Text), con);
                        cmd1.ExecuteNonQuery();
                    }
                }
                if (checkBox3.Checked == true)
                {
                    if (checkBox5.Checked == true || checkBox6.Checked == true || checkBox7.Checked == true || checkBox8.Checked == true)
                    {
                        SqlCommand cmd1 = new SqlCommand(String.Format("Insert into time3 ([date]) values('{0}')", dateTimePicker1.Value.AddDays(Convert.ToDouble(k))), con);
                        cmd1.ExecuteNonQuery();
                    }
                    if (checkBox5.Checked == true)
                    {

                        SqlCommand cmd1 = new SqlCommand(String.Format("Update  time3 set [th_1]= '{0}'", textBox1.Text), con);
                            cmd1.ExecuteNonQuery();
                        
                    }
                    if (checkBox6.Checked == true)
                    {
                        SqlCommand cmd1 = new SqlCommand(String.Format("Update  time3 set [th_2]= '{0}'", textBox1.Text), con);
                        cmd1.ExecuteNonQuery();
                    }
                    if (checkBox7.Checked == true)
                    {
                        SqlCommand cmd1 = new SqlCommand(String.Format("Update  time3 set [th_3]= '{0}'", textBox1.Text), con);
                        cmd1.ExecuteNonQuery();
                    }
                    if (checkBox8.Checked == true)
                    {
                        SqlCommand cmd1 = new SqlCommand(String.Format("Update  time3 set [th_4]= '{0}'", textBox1.Text), con);
                        cmd1.ExecuteNonQuery();
                    }
                }
                if (checkBox4.Checked == true)
                {
                    if (checkBox5.Checked == true || checkBox6.Checked == true || checkBox7.Checked == true || checkBox8.Checked == true)
                    {
                        SqlCommand cmd1 = new SqlCommand(String.Format("Insert into time4 ([date]) values('{0}')", dateTimePicker1.Value.AddDays(Convert.ToDouble(k))), con);
                        cmd1.ExecuteNonQuery();
                    }
                    if (checkBox5.Checked == true)
                    {
                        SqlCommand cmd1 = new SqlCommand(String.Format("Update  time4 set [th_1]= '{0}'", textBox1.Text), con);
                        cmd1.ExecuteNonQuery();
                    }
                    if (checkBox6.Checked == true)
                    {
                        SqlCommand cmd1 = new SqlCommand(String.Format("Update  time4 set [th_2]= '{0}'", textBox1.Text), con);
                        cmd1.ExecuteNonQuery();
                    }
                    if (checkBox7.Checked == true)
                    {
                        SqlCommand cmd1 = new SqlCommand(String.Format("Update  time4 set [th_3]= '{0}'", textBox1.Text), con);
                        cmd1.ExecuteNonQuery();
                    }
                    if (checkBox8.Checked == true)
                    {
                        SqlCommand cmd1 = new SqlCommand(String.Format("Update  time4 set [th_4]= '{0}'", textBox1.Text), con);
                        cmd1.ExecuteNonQuery();
                    }
                }

                
                

            }
             
            /*string box2="";
            if(checkBox5.Checked==true)
            {
                box2=checkBox5.Text;
            }
            else if(checkBox6.Checked==true)
            {box2=checkBox6.Text;
            }
            else if(checkBox7.Checked==true)
            {box2=checkBox7.Text;
            }
            else 
                box2=checkBox8.Text;*/




          //  strcmd = string.Format("insert into MTrelation ([movie id], [showtime], [Theater no], [Ticket Type]) values ('{0}','{1}','{2}','{3}')", textBox2.Text, box, box2, comboBox1.Text);

           // SqlCommand com2 = new SqlCommand(strcmd, con);

          //  com2.ExecuteNonQuery();
            string priceUpdate = string.Format("Insert into Price ([Movie Name],[Normal],[Premium]) values('{0}','{1}','{2}') ", textBox1.Text, Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text));
            SqlCommand cmd4 = new SqlCommand(priceUpdate, con);
            cmd4.ExecuteNonQuery();
            SqlDataAdapter da2 = new SqlDataAdapter("Select [Movie id],[Movie title], [Movie type],[start date],[End date],[Normal],[Premium] from [Movie] Inner join [price] On Movie.[Movie title]=price.[Movie Name]", con);
            DataTable t3 = new DataTable();
            da2.Fill(t3);
            dataGridView1.DataSource = t3;
            }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.ShowDialog();
            
        }
    }
}

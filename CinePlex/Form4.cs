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
    public partial class Form4 : Form
    {
        string th1 = "";
        string th2 = "";
        int flag = 0;
        int temp = 0;
        int sell1=0;
        int sell2=0;
        string st1 = "";
        string st2 = "";
        bool bul = false;
        string[] tkt= new string[40];
        string[] sit = new string[40];
        int capacity = 40;
        string normal = "";
        string premium = "";
        int TotalCost;
        int newdate=0;
        string connection = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True";
       
        public Form4()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();

            
            SqlDataAdapter da=new SqlDataAdapter(string.Format("Select * from Movie where [movie title]='{0}'", nameField.Text), con);
            DataTable t = new DataTable();
            da.Fill(t);
            dataGridView1.DataSource = t;
            //con.Close();

        
        
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
           /* 9.00-11.59AM
12.00-2.59PM
3.00-5.59PM
6.00-8.59PM*/
            if (comboBox2.Text != "")
            {
                if (comboBox2.Text == "9.00-11.59AM")
                {
                    SqlDataAdapter da = new SqlDataAdapter(string.Format("Select * from time1 where [date]='{0}'", dateTimePicker1.Value), con);
                    DataTable t = new DataTable();
                    da.Fill(t);
                    dataGridView1.DataSource = t;
                   // con.Close();
                }
                else if (comboBox2.Text == "12.00-2.59PM")
                {
                    SqlDataAdapter da = new SqlDataAdapter(string.Format("Select * from time2 where [date]='{0}'", dateTimePicker1.Value), con);
                    DataTable t = new DataTable();
                    da.Fill(t);
                    dataGridView1.DataSource = t;
                 //   con.Close();
                }
                else if (comboBox2.Text == "3.00-5.59PM")
                {
                    SqlDataAdapter da = new SqlDataAdapter(string.Format("Select * from time3 where [date]='{0}'", dateTimePicker1.Value), con);
                    DataTable t = new DataTable();
                    da.Fill(t);
                    dataGridView1.DataSource = t;
                   // con.Close();
                }
                else if (comboBox2.Text == "6.00-8.59PMAM")
                {
                    SqlDataAdapter da = new SqlDataAdapter(string.Format("Select * from time4 where [date]='{0}'", dateTimePicker1.Value), con);
                    DataTable t = new DataTable();
                    da.Fill(t);
                    dataGridView1.DataSource = t;
                 //   con.Close();
                }
            }
            else
                MessageBox.Show("Enter a Time","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*Normal
             Premium*/
            SqlConnection con = new SqlConnection(connection);
            con.Open();

            if (comboBox3.Text == ""||comboBox1.Text=="")
            {
                MessageBox.Show("Invalid Theater No. or Ticket Type");
                return;
            }

            if (comboBox1.Text == "Normal")
            {

                if (comboBox3.Text=="1")
                {
                    th1 = "Th11";
                    st1 = "st11";
                }
                else if (comboBox3.Text == "2")
                {
                    th1 = "Th21";
                    st1 = "st21";
                }
                else if (comboBox3.Text == "3")
                {
                    th1 = "Th31";
                    st1 = "st31";
                }
                else if (comboBox3.Text == "4")
                {
                    th1 = "Th41";
                    st1 = "st41";
                }
                  
                
                    
                flag = 1;
              //  dataGridView1.Columns[1].HeaderText = th1;
                SqlDataAdapter da = new SqlDataAdapter(string.Format("Select [Date],"+th1+","+st1+" from serial where [date]='{0}'",dateTimePicker1.Value), con);
                DataTable t = new DataTable();
                da.Fill(t);
                dataGridView1.DataSource = t;
              //  con.Close();
            }
            else if (comboBox1.Text == "Premium")
            {
                if (comboBox3.Text == "1")
                {
                    th2 = "Th12";
                    st2 = "st12";
                }
                else if (comboBox3.Text == "2")
                {
                    th2 = "Th22";
                    st2 = "st22";
                }
                else if (comboBox3.Text == "3")
                {
                    th2 = "Th32";
                    st2 = "st32";
                }
                else if (comboBox3.Text == "4")
                {
                    th2 = "Th42";
                    st2 = "st42";
                }
                flag = 2;
                SqlDataAdapter da = new SqlDataAdapter(string.Format("Select [Date]," + th2 + "," + st2 + " from serial where [date]='{0}'", dateTimePicker1.Value), con);
                DataTable t = new DataTable();
                da.Fill(t);
                dataGridView1.DataSource = t;
         //       con.Close();
            }
            bul = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            int quantity = Convert.ToInt32(textBox3.Text);
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (flag == 1)
            {
                
                SqlDataAdapter da = new SqlDataAdapter(string.Format("Select " +th1+" from Theater1 where [date]='{0}'", dateTimePicker1.Value), con);
                DataTable t = new DataTable();
                da.Fill(t);
                foreach (DataRow row in t.Rows)
                {
                    temp = Convert.ToInt32(row[th1]);
                    
                }
                int temp2 = Convert.ToInt32(textBox3.Text);
                sell1 += temp2;
                if (sell1 > 1)
                {
                    MessageBox.Show("No seat is available for this category");
                    return;
                  //  String h = string.Format("Update serial");

                }
                int cost = Convert.ToInt32(textBox5.Text);
                MessageBox.Show("Thank you for buying ticket. Your Ticket Number is " + textBox1.Text + " your seat number is " + textBox2.Text + " and your Bill is " + textBox5.Text + ".");
                // TotalCost += cost;
                int final = temp - temp2;

                
                string update = string.Format("Update Theater1 set "+th1+"='{0}' where [date]='{1}'",final, dateTimePicker1.Value);
                string sell = string.Format("Update sell set [Normal]='{0}' where date='{1}'",sell1,DateTime.Now);
                SqlCommand cmd1 = new SqlCommand(sell, con);
                SqlCommand cmd = new SqlCommand(update, con);
                cmd1.ExecuteNonQuery();
               // string update = string.Format("Update Theater1 set " + th2 + "='{0}' where [date]='{1}'", final, dateTimePicker1.Value);
               // SqlCommand cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
                /*SqlDataAdapter da1 = new SqlDataAdapter(string.Format("Select * from sell where [date]='{0}'", DateTime.Now), con);
                DataTable t1 = new DataTable();
                da1.Fill(t);
                dataGridView1.DataSource = t1;*/
                SqlDataAdapter da2 = new SqlDataAdapter("Select * From Theater1", con);
                DataTable t1 = new DataTable();
                da2.Fill(t1);
                dataGridView1.DataSource = t1;
                
                
                

            }

            else if (flag == 2)
            {
                SqlDataAdapter da = new SqlDataAdapter(string.Format("Select " +th2+" from Theater1 where [date]='{0}'", dateTimePicker1.Value),con);
                DataTable t = new DataTable();
                da.Fill(t);
                foreach (DataRow row in t.Rows)
                {
                    temp = Convert.ToInt32(row[th2]);
                }
                int temp2 = Convert.ToInt32(textBox3.Text);
                sell2 += temp2;
                if (sell2 > 1)
                {
                    MessageBox.Show("No seat is available for this category");
                    return;

                }
                int cost= Convert.ToInt32(textBox5.Text);
                MessageBox.Show("Thank you for buying ticket. Your Ticket Number is " + textBox1.Text + " your seat number is " + textBox2.Text + " and your Bill is " + textBox5.Text + ".");
               // TotalCost += cost;
                int final = temp - temp2;

                string update = string.Format("Update Theater1 set "+th2+"='{0}' where [date]='{1}'",final, dateTimePicker1.Value);
                SqlCommand cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
                string sell = string.Format("Update sell set [Normal]='{0}' where date='{1}'", sell1, DateTime.Now);
                SqlCommand cmd1 = new SqlCommand(sell, con);
                cmd1.ExecuteNonQuery();

                SqlDataAdapter da2 = new SqlDataAdapter("Select * From Theater1",con);
                DataTable t1 = new DataTable();
                da2.Fill(t1);
                dataGridView1.DataSource=t1;

              //  con.Close();

            }



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = 1;
            if (bul)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    if(i==40)
                        return;
                    if (flag == 1)
                    {
                        tkt[i] = row.Cells[1].Value.ToString();
                        sit[i]= row.Cells[2].Value.ToString();
                        textBox1.Text = tkt[i];
                        textBox2.Text=sit[i];

                        SqlConnection con = new SqlConnection(connection);
                        con.Open();
                        string normalcmd=string.Format("Select [Normal] from price where [Movie Name]='{0}'", nameField.Text);
                        SqlDataAdapter da = new SqlDataAdapter(normalcmd, con);
                        DataTable t = new DataTable();
                        da.Fill(t);
                        foreach (DataRow rows in t.Rows)
                        {
                            normal = rows["Normal"].ToString();
                        }
                        //textBox5.Text=
                        
                        textBox5.Text=normal;
                        i++;
                        
                    }
                    if (flag == 2)
                    {
                        tkt[i] = row.Cells[1].Value.ToString();
                        sit[i]= row.Cells[2].Value.ToString();
                        textBox1.Text = tkt[i];
                        textBox2.Text=sit[i];
                        SqlConnection con = new SqlConnection(connection);
                        con.Open();
                        string premiumcmd = string.Format("Select [Premium] from price where [Movie Name]='{0}'", nameField.Text);
                        SqlDataAdapter da = new SqlDataAdapter(premiumcmd, con);
                        DataTable t = new DataTable();
                        da.Fill(t);
                        foreach (DataRow rows in t.Rows)
                        {
                            premium = rows["Premium"].ToString();
                        }
                        //textBox5.Text=

                        textBox5.Text = premium;
                        i++;
                        
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            comboBox2.Text = "";
            comboBox1.Text = "";
            comboBox3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox5.Text = "";
            nameField.Text = "";
            dataGridView1.DataSource = "";

        }
    }
}

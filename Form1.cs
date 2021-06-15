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
namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Server=DESKTOP-62UOLEV\DOAAELADL;DataBase=guest;Integrated Security=true;");
        SqlCommand cmd;
        DataTable dt = new DataTable();
        SqlDataReader dr;
        SqlDataAdapter adap,ap;
        DataSet ds;
        SqlCommandBuilder cmd1;
        DataTable ss = new DataTable();

        public Form1()
        {
            InitializeComponent();
            try
            {
                con.Open();
                adap = new SqlDataAdapter("select * from guest", con);
                ds = new System.Data.DataSet();
                adap.Fill(ds, "guest");
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Exit
            DialogResult dg = MessageBox.Show("do you want rellay exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void button6_Click(object sender, EventArgs e)
        {//employee shift
          Form f4 = new Form4();
            f4.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {//add

           /* string firtname = textBox2.Text;
            string familyname = textBox3.Text;
           // int telefonno =int.Parse(textBox4.Text);
            string address = textBox5.Text;
            string from = textBox8.Text;
          //  int nationalid = int.Parse(textBox6.Text);
            string Email = textBox7.Text;*/
            
           try
            {
                if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == ""||textBox7.Text==""||textBox8.Text=="")
                {
                    MessageBox.Show("fill the form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
// cmd = new SqlCommand("insert into guest ([first name],[date of reserve])VALUES('"+firtname+"',#"+dateTimePicker1.Value+"#)", con);
         //       con.Open();
                    
                    /*ss.Columns.Add("first name");
                    ss.Columns.Add("family name");
                    ss.Columns.Add("telefon no");
                    ss.Columns.Add("address");
                    ss.Columns.Add("from");
                    ss.Columns.Add("needed");
                    ss.Columns.Add("national id");
                    ss.Columns.Add("Email");
                    ss.Columns.Add("date of reserve");*/

                    DataRow row = ds.Tables["guest"].NewRow();
                    row["first name"] = textBox2.Text;
                    row["family name"] = textBox3.Text;
                    row["telefon no"] = textBox4.Text;
                    row["address"] = textBox5.Text;
                    row["from"] = textBox8.Text;
                    row["needed"] = comboBox1.SelectedItem;
                    row["national id"] = textBox6.Text;
                    row["Email"] = textBox7.Text;
                    row["date of reserve"] = dateTimePicker1.Value;

                    ds.Tables["guest"].Rows.Add(row);
                    //  ss.Rows.Add(row);
                    /*foreach(DataRow drow in ss.Rows)
                    {
                        int num = dataGridView1.Rows.Add();
                        dataGridView1.Rows[num].Cells[0].Value = drow["first name"].ToString();
                        dataGridView1.Rows[num].Cells[1].Value = drow["family name"].ToString();
                        dataGridView1.Rows[num].Cells[2].Value = drow["telefon no"].ToString();
                        dataGridView1.Rows[num].Cells[3].Value = drow["address"].ToString();
                        dataGridView1.Rows[num].Cells[4].Value = drow["from"].ToString();
                        dataGridView1.Rows[num].Cells[5].Value = drow["needed"].ToString();
                        dataGridView1.Rows[num].Cells[6].Value = drow["national id"].ToString();
                        dataGridView1.Rows[num].Cells[7].Value = drow["Email"].ToString();
                        dataGridView1.Rows[num].Cells[8].Value = drow["date of reserve"].ToString();

                    }  */
                    //      cmd.ExecuteNonQuery();
                    cmd1 = new SqlCommandBuilder(adap);
                    adap.Update(ds, "guest");
                    MessageBox.Show("done!","resevation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // dataGridView1.DataSource = ds;

             }
            }
            catch (SqlException ex)
            {
              MessageBox.Show(ex.Message);
            }
             finally
              {
             con.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {//clear
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox1.SelectedItem = null;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            if (radioButton3.Checked ==true )
            {
                //ap = new SqlDataAdapter("select * from guest where Email like '%" + textBox1.Text + "%'", con);
                //cmd1 = new SqlCommandBuilder(ap);
                //ap.Update(ds, "guest");
                //dataGridView1.DataSource = ds;
                dt.Clear();
                cmd = new SqlCommand("select * from guest where Email like '%"+textBox1.Text+"%'", con);
                con.Open();
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            else if (radioButton4.Checked == true)
            {
                dt.Clear();
                cmd = new SqlCommand("select * from guest where [national id] like '%" + textBox1.Text + "%'", con);
                con.Open();
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            else if (radioButton5.Checked== true)
            {
                dt.Clear();
                cmd = new SqlCommand("select * from guest where [telefon no] like '%" + textBox1.Text + "%'", con);
                con.Open();
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            else if (radioButton6.Checked == true)
            {
                dt.Clear();
                cmd = new SqlCommand("select * from guest where [family name] like '%" + textBox1.Text + "%'", con);
                con.Open();
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            else
            {
                MessageBox.Show("try againe");
                textBox1.Clear();
            }
        }
        private void button6_Click_1(object sender, EventArgs e)
        {
            //update 
            try
            {
                
                cmd1 = new SqlCommandBuilder(adap);
                adap.Update(ds, "guest");
                dataGridView1.DataSource = ds.Tables[0];
                MessageBox.Show("Successfully update !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            /* cmd1 = new SqlCommandBuilder(adap);
             adap.Update(ds, "guest");
             dataGridView1.DataSource = ds; 

               SqlCommand cmd2 = new SqlCommand("update guest set [first name] ='"+textBox2.Text+"',[family name]='"+textBox3.Text+"',[telefon no]="+textBox4.Text+",adress='"+textBox5.Text+"',needed='"+comboBox1.SelectedItem+"',[national id]="+textBox6.Text+",[date of reservation]="+dateTimePicker1.Value+",Email='"+textBox7.Text+"',[from]='"+textBox8.Text+"'", con);
               cmd2.ExecuteNonQuery();*/
        }
    }
}

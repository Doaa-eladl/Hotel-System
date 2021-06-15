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
    public partial class Form4 : Form
    {
        SqlConnection con = new SqlConnection(@"Server=DESKTOP-62UOLEV\DOAAELADL;DataBase=employee;Integrated Security=true;");
        SqlDataAdapter adap;
        DataSet ds = new DataSet();
        SqlCommandBuilder cmd1;
        SqlDataReader da;

        public Form4()
        {
            InitializeComponent();
            try
            {
                con.Open();
                adap = new SqlDataAdapter("select * from employee", con);
                ds = new System.Data.DataSet();
                adap.TableMappings.Add("Table","employee");
                adap.MissingSchemaAction=MissingSchemaAction.AddWithKey;
                adap.Fill(ds, "employee");
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //finally
            //{
              //  con.Close();
            //}
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {//Update
            SqlCommandBuilder cm3 = new SqlCommandBuilder(adap);
            DataRow r3 = ds.Tables["employee"].Rows.Find(textBox1.Text);
            r3["id"] = textBox1.Text;
            r3["name"] = textBox2.Text;
            r3["At"] = textBox3.Text;
            r3["shift"] = textBox4.Text;
            r3["Age"] = textBox5.Text;
            da.Close();
            adap.Update(ds, "employee");


           /* try
            {
                cmd1 = new SqlCommandBuilder(adap);
                adap.Update(ds, "employee");
                da.Close();
                MessageBox.Show("Successfully update !");
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Add
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                {
                    MessageBox.Show("fill the form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DataRow row = ds.Tables["employee"].NewRow();
                    row["id"] = textBox1.Text;
                    row["name"] = textBox2.Text;
                    row["At"] = textBox3.Text;
                    row["shift"] = textBox4.Text;
                    row["Age"] = textBox5.Text;
                    ds.Tables["employee"].Rows.Add(row);
                    con.Close();
                    cmd1 = new SqlCommandBuilder(adap);
                    adap.Update(ds, "employee");
                    MessageBox.Show("done!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
                
        }
        private void button6_Click(object sender, EventArgs e)
               {
            //Exit
            Form1 f1 = new Form1();
            this.Close();
            f1.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {//Back
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Delet
            SqlCommandBuilder cm2 = new SqlCommandBuilder(adap);
            da.Close();
            DataRow row2 = ds.Tables["employee"].Rows.Find(textBox1.Text);
            row2.Delete();
            adap.Update(ds, "employee");

          /*  adap = new SqlDataAdapter("Delete * from employee where id like %"+textBox1.Text+"%",con);
            cmd1 = new SqlCommandBuilder(adap);
            adap.Update(ds,"employee");
            MessageBox.Show("deleted");
            dataGridView1.DataSource = ds.Tables[0]; */


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {//like search
            if (textBox1.Text!= "")
            {
                con.Close();
                SqlCommand cmd = new SqlCommand("select name,shift,At,Age from employee where id=@ID", con);
                cmd.Parameters.AddWithValue("@ID",int.Parse(textBox1.Text));

                con.Open();
                    da = cmd.ExecuteReader();
                    while (da.Read())
                    {
                        textBox2.Text = da.GetValue(0).ToString();
                        textBox3.Text = da.GetValue(1).ToString();
                        textBox4.Text = da.GetValue(2).ToString();
                        textBox5.Text = da.GetValue(3).ToString();
                        // con.Close();
                    }
                
            }
        }
    }
}

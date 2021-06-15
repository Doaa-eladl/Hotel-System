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
    public partial class Form3 : Form
    {
        SqlConnection con1 = new SqlConnection(@"Server=DESKTOP-62UOLEV\DOAAELADL;DataBase=guest;Integrated Security=true;");
        SqlDataAdapter adap1;
        DataSet ds1;
        SqlCommandBuilder cmd1;

        public Form3()
        {
            InitializeComponent();
            try
            {
                con1.Open();
                adap1 = new SqlDataAdapter("select * from guest", con1);
                ds1 = new System.Data.DataSet();
                adap1.Fill(ds1, "guest");
                dataGridView1.DataSource = ds1.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con1.Close();
            }

        }
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cmd1 = new SqlCommandBuilder(adap1);
                adap1.Update(ds1, "guest");
                MessageBox.Show("Successfully update !");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}

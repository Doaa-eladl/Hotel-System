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
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(@"Server=DESKTOP-62UOLEV\DOAAELADL;DataBase=guest;Integrated Security=true;");
        SqlCommand cmd;
        public Form2()
        {
            InitializeComponent();
           
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select first name from guest where", con);
        }
    }
}

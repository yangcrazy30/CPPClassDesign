using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Data.SqlClient;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void Signup_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string Signup_id = this.textBox1.Text;
            string Signup_password = this.textBox1.Text;

            string conn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=H:\\code\\C#\\Restaurant\\Restaurant\\bin\\Debug\\Restaruant.mdb";
            SqlConnection connection = new SqlConnection(conn);

            connection.Open();
            string sql = string.Format("select count(*) from admin where iD='"+Signup_id+"' and password='"+Signup_password+"'",conn);

            SqlCommand command = new SqlCommand(sql, connection);
            int i = Convert.ToInt32(command.ExecuteScalar());//执行后返回记录行数

            if (i > 0)
            {
                MessageBox.Show("用户名已被注册");
            }
            else
            {
                MessageBox.Show("注册成功");

                string str = "server=.;database=Restaurant;integrated security=true";

                SqlConnection conn1 = new SqlConnection(str);
                conn1.Open();
                SqlCommand cmd = new SqlCommand("insert into Restaurant (iD,password) values('Signup_id','Signup_password')", conn1);
                cmd.ExecuteNonQuery();
                conn1.Close();


            }
            connection.Close();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Focus();
        }
    }
}

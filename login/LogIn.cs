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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click_1(object sender, EventArgs e)
        {
            string admin_id = this.textBox1.Text;
            string admin_password = this.textBox1.Text;

            string conn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=H:\\code\\C#\\Restaurant\\Restaurant\\bin\\Debug\\Restaruant.mdb";
            SqlConnection connection = new SqlConnection(conn);

            connection.Open();
            string sql = string.Format("select count(*) from admin where admin id='{0}' and admin_psw='{1}'", admin_id, admin_password);

            SqlCommand command = new SqlCommand(sql, connection);
            int i = Convert.ToInt32(command.ExecuteScalar());//执行后返回记录行数

            if (i > 0)//如果大于1，说明记录存在，登录成功
            {
                MessageBox.Show("登陆成功");
            }
            else
            {
                MessageBox.Show("用户名或密码错误");
            }
            connection.Close();

        }

        private void SigninButton_Click_1(object sender, EventArgs e)
        {
            var form = new Signup();
            form.Show();
            this.Close();
        }
    }
}

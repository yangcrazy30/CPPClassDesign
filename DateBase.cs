using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Restaurant
{
    class DateBase
    {
        private OleDbConnection connect;
        private OleDbCommand command;
        private ListViewItem foodmenu;
        private string bpoint;
        private string count;
        string connectstring;
        private string pword;
        public DateBase()
        {
            connectstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=H:\\code\\C#\\Restaurant\\Restaurant\\bin\\Debug\\Restaruant.mdb";
            connect = new OleDbConnection(connectstring);
            connect.Open();
            pword = null;
        }        
        public void SetLogin(string ID,string Password)
        {
            string sqlstr = "Insert into LOGIN values(";
            sqlstr += "'" + ID + "'";
            sqlstr += "," + "'" + Password + "'" + ")";
            command = new OleDbCommand(sqlstr, connect);
            command.ExecuteNonQuery();
            command.Dispose();
        }
        public string GetPassword(string ID)
        {
            string sqlstr = "select Password from LOGIN where ID=";
            sqlstr += "'" + ID + "'";
            command = connect.CreateCommand();
            command.CommandText = sqlstr;
            OleDbDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                 pword  = reader["Password"].ToString();
            }
            command.Dispose();
            return pword;
            
        }
        public void InsertMenu(string ID,string Name,int Price)
        {
            string sqlstr = "Insert into Menu(ID,Name,Price) values(";
            sqlstr += "'" + ID + "'" + ",";
            sqlstr += "'" + Name + "'" + ",";
            sqlstr += "'" + Price + "'" + ")";
            command = new OleDbCommand(sqlstr, connect);
            command.ExecuteNonQuery();
            command.Dispose();
        }
        public void DeleteMenu(string ID)
        {
            string sqlstr = "delete from Menu where ID=";
            sqlstr += "'" + ID + "'";
            command = new OleDbCommand(sqlstr, connect);
            command.ExecuteNonQuery();
            command.Dispose();
        }
        public ListViewItem  GetFoodProperty()
        {
            foodmenu.SubItems.Clear();
            command = connect.CreateCommand();
            command.CommandText = "select * from Menu";
            OleDbDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                foodmenu.SubItems[0].Text = reader["ID"].ToString();
                foodmenu.SubItems.Add(reader["Name"].ToString());
                foodmenu.SubItems.Add(reader["Price"].ToString());
                foodmenu.SubItems.Add(reader["Point"].ToString());
            }
            command.Dispose();
            return foodmenu;
        }
        public void InsertOrder(string ID,string Name,int num,string Price,string Time)
        {
            string sqlstr = "Insert into Orderlist values(";
            sqlstr += "'" + ID + "'" + ",";
            sqlstr += "'" + Name + "'" + ",";
            sqlstr += "'" + num + "'" + ",";
            sqlstr += "'" + Price + "'" + ",";
            sqlstr += "'" + Time + "'" + ")";
            command = new OleDbCommand(sqlstr, connect);
            command.ExecuteNonQuery();
            command.Dispose();
        }
        public ListViewItem GetOrder()
        {
            foodmenu.SubItems.Clear();
            command = connect.CreateCommand();
            command.CommandText = "select * from Orderlist";
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                foodmenu.SubItems[0].Text = reader["ID"].ToString();
                foodmenu.SubItems.Add(reader["Name"].ToString());
                foodmenu.SubItems.Add(reader["Num"].ToString());
                foodmenu.SubItems.Add(reader["Price"].ToString());
                foodmenu.SubItems.Add(reader["Time"].ToString());
            }
            command.Dispose();
            return foodmenu;
        }
        public void PointSet(int point,string ID)
        {
            /*string sqlstr = "select Point from Menu where ID=";
            sqlstr += "'" + ID + "'";
            command = connect.CreateCommand();
            command.CommandText = sqlstr;
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                 bpoint = reader["Point"].ToString();
                 count = reader["Count"].ToString();
            }
            int npoint = (int.Parse(bpoint) + point) / int.Parse(count);
            */
            string sqlstr = "insert into  Menu(Point) where ID= ";
            sqlstr += "'" + ID + "'";
            sqlstr += "valuse(";
            sqlstr += "'" + point + "'" + ")";
            command = new OleDbCommand(sqlstr, connect);
            command.ExecuteNonQuery();
            command.Clone();

        }
    }
}

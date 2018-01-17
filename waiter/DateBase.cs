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
        private string[] Waiter;
        private int Long;
        private string count;
        string connectstring;
        private string pword;
        private string type;
        public DateBase()
        {
            connectstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=H:\\code\\C#\\Restaurant\\Restaurant\\bin\\Debug\\Restaruant.mdb";
            connect = new OleDbConnection(connectstring);
            connect.Open();
            count = "";
          
            foodmenu = new ListViewItem();
            pword = null;
            type = null;
            Long = 0;
            
        }        
        public void SetLogin(string ID,string Password,string type)
        {
            string sqlstr = "Insert into LOGIN values(";
            sqlstr += "'" + ID + "'";
            sqlstr += "," + "'" + Password + "'";
            sqlstr += "," + "'" + type + "'" + ")";
            command = new OleDbCommand(sqlstr, connect);
            command.ExecuteNonQuery();
            command.Dispose();
        }
        public string GetPassword(string ID,string type)
        {
            command = new OleDbCommand();
            string sqlstr = "select Password from LOGIN where ID=";
            sqlstr += "'" + ID + "'";
            sqlstr += " "+"AND" + " "+"Type=" + "'" + type + "'";
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
        public string GEtUserType(string ID)
        {
            command = new OleDbCommand();
            string sqlstr = "select Password from LOGIN where ID=";
            sqlstr += "'" + ID + "'";
            command = connect.CreateCommand();
            command.CommandText = sqlstr;
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                type = reader["Type"].ToString();
            }
            command.Dispose();
            return type;
        }
        public void InsertMenu(string Name,string Price)
        {
            float result;
            float.TryParse(Price, out result);
            string sqlstr = "Insert into Menu(Name,Price) values(";
            sqlstr += "'" + Name + "'" + ",";
            sqlstr += "'" + Price + "'" + ")";
            command = new OleDbCommand(sqlstr, connect);
            command.ExecuteNonQuery();
            command.Dispose();
        }
        public void DeleteMenu(int ID)
        {
            string sqlstr = "delete from Menu where ID=";
            sqlstr +=ID;
            command = new OleDbCommand(sqlstr, connect);
            command.ExecuteNonQuery();
            command.Dispose();
        }
        public void  GetFoodProperty(ListView list)
        {
            command = new OleDbCommand();
            command = connect.CreateCommand();
            command.CommandText = "select * from Menu";
            OleDbDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                foodmenu = new ListViewItem();
                foodmenu.SubItems[0].Text = reader["ID"].ToString();
                foodmenu.SubItems.Add(reader["Name"].ToString());
                foodmenu.SubItems.Add(reader["Price"].ToString());
                foodmenu.SubItems.Add(reader["Point"].ToString());
                list.Items.Add(foodmenu);
            }
            command.Dispose();
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
        public void GetOrder(string ID,ListView list)
        {
            foodmenu = new ListViewItem();
            command = new OleDbCommand();
            command = connect.CreateCommand();
            string sqlstr = "select * from Orderlist where ID=";
            sqlstr += "'" + ID + "'";
            command.CommandText = sqlstr;
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                foodmenu = new ListViewItem();
                foodmenu.SubItems[0].Text = reader["ID"].ToString();
                foodmenu.SubItems.Add(reader["FoodName"].ToString());
                foodmenu.SubItems.Add(reader["Price"].ToString());
                foodmenu.SubItems.Add(reader["Num"].ToString());
                foodmenu.SubItems.Add(reader["Time"].ToString());
                list.Items.Add(foodmenu);
            }
            command.Dispose();
        }
        public void PointSet(double point,int ID)
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
            string Ppoint = point.ToString();
            string sqlstr = "Update Menu Set Point=";
            sqlstr += "'" + Ppoint + "'";
            sqlstr += "WHERE ID=";
            sqlstr += ID;
            command = new OleDbCommand(sqlstr, connect);
            command.ExecuteNonQuery();
            command.Dispose();


        }
        public void DeleteOrder(string ID)
        {
            string sqlstr = "delete from Orderlist where ID=";
            sqlstr += "'" + ID + "'";
            command = new OleDbCommand(sqlstr, connect);
            command.ExecuteNonQuery();
            command.Dispose();
        }
        public void GetOrderBytime(string time,ListView list,string ID)
        {
            command = new OleDbCommand();
            command = connect.CreateCommand();
            string sqlstr = "SELECT * from Orderlist WHERE Time LIKE";
            sqlstr += "'" + time + "%" + "'";
            sqlstr += " " + "AND" + " " + "ID=";
            sqlstr += "'" + ID + "'";
            command.CommandText = sqlstr;
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                foodmenu = new ListViewItem();
                foodmenu.SubItems[0].Text = reader["ID"].ToString();
                foodmenu.SubItems.Add(reader["FoodName"].ToString());
                foodmenu.SubItems.Add(reader["Num"].ToString());
                foodmenu.SubItems.Add(reader["Price"].ToString());
                foodmenu.SubItems.Add(reader["Time"].ToString());
                list.Items.Add(foodmenu);
            }
            command.Dispose();
        }
        public void InsertPM(string ID,string count)
        {
            string time = DateTime.Now.ToString();
            string sqlstr = "Insert into PM values(";
            sqlstr += "'" + ID + "'" + ",";
            sqlstr += "'" + count + "'";
            sqlstr += "," + "'" + time + "'"+")";
            command = new OleDbCommand(sqlstr, connect);
            command.ExecuteNonQuery();
            command.Dispose();
        }
        public string[] GetWaiter()
        {
            Long = 0;
            command = new OleDbCommand();
            command = connect.CreateCommand();
            string sqlstr = "select * from LOGIN Where Type='2'";
            command.CommandText = sqlstr;
            OleDbDataReader reader = command.ExecuteReader();
            int i = 0;
            Waiter = new string[99];
            while (reader.Read())
            {
                Waiter[i] = reader["ID"].ToString();
                Long++;
            }
            command.Dispose();
            return Waiter;
        }
        public int Getlong()
        {
            return Long;
        }
        public void GetPerformanceBytime(string time,ListView list)
        {
            command = new OleDbCommand();
            command = connect.CreateCommand();
            string sqlstr= "SELECT * from PM WHERE Time LIKE";
            sqlstr += "'" + time + "%" + "'";
            command.CommandText = sqlstr;
            OleDbDataReader reader = command.ExecuteReader();
            int count = 0;
            Waiter = GetWaiter();
            int m = Getlong();
            for (int i = 0; i < m; i++)
            {
                count = 0;
                foodmenu = new ListViewItem();
                while (reader.Read())
                {
                 
                    if(reader["ID"].ToString()==Waiter[i])
                    {
                        count += int.Parse(reader["t"].ToString());
                    }
                    foodmenu.SubItems[0].Text = reader["ID"].ToString();
                }
                
                
                foodmenu.SubItems.Add(count.ToString());
                foodmenu.SubItems.Add(time);
                list.Items.Add(foodmenu);
            }
            command.Dispose();
        }
        public string GetPoint(int ID)
        {
            command = new OleDbCommand();
            command = connect.CreateCommand();
            string sqlstr = "select Point from Menu where ID=";
            sqlstr += ID;
            command.CommandText = sqlstr;
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                type = reader["Point"].ToString();
            }
            command.Dispose();
            return type;
        }
        public void UpdateCount(int ID,int Count)
        {
            string sqlstr = "Update Menu Set [Count]=";
            sqlstr += "'" + Count + "'";
            sqlstr += "WHERE [ID]=";
            sqlstr += ID;
            command = new OleDbCommand(sqlstr, connect);
            command.ExecuteNonQuery();
            command.Dispose();
        }
        public void SortWithCount(ListView list)
        {
            string sqlstr = "Select* from Menu Order by Count DESC";
            command = new OleDbCommand();
            command = connect.CreateCommand();
            command.CommandText = sqlstr;
            OleDbDataReader reader = command.ExecuteReader();
            int i = 0;
            while (reader.Read()&&i<=4)
            {
                foodmenu = new ListViewItem();
                foodmenu.SubItems[0].Text = reader["ID"].ToString();
                foodmenu.SubItems.Add(reader["Name"].ToString());
                foodmenu.SubItems.Add(reader["Price"].ToString());
                foodmenu.SubItems.Add(reader["Point"].ToString());
                list.Items.Add(foodmenu);
                i++;
            }
            command.Dispose();
        }
        public int GetCount(int ID)
        {
            command = new OleDbCommand();
            string sqlstr = "select Count from Menu where ID=";
            sqlstr += ID; 
            command = connect.CreateCommand();
            command.CommandText = sqlstr;
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                count = reader["Count"].ToString();
            }
            command.Dispose();
            return int.Parse(count);
        }
    }
}

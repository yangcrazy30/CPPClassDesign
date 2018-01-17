using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant
{
    public partial class MenuCreate : Form
    {
        private DateBase database;
        private Manager ma;
        private LogIn log;
        public MenuCreate()
        {
           
            InitializeComponent();
            ma = new Manager();
            database = new DateBase();
            RefreshItem();
        }
        public MenuCreate(LogIn login )
        {
            InitializeComponent();
            log = login;
            ma = new Manager();
            database = new DateBase();
            RefreshItem();
        }
        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // listView1.Items.Add()
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            InsertFood temp = new InsertFood(this);
            temp.ShowDialog();
        }
        public void RefreshItem()
        {
            listView1.Items.Clear();
           
            database.GetFoodProperty(listView1);
        
        }
        private void MenuCreate_Load(object sender, EventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem var in listView1.Items )
            {
                if(var.Selected)
                {
                    ma.DeletMenu(listView1);
                    var.Remove();
                   
                 }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            log.textBox1.Text = "";
            log.textBox2.Text = "";
            log.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Performance pm = new Performance();
            pm.Show();
        }
    }
}

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
    public partial class InsertFoodNum : Form
    {
        private WaiterSystem waitersys;
        private DateBase db;
        public InsertFoodNum()
        {
            InitializeComponent();
            textBox1.Text = "1";
        }
        public InsertFoodNum(WaiterSystem wsys)
        {
            InitializeComponent();
            waitersys = wsys;
            textBox1.Text = "1";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            db = new DateBase();
            int result;
            int.TryParse(textBox1.Text,out result);
            waitersys.Num = result;
            db.InsertPM(waitersys.log.textBox1.Text, result.ToString());
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

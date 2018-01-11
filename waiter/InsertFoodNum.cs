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
        public InsertFoodNum()
        {
            InitializeComponent();
        }
        public InsertFoodNum(WaiterSystem wsys)
        {
            InitializeComponent();
            waitersys = wsys;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int result;
            int.TryParse(textBox1.Text,out result);
            waitersys.Num = result;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

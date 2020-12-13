using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szerencsejatek
{
    public partial class Form1 : Form
    {
        Database1Entities context = new Database1Entities();

        List<Table> Szelvenyek;

        Random rnd = new Random();


        public Form1()
        {
            InitializeComponent();
            LoadData();

            

        }

        private void LoadData()
        {
            Szelvenyek = context.Table.ToList();
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            textBox1.Text = rnd.Next(1, 90).ToString();
            textBox2.Text = rnd.Next(1, 90).ToString();
            textBox3.Text = rnd.Next(1, 90).ToString();
            textBox4.Text = rnd.Next(1, 90).ToString();
            textBox5.Text = rnd.Next(1, 90).ToString();
        }
    }
}

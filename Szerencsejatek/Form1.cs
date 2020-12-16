using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace Szerencsejatek
{
    public partial class Form1 : Form
    {
        Database1Entities context = new Database1Entities();

        List<Table> Szelvenyek;

        Excel.Application xlApp;
        Excel.Workbook xlWB;
        Excel.Worksheet xlSheet;


        Random rnd = new Random();




        public Form1()
        {
            InitializeComponent();

            Szelvenyek = context.Szelvenyek.ToList();
            dataGridView1.DataSource = Szelvenyek;

            

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

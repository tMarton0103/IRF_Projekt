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

            CreateExcel();
            
        }

        

        void CreateExcel()
        {
            try
            {
                xlApp = new Excel.Application();

                xlWB = xlApp.Workbooks.Add(Missing.Value);

                xlSheet = xlWB.ActiveSheet;

                CreateTable();

                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception ex)
            {
                string errMsg = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
                MessageBox.Show(errMsg, "Error");

                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWB = null;
                xlApp = null;

                
            }
        }
        
        void CreateTable()
        {
            string[] fejlec = new string[]
            {
                "Szelveny_Id",
                "1. szám",
                "2. szám",
                "3. szám",
                "4. szám",
                "5. szám"
            };

            for (int i = 1; i < fejlec.Length; i++)
            {
                xlSheet.Cells[i, 1] = fejlec[0];
            }

            object[,] values = new object[Szelvenyek.Count, fejlec.Length];

            int counter = 0;
            foreach (var s in Szelvenyek)
            {
                values[counter, 0] = s.Szelveny_Id;
                values[counter, 1] = s.t01;
                values[counter, 2] = s.t02;
                values[counter, 3] = s.t03;
                values[counter, 4] = s.t04;
                values[counter, 5] = s.t05;
                counter++;
            }
            xlSheet.get_Range(
                GetCell(2, 1),
                GetCell(1 + values.GetLength(0), values.GetLength(1))).Value2 = values;


            //Tábla formázása
            Excel.Range headerRange = xlSheet.get_Range(GetCell(1, 1), GetCell(1, fejlec.Length));
            headerRange.Font.Bold = true;
            headerRange.Interior.Color = Color.AliceBlue;

        }

        
        
        private string GetCell(int x, int y)
        {
            string ExcelCoordinate = "";
            int dividend = y;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                ExcelCoordinate = Convert.ToChar(65 + modulo).ToString() + ExcelCoordinate;
                dividend = (int)((dividend - modulo) / 26);
            }
            ExcelCoordinate += x.ToString();
            return ExcelCoordinate;          
        }

        
        private void btnStart_Click(object sender, EventArgs e)
        {
            textBox1.Text = rnd.Next(1, 90).ToString();
            textBox2.Text = rnd.Next(1, 90).ToString();
            textBox3.Text = rnd.Next(1, 90).ToString();
            textBox4.Text = rnd.Next(1, 90).ToString();
            textBox5.Text = rnd.Next(1, 90).ToString();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {

            int talalatokSzama = 0;
            for (int i = 0; i < Szelvenyek.Count; i++)
            {
                if (Szelvenyek[i].ToString() == textBox1.Text)
                {
                    talalatokSzama++;
                }
                else if(Szelvenyek[i].ToString() == textBox2.Text)
                {
                    talalatokSzama++;
                }
                else if (Szelvenyek[i].ToString() == textBox3.Text)
                {
                    talalatokSzama++;
                }
                else if (Szelvenyek[i].ToString() == textBox4.Text)
                {
                    talalatokSzama++;
                }
                else if (Szelvenyek[i].ToString() == textBox5.Text)
                {
                    talalatokSzama++;
                }
                
                  
            }

            txtTalalatok.Text = talalatokSzama.ToString();
        }
    }
}

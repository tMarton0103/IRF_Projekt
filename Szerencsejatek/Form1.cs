﻿using System;
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


        public Form1()
        {
            InitializeComponent();
            LoadData();


        }

        private void LoadData()
        {
            Szelvenyek = context.Table.ToList();
        }
    }
}

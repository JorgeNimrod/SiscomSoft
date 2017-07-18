﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmPeriodoTrabajo : Form
    {
        public FrmPeriodoTrabajo()
        {
            InitializeComponent();
            dgvPeriodos.AutoGenerateColumns = false;
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            Close();
            FrmMenu v = new FrmMenu();
            v.ShowDialog();
        }

        private void FrmPeriodoTrabajo_Load(object sender, EventArgs e)
        {
            timer1.Start();             
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
        }
    }
}

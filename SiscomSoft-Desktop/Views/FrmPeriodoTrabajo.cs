using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SiscomSoft.Models;
using SiscomSoft.Controller;


namespace SiscomSoft_Desktop.Views
{
    public partial class FrmPeriodoTrabajo : Form
    {
        public FrmPeriodoTrabajo()
        {
            InitializeComponent();
            dgvPeriodos.AutoGenerateColumns = false;
        }

        public void cargarPeriodos()
        {
            dgvPeriodos.DataSource = ManejoPeriodo.getAll(true);
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
            cargarPeriodos();            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
        }

        private void btnIniciarPeriodo_Click(object sender, EventArgs e)
        {
            Periodo mPeriodo = ManejoPeriodo.getByUser(FrmMenu.uHelper.usuario.pkUsuario);
            if (mPeriodo!=null)
            {
                MessageBox.Show("Ya hay un periodo iniciado para este usuario: " + FrmMenu.uHelper.usuario.sUsuario + ".");
                mPeriodo = null;
            }
            else
            {
                FrmDetallePeriodo v = new Views.FrmDetallePeriodo(this);
                v.ShowDialog();
            }
        }

        private void btnFinalizarPeriodo_Click(object sender, EventArgs e)
        {
            if (dgvPeriodos.CurrentRow != null)
            {
                DateTime dt = new DateTime(0001, 01, 01, 00, 00, 00);
                Periodo mPeriodo = ManejoPeriodo.getById(Convert.ToInt32(dgvPeriodos.CurrentRow.Cells[0].Value));
                if (mPeriodo.dtFinal == dt)
                {
                    if (FrmMenu.uHelper.usuario.pkUsuario == mPeriodo.fkUsuario.pkUsuario)
                    {
                        mPeriodo.dtFinal = DateTime.Now;
                        ManejoPeriodo.Modificar(mPeriodo, FrmMenu.uHelper.usuario);
                        cargarPeriodos();
                    }
                    else
                    {
                        MessageBox.Show("No puedes finalizar este periodo.");
                    }
                }
                else
                {
                    MessageBox.Show("Este periodo ya esta finalizado.");
                }
                mPeriodo = null;
            }
        }
    }
}

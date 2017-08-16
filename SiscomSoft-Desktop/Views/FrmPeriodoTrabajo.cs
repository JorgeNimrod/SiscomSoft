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
        #region MAIN
        public FrmPeriodoTrabajo()
        {
            InitializeComponent();
            dgvPeriodos.AutoGenerateColumns = false;
            dgvPeriodoFecha.AutoGenerateColumns = false;
            dgvDetalleVenta.AutoGenerateColumns = false;
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
            cmbPeriodo.SelectedIndex = 0;
            dgvPeriodoFecha.DataSource = ManejoPeriodo.getAllDate();
            totalesGenerales();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
        }

        private void btnIniciarPeriodo_Click(object sender, EventArgs e)
        {
            Periodo mPeriodo = ManejoPeriodo.getByUser(FrmMenu.uHelper.usuario.idUsuario);
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
                    if (FrmMenu.uHelper.usuario.idUsuario == mPeriodo.usuario_id.idUsuario)
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
        private void btnReporte_Click(object sender, EventArgs e)
        {
            dgvPeriodos.Visible = false;
            btnReporte.Visible = false;
            lblalgo.Visible = false;
            btnIniciarPeriodo.Visible = false;
            btnFinalizarPeriodo.Visible = false;
            pnlReporte.Visible = true;
            pnlTotalGeneral.Visible = true;
        }

        #endregion

        #region REPORTE
        public void totalesGenerales()
        {
            decimal tCredito = 0;
            decimal credito = 0;
            decimal efectivo = 0;
            foreach (DataGridViewRow row in dgvPeriodoFecha.Rows)
            {
                tCredito += Convert.ToDecimal(row.Cells[4].Value);
                credito += Convert.ToDecimal(row.Cells[3].Value);
                efectivo += Convert.ToDecimal(row.Cells[2].Value);
            }
            lblTotalTCredito.Text = tCredito.ToString("N");
            lblTotalCredito.Text = credito.ToString("N");
            lblTotalEfectivo.Text = efectivo.ToString("N");
        }

        private void btnPeriodo_Click(object sender, EventArgs e)
        {
            dgvPeriodos.Visible = true;
            btnReporte.Visible = true;
            lblalgo.Visible = true;
            btnIniciarPeriodo.Visible = true;
            btnFinalizarPeriodo.Visible = true;
            pnlReporte.Visible = false;
            pnlTotalGeneral.Visible = false;
        }

        private void cmbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime fechaTemp = DateTime.Today;
            DateTime dateInicio;
            DateTime dateFin;
            if (cmbPeriodo.SelectedIndex==0)
            {
                dtpInicio.Enabled = false;
                dtpFin.Enabled = false;
            }
            else if (cmbPeriodo.SelectedIndex == 1)
            {
                dtpInicio.Enabled = true;
                dtpFin.Enabled = true;
                dateInicio = new DateTime(fechaTemp.Year, fechaTemp.Month, 1);
                if (fechaTemp.Month + 1 < 13)
                {
                    dateFin = new DateTime(fechaTemp.Year, fechaTemp.Month + 1, 1).AddDays(-1);
                }
                else
                {
                    dateFin = new DateTime(fechaTemp.Year + 1, 1, 1).AddDays(-1);
                }
                dtpInicio.Value = dateInicio;
                dtpFin.Value = dateFin;
            }
            else if (cmbPeriodo.SelectedIndex == 2)
            {
                dtpInicio.Enabled = true;
                dtpFin.Enabled = true;
                dateInicio = new DateTime(fechaTemp.Year, fechaTemp.Month - 1, 1);
                if (fechaTemp.Month + 1 < 13)
                {
                    dateFin = new DateTime(fechaTemp.Year, fechaTemp.Month - 1 + 1, 1).AddDays(-1);
                }
                else
                {
                    dateFin = new DateTime(fechaTemp.Year + 1, 1, 1).AddDays(-1);
                }
                dtpInicio.Value = dateInicio;
                dtpFin.Value = dateFin;
            }
            else if (cmbPeriodo.SelectedIndex == 3)
            {
                dtpInicio.Enabled = true;
                dtpFin.Enabled = true;

                dateInicio = DateTime.MinValue;
                dateInicio = fechaTemp.AddDays(1 - Convert.ToDouble(fechaTemp.DayOfWeek));

                dateFin = DateTime.MinValue;
                dateFin = fechaTemp.AddDays(7 - Convert.ToDouble(fechaTemp.DayOfWeek));

                dtpInicio.Value = dateInicio.Date;
                dtpFin.Value = dateFin.Date;
            }
            else if (cmbPeriodo.SelectedIndex == 4)
            {
                dtpInicio.Enabled = true;
                dtpFin.Enabled = true;

                dateInicio = DateTime.MinValue;
                dateInicio = fechaTemp.AddDays(1 - Convert.ToDouble(fechaTemp.DayOfWeek) - 7);

                dateFin = DateTime.MinValue;
                dateFin = fechaTemp.AddDays(7 - Convert.ToDouble(fechaTemp.DayOfWeek) -7);

                dtpInicio.Value = dateInicio.Date;
                dtpFin.Value = dateFin.Date;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbPeriodo.SelectedIndex == 0)
            {
                dgvPeriodoFecha.DataSource = null;
                dgvPeriodoFecha.DataSource = ManejoPeriodo.getAllDate();
                totalesGenerales();
            }
            else
            {
                dgvPeriodoFecha.DataSource = null;
                dgvPeriodoFecha.DataSource = ManejoPeriodo.getByDate(dtpInicio.Value, dtpFin.Value);
                totalesGenerales();
            }
        }

        private void dgvPeriodoFecha_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Venta mVenta = ManejoVenta.getById(Convert.ToInt32(dgvPeriodoFecha.CurrentRow.Cells[5].Value));
            List<PeriodoVentas> mDetalleVenta = ManejoPeriodo.getByDetalleVenta(mVenta.idVenta);
            txtFolioVenta.Text = mVenta.sFolio;
            txtFecha.Text = mVenta.dtFechaVenta.ToString();
            txtTipoPago.Text = mVenta.sTipoPago;
            txtMoneda.Text = mVenta.sMoneda;
            if(mVenta.iTurno==1)
            {
                txtTurno.Text = "MATUTINO";
            }
            else if (mVenta.iTurno == 2)
            {
                txtTurno.Text = "VESPERTINO";
            }
            txtCaja.Text = mVenta.iCaja.ToString();
            decimal total = 0;
            decimal subtotal = 0;
            decimal cantidad = 0;
            decimal costo = 0;
            foreach (PeriodoVentas rDetalleVenta in mDetalleVenta)
            {
                DataGridViewRow row = (DataGridViewRow)dgvDetalleVenta.Rows[0].Clone();
                row.Cells[0].Value = rDetalleVenta.idDetalleVenta;
                row.Cells[1].Value = rDetalleVenta.idProducto;
                row.Cells[2].Value = rDetalleVenta.sDescripcion;
                row.Cells[3].Value = rDetalleVenta.dCantidad;
                row.Cells[4].Value = rDetalleVenta.dCosto;

                cantidad = rDetalleVenta.dCantidad;
                costo = rDetalleVenta.dCosto;
                subtotal = cantidad * costo;

                row.Cells[5].Value = subtotal.ToString("N");
                dgvDetalleVenta.Rows.Add(row);
            }

            foreach (DataGridViewRow row in dgvDetalleVenta.Rows)
            {
                total += Convert.ToDecimal(row.Cells[5].Value);
            }

            txtTotal.Text = total.ToString("N");
            txtCambio.Text = mVenta.dCambio.ToString("N");
            
            txtUsuario.Text = mVenta.usuario_id.sNombre;

            if (mVenta.cliente_id != null)
            {
                txtCliente.Text = mVenta.cliente_id.sNombre;
            }
            if (mVenta.factura_id!=null)
            {
                txtFolio.Text = mVenta.factura_id.sFolio;
            }

            dgvPeriodos.Visible = false;
            btnReporte.Visible = false;
            lblalgo.Visible = false;
            btnIniciarPeriodo.Visible = false;
            btnFinalizarPeriodo.Visible = false;
            pnlReporte.Visible = false;
            pnlTotalGeneral.Visible = false;
            pnlDetallePeriodo.Visible = true;
        }
        #endregion

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            pnlDetallePeriodo.Visible = false;
            dgvPeriodos.Visible = false;
            btnReporte.Visible = false;
            lblalgo.Visible = false;
            btnIniciarPeriodo.Visible = false;
            btnFinalizarPeriodo.Visible = false;
            pnlReporte.Visible = true;
            pnlTotalGeneral.Visible = true;
            dgvDetalleVenta.Rows.Clear();
        }
    }
}

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

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmMenuVentas : Form
    {
        #region variables staticas
        public static InventarioEntrada nVentaB10;
        public static Boolean bBtnB10 = false;
        public static InventarioEntrada nVentaB11;
        public static Boolean bBtnB11 = false;
        public static InventarioEntrada nVentaB12;
        public static Boolean bBtnB12 = false;
        public static InventarioEntrada nVentaB13;
        public static Boolean bBtnB13 = false;
        public static InventarioEntrada nVentaB14;
        public static Boolean bBtnB14 = false;
        public static InventarioEntrada nVentaB15;
        public static Boolean bBtnB15 = false;
        public static InventarioEntrada nVentaB16;
        public static Boolean bBtnB16 = false;
        public static InventarioEntrada nVentaB17;
        public static Boolean bBtnB17 = false;
        public static InventarioEntrada nVentaB18;
        public static Boolean bBtnB18 = false;
        public static InventarioEntrada nVentaB19;
        public static Boolean bBtnB19 = false;
        public static InventarioEntrada nVentaB20;
        public static Boolean bBtnB20 = false;
        public static InventarioEntrada nVentaB21;
        public static Boolean bBtnB21 = false;
        public static InventarioEntrada nVentaB22;
        public static Boolean bBtnB22 = false;
        public static InventarioEntrada nVentaB23;
        public static Boolean bBtnB23 = false;
        public static InventarioEntrada nVentaB24;
        public static Boolean bBtnB24 = false;
        public static InventarioEntrada nVentaB25;
        public static Boolean bBtnB25 = false;
        public static InventarioEntrada nVentaB26;
        public static Boolean bBtnB26 = false;
        public static InventarioEntrada nVentaB27;
        public static Boolean bBtnB27 = false;
        public static InventarioEntrada nVentaB28;
        public static Boolean bBtnB28 = false;
        public static InventarioEntrada nVentaB29;
        public static Boolean bBtnB29 = false;
        public static InventarioEntrada nVentaB30;
        public static Boolean bBtnB30 = false;
        public static InventarioEntrada nVentaM10;
        public static Boolean bBtnM10 = false;
        public static InventarioEntrada nVentaM11;
        public static Boolean bBtnM11 = false;
        public static InventarioEntrada nVentaM12;
        public static Boolean bBtnM12 = false;
        public static InventarioEntrada nVentaM13;
        public static Boolean bBtnM13 = false;
        public static InventarioEntrada nVentaM14;
        public static Boolean bBtnM14 = false;
        public static InventarioEntrada nVentaM15;
        public static Boolean bBtnM15 = false;
        public static InventarioEntrada nVentaM16;
        public static Boolean bBtnM16 = false;
        public static InventarioEntrada nVentaM17;
        public static Boolean bBtnM17 = false;
        public static InventarioEntrada nVentaM18;
        public static Boolean bBtnM18 = false;
        public static InventarioEntrada nVentaM19;
        public static Boolean bBtnM19 = false;
        public static InventarioEntrada nVentaM20;
        public static Boolean bBtnM20 = false;
        public static InventarioEntrada nVentaM21;
        public static Boolean bBtnM21 = false;
        public static InventarioEntrada nVentaM22;
        public static Boolean bBtnM22 = false;
        public static InventarioEntrada nVentaM23;
        public static Boolean bBtnM23 = false;
        public static InventarioEntrada nVentaM24;
        public static Boolean bBtnM24 = false;
        public static InventarioEntrada nVentaM25;
        public static Boolean bBtnM25 = false;
        public static InventarioEntrada nVentaM26;
        public static Boolean bBtnM26 = false;
        public static InventarioEntrada nVentaM27;
        public static Boolean bBtnM27 = false;
        public static InventarioEntrada nVentaM28;
        public static Boolean bBtnM28 = false;
        public static InventarioEntrada nVentaM29;
        public static Boolean bBtnM29 = false;
        public static InventarioEntrada nVentaM30;
        public static Boolean bBtnM30 = false;
        #endregion

        public FrmMenuVentas()
        {
            InitializeComponent();
        }

        public void venta()
        {
            this.Close();
            FrmDetalleVentaTemplete v = new FrmDetalleVentaTemplete();
            v.Show();
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
            #region color botones
            if (nVentaB10!=null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaB11 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaB12 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaB13 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaB14 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaB15 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaB16 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaB17 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaB18 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaB19 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaB20 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaB21 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaB22 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaB23 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaB24 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaB25 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaB26 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaB27 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaB28 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaB29 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaB30 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaM10 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaM11 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaM12 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaM13 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaM14 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaM15 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaM16 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaM17 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaM18 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaM19 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaM20 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaM21 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaM22 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaM23 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaM24 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaM25 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaM26 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaM27 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaM28 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaM29 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaM30 != null)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            #endregion
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmMenu v = new FrmMenu();
            v.Show();
        }

        private void btnB10_Click(object sender, EventArgs e)
        {
            venta();
            bBtnB10 = true;
        }
    }
}

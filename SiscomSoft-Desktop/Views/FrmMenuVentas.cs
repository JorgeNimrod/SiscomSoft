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
        public static List<InventarioEntrada> nVentaB10;
        public static Boolean bBtnB10 = false;
        public static List<InventarioEntrada> nVentaB11;
        public static Boolean bBtnB11 = false;
        public static List<InventarioEntrada> nVentaB12;
        public static Boolean bBtnB12 = false;
        public static List<InventarioEntrada> nVentaB13;
        public static Boolean bBtnB13 = false;
        public static List<InventarioEntrada> nVentaB14;
        public static Boolean bBtnB14 = false;
        public static List<InventarioEntrada> nVentaB15;
        public static Boolean bBtnB15 = false;
        public static List<InventarioEntrada> nVentaB16;
        public static Boolean bBtnB16 = false;
        public static List<InventarioEntrada> nVentaB17;
        public static Boolean bBtnB17 = false;
        public static List<InventarioEntrada> nVentaB18;
        public static Boolean bBtnB18 = false;
        public static List<InventarioEntrada> nVentaB19;
        public static Boolean bBtnB19 = false;
        public static List<InventarioEntrada> nVentaB20;
        public static Boolean bBtnB20 = false;
        public static List<InventarioEntrada> nVentaB21;
        public static Boolean bBtnB21 = false;
        public static List<InventarioEntrada> nVentaB22;
        public static Boolean bBtnB22 = false;
        public static List<InventarioEntrada> nVentaB23;
        public static Boolean bBtnB23 = false;
        public static List<InventarioEntrada> nVentaB24;
        public static Boolean bBtnB24 = false;
        public static List<InventarioEntrada> nVentaB25;
        public static Boolean bBtnB25 = false;
        public static List<InventarioEntrada> nVentaB26;
        public static Boolean bBtnB26 = false;
        public static List<InventarioEntrada> nVentaB27;
        public static Boolean bBtnB27 = false;
        public static List<InventarioEntrada> nVentaB28;
        public static Boolean bBtnB28 = false;
        public static List<InventarioEntrada> nVentaB29;
        public static Boolean bBtnB29 = false;
        public static List<InventarioEntrada> nVentaB30;
        public static Boolean bBtnB30 = false;
        public static List<InventarioEntrada> nVentaM10;
        public static Boolean bBtnM10 = false;
        public static List<InventarioEntrada> nVentaM11;
        public static Boolean bBtnM11 = false;
        public static List<InventarioEntrada> nVentaM12;
        public static Boolean bBtnM12 = false;
        public static List<InventarioEntrada> nVentaM13;
        public static Boolean bBtnM13 = false;
        public static List<InventarioEntrada> nVentaM14;
        public static Boolean bBtnM14 = false;
        public static List<InventarioEntrada> nVentaM15;
        public static Boolean bBtnM15 = false;
        public static List<InventarioEntrada> nVentaM16;
        public static Boolean bBtnM16 = false;
        public static List<InventarioEntrada> nVentaM17;
        public static Boolean bBtnM17 = false;
        public static List<InventarioEntrada> nVentaM18;
        public static Boolean bBtnM18 = false;
        public static List<InventarioEntrada> nVentaM19;
        public static Boolean bBtnM19 = false;
        public static List<InventarioEntrada> nVentaM20;
        public static Boolean bBtnM20 = false;
        public static List<InventarioEntrada> nVentaM21;
        public static Boolean bBtnM21 = false;
        public static List<InventarioEntrada> nVentaM22;
        public static Boolean bBtnM22 = false;
        public static List<InventarioEntrada> nVentaM23;
        public static Boolean bBtnM23 = false;
        public static List<InventarioEntrada> nVentaM24;
        public static Boolean bBtnM24 = false;
        public static List<InventarioEntrada> nVentaM25;
        public static Boolean bBtnM25 = false;
        public static List<InventarioEntrada> nVentaM26;
        public static Boolean bBtnM26 = false;
        public static List<InventarioEntrada> nVentaM27;
        public static Boolean bBtnM27 = false;
        public static List<InventarioEntrada> nVentaM28;
        public static Boolean bBtnM28 = false;
        public static List<InventarioEntrada> nVentaM29;
        public static Boolean bBtnM29 = false;
        public static List<InventarioEntrada> nVentaM30;
        public static Boolean bBtnM30 = false;
        #endregion

        public FrmMenuVentas()
        {
            InitializeComponent();
        }

        public void venta()
        {
            this.Close();
            FrmDetalleVentaComandera v = new FrmDetalleVentaComandera();
            v.Show();
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
            #region color botones
            if (nVentaB10!=null && bBtnB10 == false)
            {
                btnB10.BackColor = Color.RoyalBlue;
                btnB10.ForeColor = Color.White;
            }
            if (nVentaB11 != null && bBtnB11 == false)
            {
                btnB11.BackColor = Color.RoyalBlue;
                btnB11.ForeColor = Color.White;
            }
            if (nVentaB12 != null && bBtnB12 == false)
            {
                btnB12.BackColor = Color.RoyalBlue;
                btnB12.ForeColor = Color.White;
            }
            if (nVentaB13 != null && bBtnB13 == false)
            {
                btnB13.BackColor = Color.RoyalBlue;
                btnB13.ForeColor = Color.White;
            }
            if (nVentaB14 != null && bBtnB14 == false)
            {
                btnB14.BackColor = Color.RoyalBlue;
                btnB14.ForeColor = Color.White;
            }
            if (nVentaB15 != null && bBtnB15 == false)
            {
                btnB15.BackColor = Color.RoyalBlue;
                btnB15.ForeColor = Color.White;
            }
            if (nVentaB16 != null && bBtnB16 == false)
            {
                btnB16.BackColor = Color.RoyalBlue;
                btnB16.ForeColor = Color.White;
            }
            if (nVentaB17 != null && bBtnB17 == false)
            {
                btnB17.BackColor = Color.RoyalBlue;
                btnB17.ForeColor = Color.White;
            }
            if (nVentaB18 != null && bBtnB18 == false)
            {
                btnB18.BackColor = Color.RoyalBlue;
                btnB18.ForeColor = Color.White;
            }
            if (nVentaB19 != null && bBtnB19 == false)
            {
                btnB19.BackColor = Color.RoyalBlue;
                btnB19.ForeColor = Color.White;
            }
            if (nVentaB20 != null && bBtnB20 == false)
            {
                btnB20.BackColor = Color.RoyalBlue;
                btnB20.ForeColor = Color.White;
            }
            if (nVentaB21 != null && bBtnB21 == false)
            {
                btnB21.BackColor = Color.RoyalBlue;
                btnB21.ForeColor = Color.White;
            }
            if (nVentaB22 != null && bBtnB22 == false)
            {
                btnB22.BackColor = Color.RoyalBlue;
                btnB22.ForeColor = Color.White;
            }
            if (nVentaB23 != null && bBtnB23 == false)
            {
                btnB23.BackColor = Color.RoyalBlue;
                btnB23.ForeColor = Color.White;
            }
            if (nVentaB24 != null && bBtnB24 == false)
            {
                btnB24.BackColor = Color.RoyalBlue;
                btnB24.ForeColor = Color.White;
            }
            if (nVentaB25 != null && bBtnB25 == false)
            {
                btnB25.BackColor = Color.RoyalBlue;
                btnB25.ForeColor = Color.White;
            }
            if (nVentaB26 != null && bBtnB26 == false)
            {
                btnB26.BackColor = Color.RoyalBlue;
                btnB26.ForeColor = Color.White;
            }
            if (nVentaB27 != null && bBtnB27 == false)
            {
                btnB27.BackColor = Color.RoyalBlue;
                btnB27.ForeColor = Color.White;
            }
            if (nVentaB28 != null && bBtnB28 == false)
            {
                btnB28.BackColor = Color.RoyalBlue;
                btnB28.ForeColor = Color.White;
            }
            if (nVentaB29 != null && bBtnB29 == false)
            {
                btnB29.BackColor = Color.RoyalBlue;
                btnB29.ForeColor = Color.White;
            }
            if (nVentaB30 != null && bBtnB30 == false)
            {
                btnB30.BackColor = Color.RoyalBlue;
                btnB30.ForeColor = Color.White;
            }
            if (nVentaM10 != null && bBtnM10 == false)
            {
                btnM10.BackColor = Color.RoyalBlue;
                btnM10.ForeColor = Color.White;
            }
            if (nVentaM11 != null && bBtnM11 == false)
            {
                btnM11.BackColor = Color.RoyalBlue;
                btnM11.ForeColor = Color.White;
            }
            if (nVentaM12 != null && bBtnM12 == false)
            {
                btnM12.BackColor = Color.RoyalBlue;
                btnM12.ForeColor = Color.White;
            }
            if (nVentaM13 != null && bBtnM13 == false)
            {
                btnM13.BackColor = Color.RoyalBlue;
                btnM13.ForeColor = Color.White;
            }
            if (nVentaM14 != null && bBtnM14 == false)
            {
                btnM14.BackColor = Color.RoyalBlue;
                btnM14.ForeColor = Color.White;
            }
            if (nVentaM15 != null && bBtnM15 == false)
            {
                btnM15.BackColor = Color.RoyalBlue;
                btnM15.ForeColor = Color.White;
            }
            if (nVentaM16 != null && bBtnM16 == false)
            {
                btnM16.BackColor = Color.RoyalBlue;
                btnM16.ForeColor = Color.White;
            }
            if (nVentaM17 != null && bBtnM17 == false)
            {
                btnM17.BackColor = Color.RoyalBlue;
                btnM17.ForeColor = Color.White;
            }
            if (nVentaM18 != null && bBtnM18 == false)
            {
                btnM18.BackColor = Color.RoyalBlue;
                btnM18.ForeColor = Color.White;
            }
            if (nVentaM19 != null && bBtnM19 == false)
            {
                btnM19.BackColor = Color.RoyalBlue;
                btnM19.ForeColor = Color.White;
            }
            if (nVentaM20 != null && bBtnM20 == false)
            {
                btnM20.BackColor = Color.RoyalBlue;
                btnM20.ForeColor = Color.White;
            }
            if (nVentaM21 != null && bBtnM21 == false)
            {
                btnM21.BackColor = Color.RoyalBlue;
                btnM21.ForeColor = Color.White;
            }
            if (nVentaM22 != null && bBtnM22 == false)
            {
                btnM22.BackColor = Color.RoyalBlue;
                btnM22.ForeColor = Color.White;
            }
            if (nVentaM23 != null && bBtnM23 == false)
            {
                btnM23.BackColor = Color.RoyalBlue;
                btnM23.ForeColor = Color.White;
            }
            if (nVentaM24 != null && bBtnM24 == false)
            {
                btnM24.BackColor = Color.RoyalBlue;
                btnM24.ForeColor = Color.White;
            }
            if (nVentaM25 != null && bBtnM25 == false)
            {
                btnM25.BackColor = Color.RoyalBlue;
                btnM25.ForeColor = Color.White;
            }
            if (nVentaM26 != null && bBtnM26 == false)
            {
                btnM26.BackColor = Color.RoyalBlue;
                btnM26.ForeColor = Color.White;
            }
            if (nVentaM27 != null && bBtnM27 == false)
            {
                btnM27.BackColor = Color.RoyalBlue;
                btnM27.ForeColor = Color.White;
            }
            if (nVentaM28 != null && bBtnM28 == false)
            {
                btnM28.BackColor = Color.RoyalBlue;
                btnM28.ForeColor = Color.White;
            }
            if (nVentaM29 != null && bBtnM29 == false)
            {
                btnM29.BackColor = Color.RoyalBlue;
                btnM29.ForeColor = Color.White;
            }
            if (nVentaM30 != null && bBtnM30 == false)
            {
                btnM30.BackColor = Color.RoyalBlue;
                btnM30.ForeColor = Color.White;
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
            bBtnB10 = true;
            venta();
        }

        private void btnB11_Click(object sender, EventArgs e)
        {
            bBtnB11 = true;
            venta();
        }

        private void btnB12_Click(object sender, EventArgs e)
        {
            bBtnB12 = true;
            venta();
        }

        private void btnB13_Click(object sender, EventArgs e)
        {
            bBtnB13 = true;
            venta();
        }

        private void btnB14_Click(object sender, EventArgs e)
        {
            bBtnB14 = true;
            venta();
        }

        private void btnB15_Click(object sender, EventArgs e)
        {
            bBtnB15 = true;
            venta();
        }

        private void btnB16_Click(object sender, EventArgs e)
        {
            bBtnB16 = true;
            venta();
        }

        private void btnB17_Click(object sender, EventArgs e)
        {
            bBtnB17 = true;
            venta();
        }

        private void btnB18_Click(object sender, EventArgs e)
        {
            bBtnB18 = true;
            venta();
        }

        private void btnB19_Click(object sender, EventArgs e)
        {
            bBtnB19 = true;
            venta();
        }

        private void btnB20_Click(object sender, EventArgs e)
        {
            bBtnB20 = true;
            venta();
        }

        private void btnB21_Click(object sender, EventArgs e)
        {
            bBtnB21 = true;
            venta();
        }

        private void btnB22_Click(object sender, EventArgs e)
        {
            bBtnB22 = true;
            venta();
        }

        private void btnB23_Click(object sender, EventArgs e)
        {
            bBtnB23 = true;
            venta();
        }

        private void btnB24_Click(object sender, EventArgs e)
        {
            bBtnB24 = true;
            venta();
        }

        private void btnB25_Click(object sender, EventArgs e)
        {
            bBtnB25 = true;
            venta();
        }

        private void btnB26_Click(object sender, EventArgs e)
        {
            bBtnB26 = true;
            venta();
        }

        private void btnB27_Click(object sender, EventArgs e)
        {
            bBtnB27 = true;
            venta();
        }

        private void btnB28_Click(object sender, EventArgs e)
        {
            bBtnB28 = true;
            venta();
        }

        private void btnB29_Click(object sender, EventArgs e)
        {
            bBtnB29 = true;
            venta();
        }

        private void btnB30_Click(object sender, EventArgs e)
        {
            bBtnB30 = true;
            venta();
        }

        private void btnM10_Click(object sender, EventArgs e)
        {
            bBtnM10 = true;
            venta();
        }

        private void btnM11_Click(object sender, EventArgs e)
        {
            bBtnM11 = true;
            venta();
        }

        private void btnM12_Click(object sender, EventArgs e)
        {
            bBtnM12 = true;
            venta();
        }

        private void btnM13_Click(object sender, EventArgs e)
        {
            bBtnM13 = true;
            venta();
        }

        private void btnM14_Click(object sender, EventArgs e)
        {
            bBtnM14 = true;
            venta();
        }

        private void btnM15_Click(object sender, EventArgs e)
        {
            bBtnM15 = true;
            venta();
        }

        private void btnM16_Click(object sender, EventArgs e)
        {
            bBtnM16 = true;
            venta();
        }

        private void btnM17_Click(object sender, EventArgs e)
        {
            bBtnM17 = true;
            venta();
        }

        private void btnM18_Click(object sender, EventArgs e)
        {
            bBtnM18 = true;
            venta();
        }

        private void btnM19_Click(object sender, EventArgs e)
        {
            bBtnM19 = true;
            venta();
        }

        private void btnM20_Click(object sender, EventArgs e)
        {
            bBtnM20 = true;
            venta();
        }

        private void btnM21_Click(object sender, EventArgs e)
        {
            bBtnM21 = true;
            venta();
        }

        private void btnM22_Click(object sender, EventArgs e)
        {
            bBtnM22 = true;
            venta();
        }

        private void btnM23_Click(object sender, EventArgs e)
        {
            bBtnM23 = true;
            venta();
        }

        private void btnM24_Click(object sender, EventArgs e)
        {
            bBtnM24 = true;
            venta();
        }

        private void btnM25_Click(object sender, EventArgs e)
        {
            bBtnM25 = true;
            venta();
        }

        private void btnM26_Click(object sender, EventArgs e)
        {
            bBtnM26 = true;
            venta();
        }

        private void btnM27_Click(object sender, EventArgs e)
        {
            bBtnM27 = true;
            venta();
        }

        private void btnM28_Click(object sender, EventArgs e)
        {
            bBtnM28 = true;
            venta();
        }

        private void btnM29_Click(object sender, EventArgs e)
        {
            bBtnM29 = true;
            venta();
        }

        private void btnM30_Click(object sender, EventArgs e)
        {
            bBtnM30 = true;
            venta();
        }
    }
}

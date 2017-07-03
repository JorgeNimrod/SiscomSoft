using System;
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
    public partial class FrmKeyboard : Form
    {
        Boolean mayus = false;
        string teclado;
        public FrmKeyboard()
        {
            InitializeComponent();
        }

        private void FrmKeyboard_Load(object sender, EventArgs e)
        {

        }

        private void btnCloseKeyboard_Click_1(object sender, EventArgs e)
        {
            this.Close();
            txtTeclado.Text = teclado;
        }

        private void btnEscape_MouseMove(object sender, MouseEventArgs e)
        {
            btnEscape.BackColor = Color.DarkCyan;
        }

        private void btnEscape_MouseLeave(object sender, EventArgs e)
        {
            btnEscape.BackColor = Color.White;
        }

        private void btnNumero1_MouseMove(object sender, MouseEventArgs e)
        {
            btnNumero1.BackColor = Color.DarkCyan;
        }

        private void btnNumero1_MouseLeave(object sender, EventArgs e)
        {
            btnNumero1.BackColor = Color.White;
        }

        private void btnNumero2_MouseMove(object sender, MouseEventArgs e)
        {
            btnNumero2.BackColor = Color.DarkCyan;
        }

        private void btnNumero2_MouseLeave(object sender, EventArgs e)
        {
            btnNumero2.BackColor = Color.White;
        }

        private void btnNumero3_MouseMove(object sender, MouseEventArgs e)
        {
            btnNumero3.BackColor = Color.DarkCyan;
        }

        private void btnNumero3_MouseLeave(object sender, EventArgs e)
        {
            btnNumero3.BackColor = Color.White;
        }

        private void btnNumero4_MouseMove(object sender, MouseEventArgs e)
        {
            btnNumero4.BackColor = Color.DarkCyan;
        }

        private void btnNumero4_MouseLeave(object sender, EventArgs e)
        {
            btnNumero4.BackColor = Color.White;
        }

        private void btnNumero6_MouseMove(object sender, MouseEventArgs e)
        {
            btnNumero6.BackColor = Color.DarkCyan;
        }

        private void btnNumero6_MouseLeave(object sender, EventArgs e)
        {
            btnNumero6.BackColor = Color.White;
        }

        private void btnNumero5_MouseMove(object sender, MouseEventArgs e)
        {
            btnNumero5.BackColor = Color.DarkCyan;
        }

        private void btnNumero5_MouseLeave(object sender, EventArgs e)
        {
            btnNumero5.BackColor = Color.White;
        }

        private void btnNumero7_MouseMove(object sender, MouseEventArgs e)
        {
            btnNumero7.BackColor = Color.DarkCyan;
        }

        private void btnNumero7_MouseLeave(object sender, EventArgs e)
        {
            btnNumero7.BackColor = Color.White;
        }

        private void btnNumero8_MouseMove(object sender, MouseEventArgs e)
        {
            btnNumero8.BackColor = Color.DarkCyan;
        }

        private void btnNumero8_MouseLeave(object sender, EventArgs e)
        {
            btnNumero8.BackColor = Color.White;
        }

        private void btnNumero9_MouseMove(object sender, MouseEventArgs e)
        {
            btnNumero9.BackColor = Color.DarkCyan;
        }

        private void btnNumero9_MouseLeave(object sender, EventArgs e)
        {
            btnNumero9.BackColor = Color.White;
        }

        private void btnNumero0_MouseMove(object sender, MouseEventArgs e)
        {
            btnNumero0.BackColor = Color.DarkCyan;
        }

        private void btnNumero0_MouseLeave(object sender, EventArgs e)
        {
            btnNumero0.BackColor = Color.White;
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            button4.BackColor = Color.DarkCyan;
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            button3.BackColor = Color.DarkCyan;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.White;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;
        }

        private void btnBack_MouseMove(object sender, MouseEventArgs e)
        {
            btnBack.BackColor = Color.DarkCyan;
        }

        private void btnBack_MouseLeave(object sender, EventArgs e)
        {
            btnBack.BackColor = Color.White;
        }

        private void btnTab_MouseMove(object sender, MouseEventArgs e)
        {
            btnTab.BackColor = Color.DarkCyan;
        }

        private void btnTab_MouseLeave(object sender, EventArgs e)
        {
            btnTab.BackColor = Color.White;
        }

        private void btnQ_MouseMove(object sender, MouseEventArgs e)
        {
            btnQ.BackColor = Color.DarkCyan;
        }

        private void btnQ_MouseLeave(object sender, EventArgs e)
        {
            btnQ.BackColor = Color.White;
        }

        private void btnW_MouseMove(object sender, MouseEventArgs e)
        {
            btnW.BackColor = Color.DarkCyan;
        }

        private void btnW_MouseLeave(object sender, EventArgs e)
        {
            btnW.BackColor = Color.White;
        }

        private void btnE_MouseMove(object sender, MouseEventArgs e)
        {
            btnE.BackColor = Color.DarkCyan;
        }

        private void btnE_MouseLeave(object sender, EventArgs e)
        {
            btnE.BackColor = Color.White;
        }

        private void btnR_MouseMove(object sender, MouseEventArgs e)
        {
            btnR.BackColor = Color.DarkCyan;
        }

        private void btnR_MouseLeave(object sender, EventArgs e)
        {
            btnR.BackColor = Color.White;
        }

        private void btnT_MouseMove(object sender, MouseEventArgs e)
        {
            btnT.BackColor = Color.DarkCyan;
        }

        private void btnT_MouseLeave(object sender, EventArgs e)
        {
            btnT.BackColor = Color.White;

        }

        private void btnY_MouseMove(object sender, MouseEventArgs e)
        {
            btnY.BackColor = Color.DarkCyan;
        }

        private void btnU_MouseMove(object sender, MouseEventArgs e)
        {
            btnU.BackColor = Color.DarkCyan;
        }

        private void btnY_MouseLeave(object sender, EventArgs e)
        {
            btnY.BackColor = Color.White;
        }

        private void btnU_MouseLeave(object sender, EventArgs e)
        {
            btnU.BackColor = Color.White;
        }

        private void btnI_MouseMove(object sender, MouseEventArgs e)
        {
            btnI.BackColor = Color.DarkCyan;
        }

        private void btnI_MouseLeave(object sender, EventArgs e)
        {
            btnI.BackColor = Color.White;
        }

        private void btnO_MouseMove(object sender, MouseEventArgs e)
        {
            btnO.BackColor = Color.DarkCyan;
        }

        private void btnO_MouseLeave(object sender, EventArgs e)
        {
            btnO.BackColor = Color.White;
        }

        private void btnP_MouseMove(object sender, MouseEventArgs e)
        {
            btnP.BackColor = Color.DarkCyan;
        }

        private void btnP_MouseLeave(object sender, EventArgs e)
        {
            btnP.BackColor = Color.White;
        }

        private void btnComilla_MouseMove(object sender, MouseEventArgs e)
        {
            btnComilla.BackColor = Color.DarkCyan;
        }

        private void btnComilla_MouseLeave(object sender, EventArgs e)
        {
            btnComilla.BackColor = Color.White;
        }

        private void btnInterrogacionabajo_MouseMove(object sender, MouseEventArgs e)
        {
            btnInterrogacionabajo.BackColor = Color.DarkCyan;
        }

        private void btnInterrogacionabajo_MouseLeave(object sender, EventArgs e)
        {
            btnInterrogacionabajo.BackColor = Color.White;
        }

        private void btnArroba_MouseMove(object sender, MouseEventArgs e)
        {
            btnArroba.BackColor = Color.DarkCyan;
        }

        private void btnArroba_MouseLeave(object sender, EventArgs e)
        {
            btnArroba.BackColor = Color.White;
        }

        private void button42_MouseMove(object sender, MouseEventArgs e)
        {
            button42.BackColor = Color.DarkCyan;
        }

        private void button42_MouseLeave(object sender, EventArgs e)
        {
            button42.BackColor = Color.White;
        }

        private void btnA_MouseMove(object sender, MouseEventArgs e)
        {
            btnA.BackColor = Color.DarkCyan;
        }

        private void btnA_MouseLeave(object sender, EventArgs e)
        {
            btnA.BackColor = Color.White;
        }

        private void btnS_MouseMove(object sender, MouseEventArgs e)
        {
            btnS.BackColor = Color.DarkCyan;
        }

        private void btnS_MouseLeave(object sender, EventArgs e)
        {
            btnS.BackColor = Color.White;
        }

        private void btnD_MouseMove(object sender, MouseEventArgs e)
        {
            btnD.BackColor = Color.DarkCyan;
        }

        private void btnD_MouseLeave(object sender, EventArgs e)
        {
            btnD.BackColor = Color.White;
        }

        private void btnF_MouseMove(object sender, MouseEventArgs e)
        {
            btnF.BackColor = Color.DarkCyan;
        }

        private void btnF_MouseLeave(object sender, EventArgs e)
        {
            btnF.BackColor = Color.White;
        }

        private void btnG_MouseMove(object sender, MouseEventArgs e)
        {
            btnG.BackColor = Color.DarkCyan;
        }

        private void btnG_MouseLeave(object sender, EventArgs e)
        {
            btnG.BackColor = Color.White;
        }

        private void btnH_MouseMove(object sender, MouseEventArgs e)
        {
            btnH.BackColor = Color.DarkCyan;
        }

        private void btnH_MouseLeave(object sender, EventArgs e)
        {
            btnH.BackColor = Color.White;
        }

        private void btnJ_MouseMove(object sender, MouseEventArgs e)
        {
            btnJ.BackColor = Color.DarkCyan;
        }

        private void btnJ_MouseLeave(object sender, EventArgs e)
        {
            btnJ.BackColor = Color.White;
        }

        private void btnK_MouseMove(object sender, MouseEventArgs e)
        {
            btnK.BackColor = Color.DarkCyan;
        }

        private void btnK_MouseLeave(object sender, EventArgs e)
        {
            btnK.BackColor = Color.White;
        }

        private void btnL_MouseMove(object sender, MouseEventArgs e)
        {
            btnL.BackColor = Color.DarkCyan;
        }

        private void btnL_MouseLeave(object sender, EventArgs e)
        {
            btnL.BackColor = Color.White;
        }

        private void btnÑ_MouseMove(object sender, MouseEventArgs e)
        {
            btnÑ.BackColor = Color.DarkCyan;
        }

        private void btnÑ_MouseLeave(object sender, EventArgs e)
        {
            btnÑ.BackColor = Color.White;
        }

        private void btnCorcheteizq_MouseMove(object sender, MouseEventArgs e)
        {
            btnCorcheteizq.BackColor = Color.DarkCyan;
        }

        private void btnCorcheteizq_MouseLeave(object sender, EventArgs e)
        {
            btnCorcheteizq.BackColor = Color.White;
        }

      

        private void btnMayusIzqu_MouseMove(object sender, MouseEventArgs e)
        {
            btnMayusIzqu.BackColor = Color.DarkCyan;
        }

        private void btnMayusIzqu_MouseLeave(object sender, EventArgs e)
        {
            btnMayusIzqu.BackColor = Color.White;
        }

        private void btnEnter_MouseMove(object sender, MouseEventArgs e)
        {
            btnEnter.BackColor = Color.DarkCyan;
        }

        private void btnEnter_MouseLeave(object sender, EventArgs e)
        {
            btnEnter.BackColor = Color.White;
        }

        private void btnZ_MouseMove(object sender, MouseEventArgs e)
        {
            btnZ.BackColor = Color.DarkCyan;
        }

        private void btnX_MouseMove(object sender, MouseEventArgs e)
        {
            btnX.BackColor = Color.DarkCyan;
        }

        private void btnX_MouseLeave(object sender, EventArgs e)
        {
            btnX.BackColor = Color.White;
        }

        private void btnC_MouseMove(object sender, MouseEventArgs e)
        {
            btnC.BackColor = Color.DarkCyan;
        }

        private void btnC_MouseLeave(object sender, EventArgs e)
        {
            btnC.BackColor = Color.White;
        }

        private void btnV_MouseMove(object sender, MouseEventArgs e)
        {
            btnV.BackColor = Color.DarkCyan;
        }

        private void btnV_MouseLeave(object sender, EventArgs e)
        {
            btnV.BackColor = Color.White;
        }

        private void btnB_MouseMove(object sender, MouseEventArgs e)
        {
            btnB.BackColor = Color.DarkCyan;
        }

        private void btnB_MouseLeave(object sender, EventArgs e)
        {
            btnB.BackColor = Color.White;
        }

   
        private void btnN_MouseMove_1(object sender, MouseEventArgs e)
        {
            btnN.BackColor = Color.DarkCyan;
        }

        private void btnN_MouseLeave(object sender, EventArgs e)
        {
            btnN.BackColor = Color.White;
        }

        private void btnM_MouseMove(object sender, MouseEventArgs e)
        {
            btnM.BackColor = Color.DarkCyan;
        }

        private void btnM_MouseLeave(object sender, EventArgs e)
        {
            btnM.BackColor = Color.White;
        }

        private void btnCorcheteDerech_MouseMove(object sender, MouseEventArgs e)
        {
            btnCorcheteDerech.BackColor = Color.DarkCyan;
        }

        private void btnCorcheteDerech_MouseLeave(object sender, EventArgs e)
        {
            btnCorcheteDerech.BackColor = Color.White;
        }

        private void button50_MouseMove(object sender, MouseEventArgs e)
        {
            button50.BackColor = Color.DarkCyan;
        }

        private void button50_MouseLeave(object sender, EventArgs e)
        {
            button50.BackColor = Color.White;
        }

        private void btncoma_MouseMove(object sender, MouseEventArgs e)
        {
            btncoma.BackColor = Color.DarkCyan;
        }

        private void btncoma_MouseLeave(object sender, EventArgs e)
        {
            btncoma.BackColor = Color.White;
        }

        private void btnPunto_MouseMove(object sender, MouseEventArgs e)
        {
            btnPunto.BackColor = Color.DarkCyan;
        }

        private void btnPunto_MouseLeave(object sender, EventArgs e)
        {
            btnPunto.BackColor = Color.White;
        }

        private void btnMayusDere_MouseMove(object sender, MouseEventArgs e)
        {
            btnMayusDere.BackColor = Color.DarkCyan;
        }

        private void btnMayusDere_MouseLeave(object sender, EventArgs e)
        {
            btnMayusDere.BackColor = Color.White;
        }

        private void btnUp_MouseMove(object sender, MouseEventArgs e)
        {
            btnUp.BackColor = Color.DarkCyan;
        }

        private void btnUp_MouseLeave(object sender, EventArgs e)
        {
            btnUp.BackColor = Color.White;
        }

        private void btnDown_MouseMove(object sender, MouseEventArgs e)
        {
            btnDown.BackColor = Color.DarkCyan;
        }

        private void btnDown_MouseLeave(object sender, EventArgs e)
        {
            btnDown.BackColor = Color.White;
        }
               
        private void btnAltGr_MouseMove(object sender, MouseEventArgs e)
        {
            btnAltGr.BackColor = Color.DarkCyan;
        }

        private void btnAltGr_MouseLeave(object sender, EventArgs e)
        {
            btnAltGr.BackColor = Color.White;
        }

        private void btnZ_MouseLeave(object sender, EventArgs e)
        {
            btnZ.BackColor = Color.White;
        }

        private void btnNumero1_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "!");
                txtTeclado.Text = teclado;
            }
            else
            {
            teclado = Convert.ToString(txtTeclado.Text + 1);
            txtTeclado.Text = teclado; 
               
            }


        }

        private void btnNumero2_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + 2);
                txtTeclado.Text = teclado;

            }

        }

        private void btnNumero3_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "#");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + 3);
                txtTeclado.Text = teclado;

            }
        }

        private void btnNumero4_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "$");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + 4);
                txtTeclado.Text = teclado;

            }
        }

        private void btnNumero5_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "%");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + 5);
                txtTeclado.Text = teclado;

            }
        }

        private void btnNumero6_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + 6);
                txtTeclado.Text = teclado;

            }
        }

        private void btnNumero7_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "/");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + 7);
                txtTeclado.Text = teclado;

            }
        }

        private void btnNumero8_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "(");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + 8);
                txtTeclado.Text = teclado;

            }
        }

        private void btnNumero9_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + ")");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + 9);
                txtTeclado.Text = teclado;

            }
        }

        private void btnNumero0_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "=");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + 0);
                txtTeclado.Text = teclado;

            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
          
          teclado.Remove(teclado.Length - 1);
            txtTeclado.Text = teclado;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            teclado = Convert.ToString(txtTeclado.Text + "-");
            txtTeclado.Text = teclado;
        }

        private void btnQ_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "q");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + "Q");
                txtTeclado.Text = teclado;
            }
        }

        private void btnW_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "w");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + "W");
                txtTeclado.Text = teclado;
            }
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "e");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + "E");
                txtTeclado.Text = teclado;
            }
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "r");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + "R");
                txtTeclado.Text = teclado;
            }
        }

        private void btnT_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "t");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + "T");
                txtTeclado.Text = teclado;
            }
        }

        private void btnY_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "y");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + "Y");
                txtTeclado.Text = teclado;
            }
        }

        private void btnU_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "u");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + "U");
                txtTeclado.Text = teclado;
            }
        }

        private void btnI_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "i");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + "I");
                txtTeclado.Text = teclado;
            }
        }

        private void btnO_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "o");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + "O");
                txtTeclado.Text = teclado;
            }
        }

        private void btnP_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "p");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + "P");
                txtTeclado.Text = teclado;
            }
        }

        private void btnComilla_Click(object sender, EventArgs e)
        {
            teclado = Convert.ToString(txtTeclado.Text + "'");
            txtTeclado.Text = teclado;
        }

        private void btnInterrogacionabajo_Click(object sender, EventArgs e)
        {
            teclado = Convert.ToString(txtTeclado.Text + "¿");
            txtTeclado.Text = teclado;
        }

        private void btnArroba_Click(object sender, EventArgs e)
        {
            teclado = Convert.ToString(txtTeclado.Text + "@");
            txtTeclado.Text = teclado;
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "a");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + "A");
                txtTeclado.Text = teclado;
            }
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "s");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + "S");
                txtTeclado.Text = teclado;
            }
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "d");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + "D");
                txtTeclado.Text = teclado;
            }
        }

        private void btnF_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "f");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + "F");
                txtTeclado.Text = teclado;
            }
        }

        private void btnG_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "g");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + "G");
                txtTeclado.Text = teclado;
            }
        }

        private void btnH_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "h");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + "H");
                txtTeclado.Text = teclado;
            }
        }

        private void btnJ_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "j");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + "J");
                txtTeclado.Text = teclado;
            }
        }

        private void btnK_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "k");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + "K");
                txtTeclado.Text = teclado;
            }
        }

        private void btnL_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "l");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + "L");
                txtTeclado.Text = teclado;
            }
        }

        private void btnÑ_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "ñ");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + "Ñ");
                txtTeclado.Text = teclado;
            }
        }

        private void btnCorcheteizq_Click(object sender, EventArgs e)
        {
            teclado = Convert.ToString(txtTeclado.Text + "{");
            txtTeclado.Text = teclado;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {

        }

        private void btnZ_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "z");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + "Z");
                txtTeclado.Text = teclado;
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "x");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + "X");
                txtTeclado.Text = teclado;
            }
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "c");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + "C");
                txtTeclado.Text = teclado;
            }
        }

        private void btnV_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "v");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + "V");
                txtTeclado.Text = teclado;
            }
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "b");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + "B");
                txtTeclado.Text = teclado;
            }
        }

        private void btnN_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "n");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + "N");
                txtTeclado.Text = teclado;
            }
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            if (mayus == true)
            {

                teclado = Convert.ToString(txtTeclado.Text + "m");
                txtTeclado.Text = teclado;
            }
            else
            {
                teclado = Convert.ToString(txtTeclado.Text + "M");
                txtTeclado.Text = teclado;
            }
        }

        private void btnCorcheteDerech_Click(object sender, EventArgs e)
        {
            teclado = Convert.ToString(txtTeclado.Text + "}");
            txtTeclado.Text = teclado;
        }

        private void button50_Click(object sender, EventArgs e)
        {
            teclado = Convert.ToString(txtTeclado.Text + "|");
            txtTeclado.Text = teclado;
        }

        private void btncoma_Click(object sender, EventArgs e)
        {
            teclado = Convert.ToString(txtTeclado.Text + ",");
            txtTeclado.Text = teclado;
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            teclado = Convert.ToString(txtTeclado.Text + ".");
            txtTeclado.Text = teclado;
        }

        private void btnEspacio_Click(object sender, EventArgs e)
        {
            teclado = Convert.ToString(txtTeclado.Text + " ");
            txtTeclado.Text = teclado;
        }

        private void btnMayusIzqu_Click(object sender, EventArgs e)
        {
            if (mayus == false)
            {
                btnNumero1.Text = "!";
                btnNumero2.Text = "¨";
                btnNumero3.Text = "#";
                btnNumero4.Text = "$";
                btnNumero5.Text = "%";
                btnNumero6.Text = @"&";
                btnNumero7.Text = "/";
                btnNumero8.Text = "(";
                btnNumero9.Text = ")";
                btnNumero0.Text = "=";
                btnComilla.Text = "?";
                btnInterrogacionabajo.Text = "¡";
                btnArroba.Text = "$";
                button50.Text = "°";
                btncoma.Text = ":";
                btnPunto.Text = ";";
                btnCorcheteizq.Text = "[";
                btnCorcheteDerech.Text = "]";
                btnQ.Text = "q"; btnG.Text = "g";
                btnW.Text = "w"; btnH.Text = "h";
                btnE.Text = "e"; btnJ.Text = "j";
                btnR.Text = "r"; btnK.Text = "k";
                btnT.Text = "t"; btnL.Text = "l";
                btnY.Text = "y"; btnÑ.Text = "ñ";
               btnZ.Text = "z";  btnO.Text = "o";
                btnU.Text = "u"; btnX.Text = "x";
                btnI.Text = "i"; btnC.Text = "c";
                btnP.Text = "p"; btnV.Text = "v";
                btnA.Text = "a"; btnB.Text = "b";
                btnS.Text = "s"; btnN.Text = "n";
                btnD.Text = "d"; btnM.Text = "m";
                btnF.Text = "f";
                
                mayus = true;
               
            }
            else
            {
                btnNumero1.Text = "1";
                btnNumero2.Text = "2";
                btnNumero3.Text = "3";
                btnNumero4.Text = "4";
                btnNumero5.Text = "5";
                btnNumero6.Text = "6";
                btnNumero7.Text = "7";
                btnNumero8.Text = "8";
                btnNumero9.Text = "9";
                btnNumero0.Text = "0";
                btnComilla.Text = "'";
                btnInterrogacionabajo.Text = "¿";
                btnArroba.Text = "@";
                button50.Text = "|";
                btncoma.Text = ",";
                btnPunto.Text = ".";
                btnCorcheteizq.Text = "{";
                btnCorcheteDerech.Text = "}";
                btnQ.Text = "Q"; btnG.Text = "G";
                btnW.Text = "W"; btnH.Text = "H";
                btnE.Text = "E"; btnJ.Text = "J";
                btnR.Text = "R"; btnK.Text = "K"; 
                btnT.Text = "T"; btnL.Text = "L";
                btnY.Text = "Y"; btnÑ.Text = "Ñ";
                btnO.Text = "O"; btnZ.Text = "Z";
                btnU.Text = "U"; btnX.Text = "X";
                btnI.Text = "I"; btnC.Text = "C";
                btnP.Text = "P"; btnV.Text = "V";
                btnA.Text = "A"; btnB.Text = "B";
                btnS.Text = "S"; btnN.Text = "N";
                btnD.Text = "D"; btnM.Text = "M";
                btnF.Text = "F";

                mayus = false;

            }
        }
    }
}

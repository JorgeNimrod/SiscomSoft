using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmSplahScreen : Form
    {
        ProgressBar pb = new ProgressBar();
        System.Threading.Timer t;
        public FrmSplahScreen()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            FrmLogin v = new FrmLogin();
            while (pb.Value < pb.Minimum)
            {
                pb.Value += 1;
            }
            if (pb.Value == pb.Minimum)
            {
                this.Opacity = this.Opacity - .01;
                if (this.Opacity==0)
                {
                    timer1.Stop();
                    this.Hide();
                    v.Show();
                }
            }
        }

        private void FrmSplahScreen_Load(object sender, EventArgs e)
        {
            pb.Visible = false;
            pb.Value = 0;
            pb.Maximum = 3000;
            pb.Minimum = 0;
            timer1.Start();
            timer1.Interval = 1;
            timer2.Start();
            timer2.Interval = 1000;
        }
    }
}

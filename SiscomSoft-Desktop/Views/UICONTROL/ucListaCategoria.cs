using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SiscomSoft.Models;
using SiscomSoft.Controller;

namespace SiscomSoft_Desktop.Views.UICONTROL
{
    public partial class ucListaCategoria : UserControl
    {
        Categoria nCategoria;
        public static int pkCategoriaUI;

        public ucListaCategoria(Categoria uiCategoria)
        {
            InitializeComponent();
            nCategoria = uiCategoria;
        }

        private void ucListaCategoria_Load(object sender, EventArgs e)
        {
            btnCategoria.Text = nCategoria.sNombre;
            pkCategoriaUI = nCategoria.pkCategoria;
        }
    }
}

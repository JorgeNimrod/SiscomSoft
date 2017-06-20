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
        public static int pkCategoriaUI;
        Categoria vCategoria;

        public ucListaCategoria(Categoria ucCategoria)
        {
            InitializeComponent();
            vCategoria = ucCategoria;
        }

        private void ucListaCategoria_Load(object sender, EventArgs e)
        {
            btnCategorias.Text = vCategoria.sNombre;
            pkCategoriaUI = vCategoria.pkCategoria;
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
        }
    }
}

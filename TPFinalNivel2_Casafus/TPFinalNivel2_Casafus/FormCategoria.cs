using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace TPFinalNivel2_Casafus
{
    public partial class FormCategoria : Form
    {

        private List<Categoria> listaCategorias;

        public FormCategoria()
        {
            InitializeComponent();
        }

        private void FormCategoria_Load(object sender, EventArgs e)
        {
            cargarCategorias();
        }
        private void cargarCategorias()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            listaCategorias = negocio.listar("");
            dgvCategorias.DataSource = listaCategorias;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            try
            {
                if (txtBuscar.Text == "")
                {
                    listaCategorias = negocio.listar("");
                }
                else
                {
                    listaCategorias = negocio.listar(txtBuscar.Text);
                }
                dgvCategorias.DataSource = listaCategorias;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

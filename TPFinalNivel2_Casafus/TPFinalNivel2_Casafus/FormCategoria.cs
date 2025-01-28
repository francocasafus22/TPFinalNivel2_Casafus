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
            dgvCategoria.DataSource = listaCategorias;            

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
                dgvCategoria.DataSource = listaCategorias;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void pbAgregar_Click(object sender, EventArgs e)
        {
            FormCategoriaAgregar form = new FormCategoriaAgregar();
            form.ShowDialog();
            cargarCategorias();
        }

        private void pbModificar_Click(object sender, EventArgs e)
        {
            Categoria seleccionado = new Categoria();
            seleccionado = (Categoria)dgvCategoria.CurrentRow.DataBoundItem;
            FormCategoriaAgregar form = new FormCategoriaAgregar(seleccionado);
            form.ShowDialog();
            cargarCategorias();
        }
    }
}

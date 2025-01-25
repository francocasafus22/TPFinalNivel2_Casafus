using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;

namespace TPFinalNivel2_Casafus
{
    public partial class FormArticulo : Form
    {

        private List<Articulo> listaArticulos;

        public FormArticulo()
        {
            InitializeComponent();
        }

        private void FormArticulo_Load(object sender, EventArgs e)
        {
            cargarArticulo();
        }

        private void cargarArticulo()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulos = negocio.listar();
            dgvArticulos.DataSource = listaArticulos;
            dgvArticulos.Columns["Imagen"].Visible = false;
            dgvArticulos.Columns["Id"].Visible = false;
            

        }
        
        public void cargarImagen(string imagen)
        {
            try
            {
                pbArticulo.Load(imagen);
            }
            catch (Exception)
            {
                pbArticulo.Load("https://www.thermaxglobal.com/wp-content/uploads/2020/05/image-not-found.jpg");
            }
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.Imagen);
            }
        }

        private void pbAgregar_Click(object sender, EventArgs e)
        {
            FormAgregarArticulo form = new FormAgregarArticulo();
            form.ShowDialog();
            cargarArticulo();
        }

        private void pbAgregar_MouseMove(object sender, MouseEventArgs e)
        {
            pbAgregar.Cursor = Cursors.Hand;
        }

        private void pbBorrar_MouseMove(object sender, MouseEventArgs e)
        {
            pbBorrar.Cursor = Cursors.Hand;
        }

        private void pbModificar_MouseMove(object sender, MouseEventArgs e)
        {
            pbModificar.Cursor = Cursors.Hand;
        }

        private void pbBorrar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            DialogResult resultado =  MessageBox.Show("¿Está seguro que desea borrar el artículo seleccionado?", "Borrar", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                if (dgvArticulos.CurrentRow != null)
                {
                    Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    negocio.borrarArticulo(seleccionado.Id);
                    cargarArticulo();
                }

            }

        }

        private void pbModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = new Articulo();
            seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            FormAgregarArticulo form = new FormAgregarArticulo(seleccionado);
            form.ShowDialog();
            cargarArticulo();
            

        }
    }
}

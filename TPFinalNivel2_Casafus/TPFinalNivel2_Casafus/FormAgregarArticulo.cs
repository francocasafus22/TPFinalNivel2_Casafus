using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace TPFinalNivel2_Casafus
{
    public partial class FormAgregarArticulo : Form
    {
        private Articulo articulo = null;

        // Importa la función de user32.dll
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public FormAgregarArticulo()
        {
            InitializeComponent();
        }
        public FormAgregarArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }

        private void FormAgregarArticulo_Load(object sender, EventArgs e)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();

            try
            {
                cbCategoria.DataSource = categoriaNegocio.listar("");
                cbCategoria.ValueMember = "Id";
                cbCategoria.DisplayMember = "Descripcion";
                cbMarca.DataSource = marcaNegocio.listar("");
                cbMarca.ValueMember = "Id";
                cbMarca.DisplayMember = "Descripcion";


                if (articulo != null)
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtImagen.Text = articulo.Imagen;
                    txtPrecio.Text = articulo.Precio.ToString();
                    cbCategoria.SelectedValue = articulo.Categoria.Id;
                    cbMarca.SelectedValue = articulo.Marca.Id;
                    cargarImagen();

                }

                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void cargarImagen()
        {
            try
            {
                pbImagen.Load(txtImagen.Text);
            }
            catch (Exception)
            {

                pbImagen.Load("https://fatty.pm.epages.com/themes/epages.base/assets/images/placeholder_900-2020f2c24e1d2e596916.jpg");
            }
        }

        private void txtImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                if (articulo == null)
                    articulo = new Articulo();

                    articulo.Codigo = txtCodigo.Text;
                    articulo.Nombre = txtNombre.Text;
                    articulo.Descripcion = txtDescripcion.Text;
                    articulo.Imagen = txtImagen.Text;
                    articulo.Precio = decimal.Parse(txtPrecio.Text);
                    articulo.Marca = (Marca)cbMarca.SelectedItem;
                    articulo.Categoria = (Categoria)cbCategoria.SelectedItem;
                

                if (articulo.Id == 0)
                {
                    negocio.agregarArticulo(articulo);
                    MessageBox.Show("Artículo agregado correctamente");

                }
                else
                {
                    negocio.modificarArticulo(articulo);
                    MessageBox.Show("Artículo modificado correctamente");
                }
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }
    }
}

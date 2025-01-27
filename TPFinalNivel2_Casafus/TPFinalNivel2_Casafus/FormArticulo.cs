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

            try
            {
                cargarArticulo();
                cb1.Items.Add("Codigo");
                cb1.Items.Add("Nombre");
                cb1.Items.Add("Precio");

                cbBusqueda1.Items.Add("Categoria");
                cbBusqueda1.Items.Add("Marca");

            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        private void cargarArticulo()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulos = negocio.listar(""); // Se le pasa un string vacío para que no filtre por nada
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
                pbArticulo.Load("https://fatty.pm.epages.com/themes/epages.base/assets/images/placeholder_900-2020f2c24e1d2e596916.jpg");
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> listaFiltrada;

            if (validarFiltros())
                return;

            if (cb2.SelectedItem == null)
            {
                listaFiltrada = negocio.listar(txtBuscar.Text);
            }
            else
            {
                listaFiltrada = negocio.busquedaFiltrada(txtBuscar.Text, cb1.SelectedItem.ToString(), cb2.SelectedItem.ToString());
            }

            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.Columns["Imagen"].Visible = false;
            dgvArticulos.Columns["Id"].Visible = false;

        }

        private void cb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb2.Items.Clear();
            ArticuloNegocio negocio = new ArticuloNegocio();

            if (cb1.SelectedItem.ToString() == "Precio")
            {
                cb2.Items.Add("Mayor a");
                cb2.Items.Add("Menor a");
                cb2.Items.Add("Igual a");
            }
            else
            {
                cb2.Items.Add("Comienza con");
                cb2.Items.Add("Termina con");
                cb2.Items.Add("Contiene");
            }
        }


        private void cbBusqueda1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbBusqueda1.SelectedItem?.ToString() == "Categoria")
                {
                    CategoriaNegocio negocio = new CategoriaNegocio();
                    cbBusqueda2.DataSource = negocio.listar("");
                    cbBusqueda2.ValueMember = "Id";
                    cbBusqueda2.DisplayMember = "Descripcion";
                    cbBusqueda2.SelectedIndex = -1;
                }
                else if (cbBusqueda1.SelectedItem?.ToString() == "Marca")
                {
                    MarcaNegocio negocio = new MarcaNegocio();
                    cbBusqueda2.DataSource = negocio.listar("");
                    cbBusqueda2.ValueMember = "Id";
                    cbBusqueda2.DisplayMember = "Descripcion";
                    cbBusqueda2.SelectedIndex = -1;
                    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> listaFiltrada;
            listaFiltrada = negocio.busquedaFiltrada("", cbBusqueda1.SelectedItem.ToString(), cbBusqueda2.SelectedItem.ToString());
            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.Columns["Imagen"].Visible = false;
            dgvArticulos.Columns["Id"].Visible = false;
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            dgvArticulos.DataSource = negocio.listar("");
            cbBusqueda1.SelectedIndex = -1;
            cbBusqueda2.SelectedIndex = -1;
            cbBusqueda2.DataSource = null;
        }
        private bool soloNumeros(string texto)
        {
            foreach (char letra in texto)
            {
                if (!char.IsNumber(letra))
                {
                    return false;
                }
            }

            return true;
        } 
        private bool validarFiltros()
        {
            
                if (cb1.SelectedItem?.ToString() == "Precio")
                {
                    if (!(soloNumeros(txtBuscar.Text)))
                    {
                        MessageBox.Show("El campo de precio solo admite números");
                        txtBuscar.Text = "";
                        return true;
                    }
                }
            

            return false;

        }
    }
}

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
    public partial class FormMarca : Form
    {
        public FormMarca()
        {
            InitializeComponent();
        }

        private void FormMarca_Load(object sender, EventArgs e)
        {
            cargarMarcas();
        }
        private void cargarMarcas()
        {
            MarcaNegocio negocio = new MarcaNegocio();
            List<Marca> lista = negocio.listar("");
            dgvMarcas.DataSource = lista;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();  
            List<Marca> lista;

            if (txtBuscar.Text == "")
            {
                lista = negocio.listar("");
            }
            else
            {
                lista = negocio.listar(txtBuscar.Text);
            }
            dgvMarcas.DataSource = lista; 
        }

        private void pbAgregar_Click(object sender, EventArgs e)
        {
            FormMarcaAgregar form = new FormMarcaAgregar();
            form.ShowDialog();
            cargarMarcas();
        }

        private void pbModificar_Click(object sender, EventArgs e)
        {
            Marca seleccionado = new Marca();
            seleccionado = (Marca)dgvMarcas.CurrentRow.DataBoundItem;
            FormMarcaAgregar form = new FormMarcaAgregar(seleccionado);
            form.ShowDialog();
            cargarMarcas();
        }
    }
}

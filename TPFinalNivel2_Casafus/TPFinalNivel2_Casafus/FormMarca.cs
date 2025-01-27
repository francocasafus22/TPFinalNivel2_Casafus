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
    }
}

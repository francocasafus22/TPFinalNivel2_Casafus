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
            List<Marca> lista = negocio.listar();
            dgvMarcas.DataSource = lista;
        }

    }
}

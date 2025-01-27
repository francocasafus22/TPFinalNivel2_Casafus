using Negocio;
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

namespace TPFinalNivel2_Casafus
{
    public partial class FormMarcaAgregar : Form
    {
        // Importa la función de user32.dll
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        Marca marca = null;

        public FormMarcaAgregar()
        {
            InitializeComponent();
        }
        public FormMarcaAgregar(Marca marca)
        {
            this.marca = marca;
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();

            if(txtDescripcion.Text == "")
            {
                MessageBox.Show("Debe completar el campo Descripción");
                return;
            }

            try
            {      
                if (marca == null)
                    marca = new Marca();

                marca.Descripcion = txtDescripcion.Text;

                if (marca.Id == 0)
                {
                    negocio.Agregar(marca);
                    MessageBox.Show("Marca agregada correctamente");
                }
                else
                {
                    negocio.Modificar(marca);
                    MessageBox.Show("Marca modificada correctamente");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            Close();
        }

        private void FormCategoriaAgregar_Load(object sender, EventArgs e)
        {
            if(marca != null)
            {
                txtDescripcion.Text = marca.Descripcion;
            }
        }
    }
}

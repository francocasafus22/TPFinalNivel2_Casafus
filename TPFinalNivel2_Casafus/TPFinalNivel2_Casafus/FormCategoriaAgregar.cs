using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace TPFinalNivel2_Casafus
{
    public partial class FormCategoriaAgregar : Form
    {

        // Importa la función de user32.dll
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        Categoria categoria = null;

        public FormCategoriaAgregar()
        {
            InitializeComponent();
        }
        public FormCategoriaAgregar(Categoria categoria)
        {
            this.categoria = categoria;
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();

            if(txtDescripcion.Text == "")
            {
                MessageBox.Show("Debe completar el campo Descripción");
                return;
            }

            try
            {
                if (categoria == null)
                    categoria = new Categoria();

                categoria.Descripcion = txtDescripcion.Text;

                if (categoria.Id == 0)
                {
                    negocio.Agregar(categoria);
                    MessageBox.Show("Agregado correctamente");
                }
                else
                {
                    negocio.Modificar(categoria);
                    MessageBox.Show("Modificado correctamente");
                }
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void FormCategoriaAgregar_Load(object sender, EventArgs e)
        {
            if (categoria != null)
            {
                txtDescripcion.Text = categoria.Descripcion;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
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
    }
}

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
    public partial class Form1 : Form
    {

        // Importa la función de user32.dll
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormArticulo form = new FormArticulo();
            mostrarForm(form);           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            FormArticulo formArticulo = new FormArticulo();
            mostrarForm(formArticulo);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            FormCategoria form = new FormCategoria();
            mostrarForm(form);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            FormMarca form = new FormMarca();
            mostrarForm(form);
        }

        private void mostrarForm(Form form)
        {
            form.TopLevel = false;
            panelCentro.Controls.Clear();
            panelCentro.Controls.Add(form);
            form.Show();
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.ForeColor = Color.Gray;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            label2.ForeColor = Color.Gray;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.White;
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            label3.ForeColor = Color.Gray;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.White;
        }
    }
}

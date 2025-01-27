namespace TPFinalNivel2_Casafus
{
    partial class FormMarca
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMarca));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbAgregar = new System.Windows.Forms.PictureBox();
            this.pbModificar = new System.Windows.Forms.PictureBox();
            this.dgvMarcas = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAgregar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbModificar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.txtBuscar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1127, 100);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Noto Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(432, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 26);
            this.button1.TabIndex = 13;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(187, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.Gainsboro;
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font = new System.Drawing.Font("Noto Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(221, 37);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(194, 26);
            this.txtBuscar.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noto Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "Marcas";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pbAgregar);
            this.panel2.Controls.Add(this.pbModificar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 508);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1127, 81);
            this.panel2.TabIndex = 0;
            // 
            // pbAgregar
            // 
            this.pbAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAgregar.Image = ((System.Drawing.Image)(resources.GetObject("pbAgregar.Image")));
            this.pbAgregar.Location = new System.Drawing.Point(484, 19);
            this.pbAgregar.Name = "pbAgregar";
            this.pbAgregar.Size = new System.Drawing.Size(50, 50);
            this.pbAgregar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAgregar.TabIndex = 10;
            this.pbAgregar.TabStop = false;
            this.pbAgregar.Click += new System.EventHandler(this.pbAgregar_Click);
            // 
            // pbModificar
            // 
            this.pbModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbModificar.Image = ((System.Drawing.Image)(resources.GetObject("pbModificar.Image")));
            this.pbModificar.Location = new System.Drawing.Point(558, 19);
            this.pbModificar.Name = "pbModificar";
            this.pbModificar.Size = new System.Drawing.Size(50, 50);
            this.pbModificar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbModificar.TabIndex = 9;
            this.pbModificar.TabStop = false;
            this.pbModificar.Click += new System.EventHandler(this.pbModificar_Click);
            // 
            // dgvMarcas
            // 
            this.dgvMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarcas.Location = new System.Drawing.Point(325, 106);
            this.dgvMarcas.Name = "dgvMarcas";
            this.dgvMarcas.Size = new System.Drawing.Size(443, 377);
            this.dgvMarcas.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvMarcas);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1127, 589);
            this.panel6.TabIndex = 6;
            // 
            // FormMarca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 589);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMarca";
            this.Text = "FormMarca";
            this.Load += new System.EventHandler(this.FormMarca_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAgregar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbModificar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).EndInit();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvMarcas;
        private System.Windows.Forms.PictureBox pbAgregar;
        private System.Windows.Forms.PictureBox pbModificar;
        private System.Windows.Forms.Panel panel6;
    }
}
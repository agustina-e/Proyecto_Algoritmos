namespace Proyecto_Formulario
{
    partial class frmPrincipalGeneral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipalGeneral));
            lblBienvenida = new Label();
            btnCerrarSesion = new Button();
            btnEditarPerfil = new Button();
            lblNombreEquipo = new Label();
            txtNombreEquipo = new TextBox();
            lblCategoria = new Label();
            cboCategoria = new ComboBox();
            lblCantidadJugadores = new Label();
            cboCantidadJugadores = new ComboBox();
            btnInscribirme = new Button();
            lblEstado = new Label();
            btnGuardarEquipo = new Button();
            flpJugadores = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Location = new Point(49, 23);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(0, 15);
            lblBienvenida.TabIndex = 0;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(671, 19);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(117, 23);
            btnCerrarSesion.TabIndex = 1;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // btnEditarPerfil
            // 
            btnEditarPerfil.Location = new Point(540, 19);
            btnEditarPerfil.Name = "btnEditarPerfil";
            btnEditarPerfil.Size = new Size(125, 23);
            btnEditarPerfil.TabIndex = 2;
            btnEditarPerfil.Text = "Editar Perfil";
            btnEditarPerfil.UseVisualStyleBackColor = true;
            btnEditarPerfil.Click += btnEditarPerfil_Click;
            // 
            // lblNombreEquipo
            // 
            lblNombreEquipo.AutoSize = true;
            lblNombreEquipo.Location = new Point(49, 88);
            lblNombreEquipo.Name = "lblNombreEquipo";
            lblNombreEquipo.Size = new Size(110, 15);
            lblNombreEquipo.TabIndex = 3;
            lblNombreEquipo.Text = "Nombre del equipo";
            // 
            // txtNombreEquipo
            // 
            txtNombreEquipo.Location = new Point(235, 85);
            txtNombreEquipo.Name = "txtNombreEquipo";
            txtNombreEquipo.Size = new Size(295, 23);
            txtNombreEquipo.TabIndex = 4;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(49, 138);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(58, 15);
            lblCategoria.TabIndex = 5;
            lblCategoria.Text = "Categoría";
            // 
            // cboCategoria
            // 
            cboCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategoria.FormattingEnabled = true;
            cboCategoria.Location = new Point(235, 135);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(295, 23);
            cboCategoria.TabIndex = 6;
            // 
            // lblCantidadJugadores
            // 
            lblCantidadJugadores.AutoSize = true;
            lblCantidadJugadores.Location = new Point(49, 191);
            lblCantidadJugadores.Name = "lblCantidadJugadores";
            lblCantidadJugadores.Size = new Size(126, 15);
            lblCantidadJugadores.TabIndex = 7;
            lblCantidadJugadores.Text = "Cantidad de jugadores";
            // 
            // cboCantidadJugadores
            // 
            cboCantidadJugadores.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCantidadJugadores.FormattingEnabled = true;
            cboCantidadJugadores.Location = new Point(235, 188);
            cboCantidadJugadores.Name = "cboCantidadJugadores";
            cboCantidadJugadores.Size = new Size(295, 23);
            cboCantidadJugadores.TabIndex = 8;
            // 
            // btnInscribirme
            // 
            btnInscribirme.Location = new Point(49, 229);
            btnInscribirme.Name = "btnInscribirme";
            btnInscribirme.Size = new Size(142, 23);
            btnInscribirme.TabIndex = 9;
            btnInscribirme.Text = "Inscribirme";
            btnInscribirme.UseVisualStyleBackColor = true;
            btnInscribirme.Click += btnInscribirme_Click;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(274, 233);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(0, 15);
            lblEstado.TabIndex = 10;
            // 
            // btnGuardarEquipo
            // 
            btnGuardarEquipo.Location = new Point(636, 406);
            btnGuardarEquipo.Name = "btnGuardarEquipo";
            btnGuardarEquipo.Size = new Size(142, 23);
            btnGuardarEquipo.TabIndex = 12;
            btnGuardarEquipo.Text = "Guardar Equipo";
            btnGuardarEquipo.UseVisualStyleBackColor = true;
            btnGuardarEquipo.Click += btnGuardarEquipo_Click;
            // 
            // flpJugadores
            // 
            flpJugadores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpJugadores.AutoScroll = true;
            flpJugadores.BorderStyle = BorderStyle.FixedSingle;
            flpJugadores.FlowDirection = FlowDirection.TopDown;
            flpJugadores.Location = new Point(52, 277);
            flpJugadores.Name = "flpJugadores";
            flpJugadores.Size = new Size(726, 108);
            flpJugadores.TabIndex = 13;
            flpJugadores.WrapContents = false;
            // 
            // frmPrincipalGeneral
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(flpJugadores);
            Controls.Add(btnGuardarEquipo);
            Controls.Add(lblEstado);
            Controls.Add(btnInscribirme);
            Controls.Add(cboCantidadJugadores);
            Controls.Add(lblCantidadJugadores);
            Controls.Add(cboCategoria);
            Controls.Add(lblCategoria);
            Controls.Add(txtNombreEquipo);
            Controls.Add(lblNombreEquipo);
            Controls.Add(btnEditarPerfil);
            Controls.Add(btnCerrarSesion);
            Controls.Add(lblBienvenida);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmPrincipalGeneral";
            Text = "Torneos Liga - Usuario";
            Load += frmPrincipalGeneral_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBienvenida;
        private Button btnCerrarSesion;
        private Button btnEditarPerfil;
        private Label lblNombreEquipo;
        private TextBox txtNombreEquipo;
        private Label lblCategoria;
        private ComboBox cboCategoria;
        private Label lblCantidadJugadores;
        private ComboBox cboCantidadJugadores;
        private Button btnInscribirme;
        private Label lblEstado;
        private Button btnGuardarEquipo;
        private FlowLayoutPanel flpJugadores;
    }
}
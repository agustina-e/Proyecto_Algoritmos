namespace Proyecto_Formulario
{
    partial class frmEditarPerfil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditarPerfil));
            btnVolver = new Button();
            lblTitulo = new Label();
            lblNombre = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            lblApellido = new Label();
            txtDni = new TextBox();
            lblDni = new Label();
            txtTelefono = new TextBox();
            lblTelefono = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            lblGenero = new Label();
            cboGenero = new ComboBox();
            lblTipoUsuario = new Label();
            cboTipoUsuario = new ComboBox();
            lblFechaNacimiento = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            lblNombreUsuario = new Label();
            btnCambiarContrasena = new Button();
            btnGuardarCambios = new Button();
            lblError = new Label();
            SuspendLayout();
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(621, 406);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(156, 23);
            btnVolver.TabIndex = 0;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(335, 41);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(84, 15);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Editar mi perfil";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(116, 80);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(109, 15);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre de usuario";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(241, 80);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 3;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(241, 126);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 5;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(116, 126);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(112, 15);
            lblApellido.TabIndex = 4;
            lblApellido.Text = "Apellido del usuario";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(241, 170);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(100, 23);
            txtDni.TabIndex = 9;
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(116, 170);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(90, 15);
            lblDni.TabIndex = 8;
            lblDni.Text = "Número de DNI";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(241, 214);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(100, 23);
            txtTelefono.TabIndex = 7;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(116, 214);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(114, 15);
            lblTelefono.TabIndex = 6;
            lblTelefono.Text = "Número de teléfono";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(241, 245);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 11;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(116, 253);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(105, 15);
            lblEmail.TabIndex = 10;
            lblEmail.Text = "Dirección de Email";
            // 
            // lblGenero
            // 
            lblGenero.AutoSize = true;
            lblGenero.Location = new Point(116, 300);
            lblGenero.Name = "lblGenero";
            lblGenero.Size = new Size(45, 15);
            lblGenero.TabIndex = 12;
            lblGenero.Text = "Género";
            // 
            // cboGenero
            // 
            cboGenero.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGenero.FormattingEnabled = true;
            cboGenero.Location = new Point(220, 298);
            cboGenero.Name = "cboGenero";
            cboGenero.Size = new Size(121, 23);
            cboGenero.TabIndex = 13;
            // 
            // lblTipoUsuario
            // 
            lblTipoUsuario.AutoSize = true;
            lblTipoUsuario.Location = new Point(117, 345);
            lblTipoUsuario.Name = "lblTipoUsuario";
            lblTipoUsuario.Size = new Size(89, 15);
            lblTipoUsuario.TabIndex = 14;
            lblTipoUsuario.Text = "Tipo de usuario";
            // 
            // cboTipoUsuario
            // 
            cboTipoUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoUsuario.FormattingEnabled = true;
            cboTipoUsuario.Location = new Point(224, 339);
            cboTipoUsuario.Name = "cboTipoUsuario";
            cboTipoUsuario.Size = new Size(121, 23);
            cboTipoUsuario.TabIndex = 15;
            // 
            // lblFechaNacimiento
            // 
            lblFechaNacimiento.AutoSize = true;
            lblFechaNacimiento.Location = new Point(95, 398);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Size = new Size(117, 15);
            lblFechaNacimiento.TabIndex = 16;
            lblFechaNacimiento.Text = "Fecha de nacimiento";
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.Location = new Point(218, 390);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(200, 23);
            dtpFechaNacimiento.TabIndex = 17;
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Location = new Point(32, 41);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(0, 15);
            lblNombreUsuario.TabIndex = 18;
            // 
            // btnCambiarContrasena
            // 
            btnCambiarContrasena.Location = new Point(621, 377);
            btnCambiarContrasena.Name = "btnCambiarContrasena";
            btnCambiarContrasena.Size = new Size(156, 23);
            btnCambiarContrasena.TabIndex = 19;
            btnCambiarContrasena.Text = "Cambiar Contraseña";
            btnCambiarContrasena.UseVisualStyleBackColor = true;
            btnCambiarContrasena.Click += btnCambiarContraseña_Click;
            // 
            // btnGuardarCambios
            // 
            btnGuardarCambios.Location = new Point(621, 345);
            btnGuardarCambios.Name = "btnGuardarCambios";
            btnGuardarCambios.Size = new Size(156, 23);
            btnGuardarCambios.TabIndex = 20;
            btnGuardarCambios.Text = "Guardar Cambios";
            btnGuardarCambios.UseVisualStyleBackColor = true;
            btnGuardarCambios.Click += btnGuardarCambios_Click;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(638, 433);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 15);
            lblError.TabIndex = 21;
            // 
            // frmEditarPerfil
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblError);
            Controls.Add(btnGuardarCambios);
            Controls.Add(btnCambiarContrasena);
            Controls.Add(lblNombreUsuario);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(lblFechaNacimiento);
            Controls.Add(cboTipoUsuario);
            Controls.Add(lblTipoUsuario);
            Controls.Add(cboGenero);
            Controls.Add(lblGenero);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtDni);
            Controls.Add(lblDni);
            Controls.Add(txtTelefono);
            Controls.Add(lblTelefono);
            Controls.Add(txtApellido);
            Controls.Add(lblApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(lblTitulo);
            Controls.Add(btnVolver);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmEditarPerfil";
            Text = "Torneos Liga - Editar Perfil";
            Load += frmEditarPerfil_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnVolver;
        private Label lblTitulo;
        private Label lblNombre;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private Label lblApellido;
        private TextBox txtDni;
        private Label lblDni;
        private TextBox txtTelefono;
        private Label lblTelefono;
        private TextBox txtEmail;
        private Label lblEmail;
        private Label lblGenero;
        private ComboBox cboGenero;
        private Label lblTipoUsuario;
        private ComboBox cboTipoUsuario;
        private Label lblFechaNacimiento;
        private DateTimePicker dtpFechaNacimiento;
        private Label lblNombreUsuario;
        private Button btnCambiarContrasena;
        private Button btnGuardarCambios;
        private Label lblError;
    }
}
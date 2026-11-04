namespace Proyecto_Formulario
{
    partial class frmRegistrarUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistrarUsuario));
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            txtDni = new TextBox();
            lblDni = new Label();
            txtTelefono = new TextBox();
            lblTelefono = new Label();
            lblGenero = new Label();
            cboGenero = new ComboBox();
            lblTipoUsuario = new Label();
            cboTipoUsuario = new ComboBox();
            lblFechaNacimiento = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            btnRegistrar = new Button();
            lblError = new Label();
            lblEmail = new Label();
            txtEmail = new TextBox();
            btnVolver = new Button();
            lblTitulo = new Label();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.Font = new Font("Segoe UI", 15F);
            lblNombre.Location = new Point(80, 155);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(350, 28);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre del usuario";
            lblNombre.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 16F);
            txtNombre.Location = new Point(204, 57);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 36);
            txtNombre.TabIndex = 1;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // lblApellido
            // 
            lblApellido.Font = new Font("Segoe UI", 15F);
            lblApellido.Location = new Point(73, 101);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(112, 15);
            lblApellido.TabIndex = 2;
            lblApellido.Text = "Apellido del usuario";
            lblApellido.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtApellido
            // 
            txtApellido.Font = new Font("Segoe UI", 16F);
            txtApellido.Location = new Point(204, 110);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(350, 36);
            txtApellido.TabIndex = 3;
            // 
            // txtDni
            // 
            txtDni.Font = new Font("Segoe UI", 16F);
            txtDni.Location = new Point(204, 160);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(350, 36);
            txtDni.TabIndex = 7;
            // 
            // lblDni
            // 
            lblDni.Font = new Font("Segoe UI", 15F);
            lblDni.Location = new Point(85, 57);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(90, 15);
            lblDni.TabIndex = 6;
            lblDni.Text = "Número de DNI";
            lblDni.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTelefono
            // 
            txtTelefono.Font = new Font("Segoe UI", 16F);
            txtTelefono.Location = new Point(199, 206);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(350, 36);
            txtTelefono.TabIndex = 5;
            // 
            // lblTelefono
            // 
            lblTelefono.Font = new Font("Segoe UI", 15F);
            lblTelefono.Location = new Point(85, 206);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(114, 15);
            lblTelefono.TabIndex = 4;
            lblTelefono.Text = "Número de teléfono";
            lblTelefono.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblGenero
            // 
            lblGenero.Font = new Font("Segoe UI", 15F);
            lblGenero.Location = new Point(85, 259);
            lblGenero.Name = "lblGenero";
            lblGenero.Size = new Size(45, 15);
            lblGenero.TabIndex = 8;
            lblGenero.Text = "Género";
            lblGenero.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboGenero
            // 
            cboGenero.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGenero.Font = new Font("Segoe UI", 15F);
            cboGenero.FormattingEnabled = true;
            cboGenero.Location = new Point(204, 261);
            cboGenero.Name = "cboGenero";
            cboGenero.Size = new Size(350, 36);
            cboGenero.TabIndex = 9;
            cboGenero.SelectedIndexChanged += cboGenero_SelectedIndexChanged;
            // 
            // lblTipoUsuario
            // 
            lblTipoUsuario.Font = new Font("Segoe UI", 15F);
            lblTipoUsuario.Location = new Point(91, 306);
            lblTipoUsuario.Name = "lblTipoUsuario";
            lblTipoUsuario.Size = new Size(89, 15);
            lblTipoUsuario.TabIndex = 10;
            lblTipoUsuario.Text = "Tipo de usuario";
            lblTipoUsuario.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboTipoUsuario
            // 
            cboTipoUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoUsuario.Font = new Font("Segoe UI", 15F);
            cboTipoUsuario.FormattingEnabled = true;
            cboTipoUsuario.Location = new Point(208, 307);
            cboTipoUsuario.Name = "cboTipoUsuario";
            cboTipoUsuario.Size = new Size(350, 36);
            cboTipoUsuario.TabIndex = 11;
            // 
            // lblFechaNacimiento
            // 
            lblFechaNacimiento.Font = new Font("Segoe UI", 15F);
            lblFechaNacimiento.Location = new Point(85, 356);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Size = new Size(117, 15);
            lblFechaNacimiento.TabIndex = 12;
            lblFechaNacimiento.Text = "Fecha de nacimiento";
            lblFechaNacimiento.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.CalendarFont = new Font("Segoe UI", 14F);
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.Location = new Point(350, 42);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(200, 23);
            dtpFechaNacimiento.TabIndex = 13;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRegistrar.Location = new Point(516, 388);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(115, 23);
            btnRegistrar.TabIndex = 14;
            btnRegistrar.Text = "Registrar Usuario";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // lblError
            // 
            lblError.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(574, 306);
            lblError.Name = "lblError";
            lblError.Size = new Size(40, 20);
            lblError.TabIndex = 15;
            // 
            // lblEmail
            // 
            lblEmail.Font = new Font("Segoe UI", 15F);
            lblEmail.Location = new Point(485, 88);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(89, 15);
            lblEmail.TabIndex = 16;
            lblEmail.Text = "Dirección email";
            lblEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 16F);
            txtEmail.Location = new Point(580, 80);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(350, 36);
            txtEmail.TabIndex = 17;
            // 
            // btnVolver
            // 
            btnVolver.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVolver.Location = new Point(674, 388);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 18;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(30, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(940, 105);
            lblTitulo.TabIndex = 19;
            lblTitulo.Text = "\tTorneos Liga  |  Registrar usuario";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frmRegistrarUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 611);
            Controls.Add(lblTitulo);
            Controls.Add(btnVolver);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(lblError);
            Controls.Add(btnRegistrar);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(lblFechaNacimiento);
            Controls.Add(cboTipoUsuario);
            Controls.Add(lblTipoUsuario);
            Controls.Add(cboGenero);
            Controls.Add(lblGenero);
            Controls.Add(txtDni);
            Controls.Add(lblDni);
            Controls.Add(txtTelefono);
            Controls.Add(lblTelefono);
            Controls.Add(txtApellido);
            Controls.Add(lblApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1000, 650);
            Name = "frmRegistrarUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Torneos Liga - Registrar Usuario";
            Load += frmRegistrarUsuario_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblApellido;
        private TextBox txtApellido;
        private TextBox txtDni;
        private Label lblDni;
        private TextBox txtTelefono;
        private Label lblTelefono;
        private Label lblGenero;
        private ComboBox cboGenero;
        private Label lblTipoUsuario;
        private ComboBox cboTipoUsuario;
        private Label lblFechaNacimiento;
        private DateTimePicker dtpFechaNacimiento;
        private Button btnRegistrar;
        private Label lblError;
        private Label lblEmail;
        private TextBox txtEmail;
        private Button btnVolver;
        private Label lblTitulo;
    }
}
namespace Proyecto_Formulario
{
    partial class frmRecuperarContrasena
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecuperarContrasena));
            lblEstadoProceso = new Label();
            lblUsuario = new Label();
            txtUsuarioRecuperar = new TextBox();
            btnEnviarCodigo = new Button();
            lblCodigo = new Label();
            txtCodigo = new TextBox();
            btnValidarCodigo = new Button();
            lblNueva = new Label();
            txtNuevaContrasena = new TextBox();
            lblConfirmar = new Label();
            txtConfirmarContrasena = new TextBox();
            btnGuardar = new Button();
            lblError = new Label();
            btnVolver = new Button();
            SuspendLayout();
            // 
            // lblEstadoProceso
            // 
            lblEstadoProceso.AutoSize = true;
            lblEstadoProceso.Location = new Point(36, 23);
            lblEstadoProceso.Name = "lblEstadoProceso";
            lblEstadoProceso.Size = new Size(257, 15);
            lblEstadoProceso.TabIndex = 0;
            lblEstadoProceso.Text = "Ingrese su usuario para recuperar su contraseña";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(330, 63);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(47, 15);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario";
            // 
            // txtUsuarioRecuperar
            // 
            txtUsuarioRecuperar.Location = new Point(155, 96);
            txtUsuarioRecuperar.Name = "txtUsuarioRecuperar";
            txtUsuarioRecuperar.Size = new Size(393, 23);
            txtUsuarioRecuperar.TabIndex = 2;
            // 
            // btnEnviarCodigo
            // 
            btnEnviarCodigo.Location = new Point(278, 140);
            btnEnviarCodigo.Name = "btnEnviarCodigo";
            btnEnviarCodigo.Size = new Size(172, 23);
            btnEnviarCodigo.TabIndex = 3;
            btnEnviarCodigo.Text = "Enviar Código";
            btnEnviarCodigo.UseVisualStyleBackColor = true;
            btnEnviarCodigo.Click += btnEnviarCodigo_Click;
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(125, 192);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(92, 15);
            lblCodigo.TabIndex = 4;
            lblCodigo.Text = "Código recibido";
            // 
            // txtCodigo
            // 
            txtCodigo.Enabled = false;
            txtCodigo.Location = new Point(223, 188);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(227, 23);
            txtCodigo.TabIndex = 5;
            // 
            // btnValidarCodigo
            // 
            btnValidarCodigo.Enabled = false;
            btnValidarCodigo.Location = new Point(473, 188);
            btnValidarCodigo.Name = "btnValidarCodigo";
            btnValidarCodigo.Size = new Size(160, 23);
            btnValidarCodigo.TabIndex = 6;
            btnValidarCodigo.Text = "Validar Código";
            btnValidarCodigo.UseVisualStyleBackColor = true;
            btnValidarCodigo.Click += btnValidarCodigo_Click;
            // 
            // lblNueva
            // 
            lblNueva.AutoSize = true;
            lblNueva.Location = new Point(125, 265);
            lblNueva.Name = "lblNueva";
            lblNueva.Size = new Size(102, 15);
            lblNueva.TabIndex = 7;
            lblNueva.Text = "Nueva contraseña";
            // 
            // txtNuevaContrasena
            // 
            txtNuevaContrasena.Enabled = false;
            txtNuevaContrasena.Location = new Point(242, 262);
            txtNuevaContrasena.Name = "txtNuevaContrasena";
            txtNuevaContrasena.PasswordChar = '*';
            txtNuevaContrasena.Size = new Size(100, 23);
            txtNuevaContrasena.TabIndex = 8;
            // 
            // lblConfirmar
            // 
            lblConfirmar.AutoSize = true;
            lblConfirmar.Location = new Point(125, 317);
            lblConfirmar.Name = "lblConfirmar";
            lblConfirmar.Size = new Size(122, 15);
            lblConfirmar.TabIndex = 9;
            lblConfirmar.Text = "Confirmar contraseña";
            // 
            // txtConfirmarContrasena
            // 
            txtConfirmarContrasena.Enabled = false;
            txtConfirmarContrasena.Location = new Point(253, 314);
            txtConfirmarContrasena.Name = "txtConfirmarContrasena";
            txtConfirmarContrasena.PasswordChar = '*';
            txtConfirmarContrasena.Size = new Size(100, 23);
            txtConfirmarContrasena.TabIndex = 10;
            // 
            // btnGuardar
            // 
            btnGuardar.Enabled = false;
            btnGuardar.Location = new Point(487, 362);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(586, 365);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 15);
            lblError.TabIndex = 12;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(588, 367);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 13;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // frmRecuperarContrasena
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnVolver);
            Controls.Add(lblError);
            Controls.Add(btnGuardar);
            Controls.Add(txtConfirmarContrasena);
            Controls.Add(lblConfirmar);
            Controls.Add(txtNuevaContrasena);
            Controls.Add(lblNueva);
            Controls.Add(btnValidarCodigo);
            Controls.Add(txtCodigo);
            Controls.Add(lblCodigo);
            Controls.Add(btnEnviarCodigo);
            Controls.Add(txtUsuarioRecuperar);
            Controls.Add(lblUsuario);
            Controls.Add(lblEstadoProceso);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmRecuperarContrasena";
            Text = "Torneos Liga - Recuperar Contraseña";
            Load += frmRecuperarContrasena_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEstadoProceso;
        private Label lblUsuario;
        private TextBox txtUsuarioRecuperar;
        private Button btnEnviarCodigo;
        private Label lblCodigo;
        private TextBox txtCodigo;
        private Button btnValidarCodigo;
        private Label lblNueva;
        private TextBox txtNuevaContrasena;
        private Label lblConfirmar;
        private TextBox txtConfirmarContrasena;
        private Button btnGuardar;
        private Label lblError;
        private Button btnVolver;
    }
}
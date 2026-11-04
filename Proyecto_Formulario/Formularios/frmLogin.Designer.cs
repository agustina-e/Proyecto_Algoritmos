namespace Proyecto_Formulario
{
    partial class frmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            lblUsuario = new Label();
            lblContrasena = new Label();
            lblTitulo = new Label();
            txtUsuario = new TextBox();
            txtContrasena = new TextBox();
            chkMostrarConstrasena = new CheckBox();
            btnIniciarSesion = new Button();
            lnkRecuperar = new LinkLabel();
            lblError = new Label();
            SuspendLayout();
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.FlatStyle = FlatStyle.Flat;
            lblUsuario.Font = new Font("Segoe UI", 13F);
            lblUsuario.Location = new Point(130, 97);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(72, 25);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario";
            lblUsuario.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Font = new Font("Segoe UI", 13F);
            lblContrasena.Location = new Point(130, 180);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(101, 25);
            lblContrasena.TabIndex = 3;
            lblContrasena.Text = "Contraseña";
            lblContrasena.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(984, 75);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Torneos Liga";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            lblTitulo.Click += lblTitulo_Click;
            // 
            // txtUsuario
            // 
            txtUsuario.Anchor = AnchorStyles.Top;
            txtUsuario.Font = new Font("Segoe UI", 24F);
            txtUsuario.Location = new Point(231, 107);
            txtUsuario.MaxLength = 50;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(480, 50);
            txtUsuario.TabIndex = 2;
            txtUsuario.TextChanged += txtUsuario_TextChanged;
            // 
            // txtContrasena
            // 
            txtContrasena.Anchor = AnchorStyles.Top;
            txtContrasena.Font = new Font("Segoe UI", 24F);
            txtContrasena.Location = new Point(231, 182);
            txtContrasena.MaxLength = 100;
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '*';
            txtContrasena.Size = new Size(480, 50);
            txtContrasena.TabIndex = 4;
            txtContrasena.TextChanged += txtContrasena_TextChanged;
            // 
            // chkMostrarConstrasena
            // 
            chkMostrarConstrasena.AutoSize = true;
            chkMostrarConstrasena.Font = new Font("Segoe UI", 12F);
            chkMostrarConstrasena.Location = new Point(734, 201);
            chkMostrarConstrasena.Name = "chkMostrarConstrasena";
            chkMostrarConstrasena.Size = new Size(164, 25);
            chkMostrarConstrasena.TabIndex = 5;
            chkMostrarConstrasena.Text = "Mostrar contraseña";
            chkMostrarConstrasena.UseVisualStyleBackColor = true;
            chkMostrarConstrasena.CheckedChanged += chkMostrarConstrasena_CheckedChanged;
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.Anchor = AnchorStyles.Top;
            btnIniciarSesion.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnIniciarSesion.Location = new Point(287, 262);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(360, 55);
            btnIniciarSesion.TabIndex = 6;
            btnIniciarSesion.Text = "Iniciar Sesión";
            btnIniciarSesion.UseVisualStyleBackColor = true;
            btnIniciarSesion.Click += btnIniciarSesion_Click;
            // 
            // lnkRecuperar
            // 
            lnkRecuperar.AutoSize = true;
            lnkRecuperar.Font = new Font("Segoe UI", 12F);
            lnkRecuperar.LinkColor = Color.Green;
            lnkRecuperar.Location = new Point(314, 333);
            lnkRecuperar.Name = "lnkRecuperar";
            lnkRecuperar.Size = new Size(187, 21);
            lnkRecuperar.TabIndex = 7;
            lnkRecuperar.TabStop = true;
            lnkRecuperar.Text = "¿Olvidaste tu contraseña?";
            lnkRecuperar.LinkClicked += lnkRecuperar_LinkClicked;
            // 
            // lblError
            // 
            lblError.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblError.ForeColor = Color.DarkRed;
            lblError.Location = new Point(518, 375);
            lblError.Name = "lblError";
            lblError.Size = new Size(500, 30);
            lblError.TabIndex = 8;
            lblError.TextAlign = ContentAlignment.MiddleCenter;
            lblError.Click += lblError_Click;
            // 
            // frmLogin
            // 
            AcceptButton = btnIniciarSesion;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 611);
            Controls.Add(lblError);
            Controls.Add(lnkRecuperar);
            Controls.Add(btnIniciarSesion);
            Controls.Add(chkMostrarConstrasena);
            Controls.Add(txtContrasena);
            Controls.Add(lblContrasena);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(lblTitulo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(341, 188);
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Torneos Liga - Inicio";
            Load += frmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblContrasena;
        private TextBox txtContrasena;
        private CheckBox chkMostrarConstrasena;
        private Button btnIniciarSesion;
        private LinkLabel lnkRecuperar;
        private Label lblError;
    }
}

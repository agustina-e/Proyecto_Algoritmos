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
            Label lblUsuario;
            Label lblContrasena;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            lblTitulo = new Label();
            txtUsuario = new TextBox();
            txtContrasena = new TextBox();
            chkMostrarConstrasena = new CheckBox();
            btnIniciarSesion = new Button();
            lnkRecuperar = new LinkLabel();
            lblError = new Label();
            lblUsuario = new Label();
            lblContrasena = new Label();
            SuspendLayout();
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.FlatStyle = FlatStyle.Flat;
            lblUsuario.Location = new Point(154, 97);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(47, 15);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario";
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Location = new Point(154, 183);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(67, 15);
            lblContrasena.TabIndex = 3;
            lblContrasena.Text = "Contraseña";
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(800, 15);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Torneos Liga";
            lblTitulo.Click += lblTitulo_Click;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(265, 94);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(327, 23);
            txtUsuario.TabIndex = 2;
            txtUsuario.TextChanged += txtUsuario_TextChanged;
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(265, 180);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '*';
            txtContrasena.Size = new Size(328, 23);
            txtContrasena.TabIndex = 4;
            txtContrasena.TextChanged += txtContrasena_TextChanged;
            // 
            // chkMostrarConstrasena
            // 
            chkMostrarConstrasena.AutoSize = true;
            chkMostrarConstrasena.Location = new Point(599, 182);
            chkMostrarConstrasena.Name = "chkMostrarConstrasena";
            chkMostrarConstrasena.Size = new Size(128, 19);
            chkMostrarConstrasena.TabIndex = 5;
            chkMostrarConstrasena.Text = "Mostrar contraseña";
            chkMostrarConstrasena.UseVisualStyleBackColor = true;
            chkMostrarConstrasena.CheckedChanged += chkMostrarConstrasena_CheckedChanged;
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.Location = new Point(299, 267);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(254, 23);
            btnIniciarSesion.TabIndex = 6;
            btnIniciarSesion.Text = "Iniciar Sesión";
            btnIniciarSesion.UseVisualStyleBackColor = true;
            btnIniciarSesion.Click += btnIniciarSesion_Click;
            // 
            // lnkRecuperar
            // 
            lnkRecuperar.AutoSize = true;
            lnkRecuperar.Location = new Point(354, 309);
            lnkRecuperar.Name = "lnkRecuperar";
            lnkRecuperar.Size = new Size(141, 15);
            lnkRecuperar.TabIndex = 7;
            lnkRecuperar.TabStop = true;
            lnkRecuperar.Text = "¿Olvidaste tu contraseña?";
            lnkRecuperar.LinkClicked += lnkRecuperar_LinkClicked;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(439, 231);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 15);
            lblError.TabIndex = 8;
            // 
            // frmLogin
            // 
            AcceptButton = btnIniciarSesion;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            Name = "frmLogin";
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

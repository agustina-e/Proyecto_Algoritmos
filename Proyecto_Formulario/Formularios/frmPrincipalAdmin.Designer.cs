namespace Proyecto_Formulario
{
    partial class frmPrincipalAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipalAdmin));
            lblBienvenida = new Label();
            btnCerrarSesion = new Button();
            btnEditarPerfil = new Button();
            btnRegistrarUsuario = new Button();
            dgvEquipos = new DataGridView();
            lblEstado = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEquipos).BeginInit();
            SuspendLayout();
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Location = new Point(98, 35);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(0, 15);
            lblBienvenida.TabIndex = 0;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(642, 47);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(125, 23);
            btnCerrarSesion.TabIndex = 1;
            btnCerrarSesion.Text = "Cerrar Sesion";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // btnEditarPerfil
            // 
            btnEditarPerfil.Location = new Point(511, 47);
            btnEditarPerfil.Name = "btnEditarPerfil";
            btnEditarPerfil.Size = new Size(125, 23);
            btnEditarPerfil.TabIndex = 2;
            btnEditarPerfil.Text = "Editar Perfil";
            btnEditarPerfil.UseVisualStyleBackColor = true;
            btnEditarPerfil.Click += btnEditarPerfil_Click;
            // 
            // btnRegistrarUsuario
            // 
            btnRegistrarUsuario.Location = new Point(98, 97);
            btnRegistrarUsuario.Name = "btnRegistrarUsuario";
            btnRegistrarUsuario.Size = new Size(116, 23);
            btnRegistrarUsuario.TabIndex = 3;
            btnRegistrarUsuario.Text = "Registrar Usuario";
            btnRegistrarUsuario.UseVisualStyleBackColor = true;
            btnRegistrarUsuario.Click += btnRegistrarUsuario_Click;
            // 
            // dgvEquipos
            // 
            dgvEquipos.AllowUserToAddRows = false;
            dgvEquipos.AllowUserToDeleteRows = false;
            dgvEquipos.AllowUserToResizeRows = false;
            dgvEquipos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquipos.Location = new Point(98, 140);
            dgvEquipos.MultiSelect = false;
            dgvEquipos.Name = "dgvEquipos";
            dgvEquipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEquipos.Size = new Size(626, 263);
            dgvEquipos.TabIndex = 4;
            dgvEquipos.CellContentClick += dgvEquipos_CellContentClick;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(111, 334);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(0, 15);
            lblEstado.TabIndex = 5;
            // 
            // frmPrincipalAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblEstado);
            Controls.Add(dgvEquipos);
            Controls.Add(btnRegistrarUsuario);
            Controls.Add(btnEditarPerfil);
            Controls.Add(btnCerrarSesion);
            Controls.Add(lblBienvenida);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmPrincipalAdmin";
            Text = "Torneos Liga - Administrador";
            Load += frmPrincipalAdmin_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEquipos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBienvenida;
        private Button btnCerrarSesion;
        private Button btnEditarPerfil;
        private Button btnRegistrarUsuario;
        private DataGridView dgvEquipos;
        private Label lblEstado;
    }
}
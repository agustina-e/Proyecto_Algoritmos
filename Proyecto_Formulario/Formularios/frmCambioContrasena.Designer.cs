namespace Proyecto_Formulario
{
    partial class frmCambioContrasena
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambioContrasena));
            lblInfo = new Label();
            lblNueva = new Label();
            txtNuevaContrasena = new TextBox();
            lblConfirmar = new Label();
            txtConfirmarContrasena = new TextBox();
            btnConfirmar = new Button();
            lblError = new Label();
            SuspendLayout();
            // 
            // lblInfo
            // 
            resources.ApplyResources(lblInfo, "lblInfo");
            lblInfo.Name = "lblInfo";
            // 
            // lblNueva
            // 
            resources.ApplyResources(lblNueva, "lblNueva");
            lblNueva.Name = "lblNueva";
            // 
            // txtNuevaContrasena
            // 
            resources.ApplyResources(txtNuevaContrasena, "txtNuevaContrasena");
            txtNuevaContrasena.Name = "txtNuevaContrasena";
            // 
            // lblConfirmar
            // 
            resources.ApplyResources(lblConfirmar, "lblConfirmar");
            lblConfirmar.Name = "lblConfirmar";
            // 
            // txtConfirmarContrasena
            // 
            resources.ApplyResources(txtConfirmarContrasena, "txtConfirmarContrasena");
            txtConfirmarContrasena.Name = "txtConfirmarContrasena";
            // 
            // btnConfirmar
            // 
            resources.ApplyResources(btnConfirmar, "btnConfirmar");
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click_1;
            // 
            // lblError
            // 
            resources.ApplyResources(lblError, "lblError");
            lblError.ForeColor = Color.Red;
            lblError.Name = "lblError";
            // 
            // frmCambioContrasena
            // 
            AcceptButton = btnConfirmar;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            ControlBox = false;
            Controls.Add(lblError);
            Controls.Add(btnConfirmar);
            Controls.Add(txtConfirmarContrasena);
            Controls.Add(lblConfirmar);
            Controls.Add(txtNuevaContrasena);
            Controls.Add(lblNueva);
            Controls.Add(lblInfo);
            Name = "frmCambioContrasena";
            FormClosing += frmCambioContrasena_FormClosing;
            Load += frmCambioContrasena_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblInfo;
        private Label lblNueva;
        private Label lblConfirmar;
        private TextBox txtConfirmarContrasena;
        private Button btnConfirmar;
        private Label lblError;
        private TextBox txtNuevaContrasena;
    }
}
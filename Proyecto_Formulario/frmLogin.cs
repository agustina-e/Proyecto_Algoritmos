namespace Proyecto_Formulario
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void chkMostrarConstrasena_CheckedChanged(object sender, EventArgs e)
        {
            // Mostrar u ocultar contraseña según el estado del CheckBox
            txtContrasena.PasswordChar = chkMostrarConstrasena.Checked ? '\0' : '*';
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {
            EstiloUI.AplicarBaseFormulario(this);
            EstiloUI.EstilizarEncabezado(lblTitulo);
            EstiloUI.EstilizarBotonPrimario(btnIniciarSesion);
            EstiloUI.EstilizarTextBox(txtUsuario);
            EstiloUI.EstilizarTextBox(txtContrasena);
            EstiloUI.EstilizarLabelError(lblError);

            lnkRecuperar.LinkColor = EstiloUI.VerdeAccion;
            lnkRecuperar.Font = EstiloUI.FuenteNormal;
        }
        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
            // Manejar cambios en la caja de contraseña (ej: limpiar mensaje de error)
            if (lblError != null)
            {
                lblError.Text = string.Empty;
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            if (lblError != null)
                lblError.Text = string.Empty;
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {
            // Acción simple para el click del título (no rompe en diseño)
            MessageBox.Show("Torneos Liga\nVersión de prueba", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text;

            // Validación de campos completos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                lblError.Text = "Debe completar usuario y contraseña.";
                return;
            }

            // Búsqueda del usuario en el array
            int indice = -1;
            for (int i = 0; i < DatosGlobales.usuarios.Count; i++)
            {
                if (DatosGlobales.usuarios[i] == usuario)
                {
                    indice = i;
                    break;
                }
            }

            if (indice == -1 || DatosGlobales.contrasenas[indice] != contrasena)
            {
                lblError.Text = "Usuario o contraseña incorrectos.";
                return;
            }

            // Guardamos quién inició sesión, para usarlo en otros formularios
            DatosGlobales.usuarioActual = usuario;
            DatosGlobales.rolActual = DatosGlobales.roles[indice];

            // Redirección según corresponda
            if (DatosGlobales.primerIngreso[indice])
            {
                frmCambioContrasena frm = new frmCambioContrasena();
                frm.Show();
                this.Hide();
            }
            else if (DatosGlobales.rolActual == "Administrador")
            {
                frmPrincipalAdmin frm = new frmPrincipalAdmin();
                frm.Show();
                this.Hide();
            }
            else
            {
                frmPrincipalGeneral frm = new frmPrincipalGeneral();
                frm.Show();
                this.Hide();
            }
        }

        private void lnkRecuperar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRecuperarContrasena frm = new frmRecuperarContrasena();
            frm.Show();
            this.Hide();
        }

    }
}

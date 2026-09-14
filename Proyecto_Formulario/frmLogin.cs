using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

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

            // consultamos a la tabla usuario si existe ese use con esa contraseña
            string query = "SELECT Rol, PrimerIngreso FROM Usuarios WHERE Usuario = @Usuario AND Contrasena = @Contrasena";

            string rolEncontrado = "";
            bool primerIngresoEncontrado = false;
            bool usuarioExiste = false;

            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", usuario);
                        cmd.Parameters.AddWithValue("@Contrasena", contrasena);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                usuarioExiste = true;
                                rolEncontrado = reader["Rol"]?.ToString() ?? string.Empty;
                                primerIngresoEncontrado = Convert.ToBoolean(reader["PrimerIngreso"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al conectar con la base de datos: " + ex.Message;
                return;
            }

            // Validación de credenciales
            if (!usuarioExiste)
            {
                lblError.Text = "Usuario o contraseña incorrectos.";
                return;
            }

            // Guardamos quién inició sesión, para usarlo en otros formularios
            DatosGlobales.usuarioActual = usuario;
            DatosGlobales.rolActual = rolEncontrado;

            // Redirección según corresponda
            if (primerIngresoEncontrado)
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
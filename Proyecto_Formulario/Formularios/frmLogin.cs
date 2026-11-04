using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Drawing;

namespace Proyecto_Formulario
{
    public partial class frmLogin : Form
    {
        #region Inicialización y configuración del login

        // Inicializar los controles del formulario
        public frmLogin()
        {
            InitializeComponent();
        }

        // Limpiar los campos y mostrar nuevamente el formulario
        public void PrepararParaNuevoInicio()
        {
            txtUsuario.Clear();
            txtContrasena.Clear();
            lblError.Text = "";

            this.Show();
            this.Activate();
        }

        // Mostrar u ocultar los caracteres de la contraseña
        private void chkMostrarConstrasena_CheckedChanged(object sender, EventArgs e)
        {
            
            txtContrasena.PasswordChar = chkMostrarConstrasena.Checked ? '\0' : '*';
        }

        // Configurar los estilos, tamaños y posiciones iniciales
        private void frmLogin_Load(object sender, EventArgs e)
        {
            EstiloUI.AplicarBaseFormulario(this);

            this.ClientSize = new Size(1000, 650);
            this.MinimumSize = new Size(900, 650);
            this.StartPosition = FormStartPosition.CenterScreen;

            EstiloUI.EstilizarEncabezado(lblTitulo);
            EstiloUI.EstilizarBotonPrimario(btnIniciarSesion);
            EstiloUI.EstilizarTextBox(txtUsuario);
            EstiloUI.EstilizarTextBox(txtContrasena);
            EstiloUI.EstilizarLabelError(lblError);

            lblTitulo.Font = new Font("Segoe UI", 24, FontStyle.Bold);

            txtUsuario.Font = new Font("Segoe UI", 24);
            txtContrasena.Font = new Font("Segoe UI", 24);

            lblUsuario.Font = new Font("Segoe UI", 13);
            lblContrasena.Font = new Font("Segoe UI", 13);

            chkMostrarConstrasena.Font = new Font("Segoe UI", 12);

            btnIniciarSesion.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            btnIniciarSesion.Size = new Size(360, 55);

            lnkRecuperar.LinkColor = EstiloUI.VerdeAccion;
            lnkRecuperar.Font = new Font("Segoe UI", 12);

            lblError.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblError.ForeColor = Color.FromArgb(190, 35, 35);
            lblError.TextAlign = ContentAlignment.MiddleCenter;
            lblError.AutoSize = false;
            lblError.Size = new Size(700, 35);

            lblTitulo.Height = 75;

            txtUsuario.Size = new Size(480, txtUsuario.Height);
            txtContrasena.Size = new Size(480, txtContrasena.Height);

            chkMostrarConstrasena.AutoSize = true;

            lblUsuario.AutoSize = false;
            lblUsuario.Size = new Size(130, 35);
            lblUsuario.TextAlign = ContentAlignment.MiddleRight;

            lblContrasena.AutoSize = false;
            lblContrasena.Size = new Size(130, 35);
            lblContrasena.TextAlign = ContentAlignment.MiddleRight;

            lblError.Text = "";

            AcomodarControles();

            this.Resize += (s, ev) => AcomodarControles();
        }

        #endregion

        #region Distribución de controles

        // Centrar y distribuir los controles según el tamaño del formulario
        private void AcomodarControles()
        {
            int centroX = this.ClientSize.Width / 2;

            int altoEncabezado = lblTitulo.Height;

            int altoBloque = 390;

            int inicioY = altoEncabezado +
                (this.ClientSize.Height - altoEncabezado - altoBloque) / 2;

            // Posicionar las etiquetas del formulario
            lblUsuario.Location = new Point(centroX - 410, inicioY + 25);
            lblContrasena.Location = new Point(centroX - 410, inicioY + 135);

            // Posicionar los campos de entrada
            txtUsuario.Location = new Point(centroX - 260, inicioY + 25);
            txtContrasena.Location = new Point(centroX - 260, inicioY + 135);

            // Posicionar la opción para mostrar la contraseña
            chkMostrarConstrasena.Location = new Point(
                txtContrasena.Right + 15,
                txtContrasena.Top + (txtContrasena.Height - chkMostrarConstrasena.Height) / 2
            );

            // Posicionar el mensaje de error
            lblError.Location = new Point(centroX - 350, inicioY + 205);

            // Posicionar el botón de inicio de sesión
            btnIniciarSesion.Location = new Point(
                centroX - btnIniciarSesion.Width / 2,
                inicioY + 260
            );

            // Posicionar el enlace de recuperación de contraseña
            lnkRecuperar.Location = new Point(
                centroX - lnkRecuperar.Width / 2,
                inicioY + 335
            );
        }

        #endregion

        #region Eventos de interfaz

        // Limpiar el mensaje de error al modificar la contraseña
        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
            
            if (lblError != null)
            {
                lblError.Text = string.Empty;
            }
        }

        // Limpiar el mensaje de error al modificar el usuario
        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            if (lblError != null)
                lblError.Text = string.Empty;
        }

        // Mostrar la información de la versión de prueba
        private void lblTitulo_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Torneos Liga\nVersión de prueba", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Autenticación de usuarios

        // Validar las credenciales y dirigir al usuario según su rol
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text;

            // Comprobar que los campos estén completos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                lblError.Text = "Debe completar usuario y contraseña.";
                return;
            }

            // Consultar si el usuario existe con la contraseña ingresada
            string query = @"
            SELECT Rol, PrimerIngreso
            FROM Usuarios
            WHERE Usuario = @Usuario
            AND Contrasena COLLATE Latin1_General_100_CS_AS =
            @Contrasena COLLATE Latin1_General_100_CS_AS"; ;

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
            catch (Exception)
            {
                lblError.Text = "No se pudo conectar con el sistema. Intente nuevamente.";
                return;
            }

            // Comprobar las credenciales ingresadas
            if (!usuarioExiste)
            {
                lblError.Text = "Usuario o contraseña incorrectos.";
                return;
            }

            // Guardar los datos del usuario que inició sesión
            DatosGlobales.usuarioActual = usuario;
            DatosGlobales.rolActual = rolEncontrado;

            // Redirigir al usuario según su primer ingreso y su rol
            if (primerIngresoEncontrado)
            {
                frmCambioContrasena frm = new frmCambioContrasena();
                Program.MostrarFormulario(frm);
                this.Hide();
            }
            else if (DatosGlobales.rolActual == "Administrador")
            {
                frmPrincipalAdmin frm = new frmPrincipalAdmin();
                Program.MostrarFormulario(frm);
                this.Hide();
            }
            else
            {
                frmPrincipalGeneral frm = new frmPrincipalGeneral();
                Program.MostrarFormulario(frm);
                this.Hide();
            }
        }

        #endregion

        #region Recuperación de contraseña

        // Abrir el formulario de recuperación de contraseña
        private void lnkRecuperar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRecuperarContrasena frm = new frmRecuperarContrasena();
            Program.MostrarFormulario(frm);
            this.Hide();
        }

        private void lblError_Click(object sender, EventArgs e)
        {

        }
        #endregion

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Proyecto_Formulario
{
    public partial class frmRecuperarContrasena : Form
    {
        #region Estado del proceso de recuperación

        // Conservar el usuario que solicita recuperar la contraseña
        private string usuarioEnRecuperacion = "";

        // Conservar el formulario desde el que se inició la recuperación
        private readonly Form? formularioAnterior;

        // Evitar guardar la contraseña sin validar previamente el código
        private bool codigoValidado = false;

        // Mantener el código fijo de recuperación establecido por la consigna
        private const string CODIGO_RECUPERACION = "1234";

        #endregion

        #region Inicialización del formulario

        // Inicializar el formulario sin un formulario de origen
        public frmRecuperarContrasena() : this(null)
        {
        }

        // Inicializar el formulario y conservar su origen
        public frmRecuperarContrasena(Form? formularioAnterior)
        {
            InitializeComponent();

            this.formularioAnterior = formularioAnterior;

            this.FormClosing += frmRecuperarContrasena_FormClosing;
        }

        // Configurar la interfaz y bloquear los pasos pendientes
        private void frmRecuperarContrasena_Load(object sender, EventArgs e)
        {
            EstiloUI.AplicarBaseFormulario(this);
            EstiloUI.EstilizarTextoDestacado(lblEstadoProceso);
            EstiloUI.EstilizarEtiqueta(lblUsuario);
            EstiloUI.EstilizarEtiqueta(lblCodigo);
            EstiloUI.EstilizarEtiqueta(lblNueva);
            EstiloUI.EstilizarEtiqueta(lblConfirmar);

            EstiloUI.EstilizarTextBox(txtUsuarioRecuperar);
            EstiloUI.EstilizarTextBox(txtCodigo);
            EstiloUI.EstilizarTextBox(txtNuevaContrasena);
            EstiloUI.EstilizarTextBox(txtConfirmarContrasena);

            EstiloUI.EstilizarBotonPrimario(btnEnviarCodigo);
            EstiloUI.EstilizarBotonPrimario(btnValidarCodigo);
            EstiloUI.EstilizarBotonPrimario(btnGuardar);
            EstiloUI.EstilizarBotonSecundario(btnVolver);

            EstiloUI.EstilizarLabelError(lblError);

            lblEstadoProceso.Text = "Ingresá tu usuario para comenzar";
            lblError.Text = "";

            EstiloUI.EstilizarEncabezado(lblTitulo);

            txtCodigo.Enabled = false;
            btnValidarCodigo.Enabled = false;
            txtNuevaContrasena.Enabled = false;
            txtConfirmarContrasena.Enabled = false;
            btnGuardar.Enabled = false;

            usuarioEnRecuperacion = "";
            codigoValidado = false;
        }

        #endregion

        #region Verificación del usuario

        // Verificar la existencia del usuario e iniciar la recuperación
        private void btnEnviarCodigo_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            string usuario = txtUsuarioRecuperar.Text.Trim();

            if (string.IsNullOrEmpty(usuario))
            {
                lblError.Text = "Debe ingresar un nombre de usuario.";
                return;
            }

            string query = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario";
            bool existeUsuario = false;

            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", usuario);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        existeUsuario = (count > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al verificar el usuario: " + ex.Message;
                return;
            }

            if (!existeUsuario)
            {
                lblError.Text = "No existe un usuario con ese nombre.";
                return;
            }

            usuarioEnRecuperacion = usuario;

            MessageBox.Show("Se envió un código a tu email registrado.", "Código enviado",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            lblEstadoProceso.Text = "Código enviado, ingresalo a continuación";

            // Habilitar el paso siguiente y bloquear el usuario durante el proceso
            txtUsuarioRecuperar.Enabled = false;
            btnEnviarCodigo.Enabled = false;
            txtCodigo.Enabled = true;
            btnValidarCodigo.Enabled = true;
        }

        #endregion

        #region Validación del código

        // Comprobar el código ingresado y habilitar el cambio
        private void btnValidarCodigo_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            // Evitar continuar sin verificar previamente el usuario
            if (string.IsNullOrEmpty(usuarioEnRecuperacion))
            {
                lblError.Text = "Debe validar su usuario primero.";
                return;
            }

            string codigoIngresado = txtCodigo.Text.Trim();

            if (string.IsNullOrEmpty(codigoIngresado))
            {
                lblError.Text = "Debe ingresar el código recibido.";
                return;
            }

            if (codigoIngresado != CODIGO_RECUPERACION)
            {
                lblError.Text = "El código ingresado es incorrecto.";
                return;
            }

            codigoValidado = true;
            lblEstadoProceso.Text = "Código válido, establecé tu nueva contraseña";

            txtCodigo.Enabled = false;
            btnValidarCodigo.Enabled = false;
            txtNuevaContrasena.Enabled = true;
            txtConfirmarContrasena.Enabled = true;
            btnGuardar.Enabled = true;
        }

        #endregion

        #region Actualización de contraseña

        // Validar y actualizar la contraseña recuperada
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            // Evitar guardar la contraseña sin validar previamente el código
            if (!codigoValidado || string.IsNullOrEmpty(usuarioEnRecuperacion))
            {
                lblError.Text = "Debe validar el código antes de continuar.";
                return;
            }

            string nueva = txtNuevaContrasena.Text;
            string confirmar = txtConfirmarContrasena.Text;

            if (string.IsNullOrEmpty(nueva) || string.IsNullOrEmpty(confirmar))
            {
                lblError.Text = "Debe completar ambos campos.";
                return;
            }

            if (nueva.Length < 8)
            {
                lblError.Text = "La contraseña debe tener al menos 8 caracteres.";
                return;
            }

            if (nueva != confirmar)
            {
                lblError.Text = "Las contraseñas no coinciden.";
                return;
            }

            // Actualizar la contraseña en SQL Server sin exigir otro cambio por primer ingreso
            string updateQuery = @"UPDATE Usuarios 
                       SET Contrasena = @Contrasena, PrimerIngreso = 0
                       WHERE Usuario = @Usuario";

            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Contrasena", nueva);
                        cmd.Parameters.AddWithValue("@Usuario", usuarioEnRecuperacion);
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas == 0)
                        {
                            lblError.Text = "No se pudo actualizar la contraseña. Verifique el usuario.";
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al actualizar la contraseña: " + ex.Message;
                return;
            }

            MessageBox.Show("Contraseña actualizada correctamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            VolverAlOrigen();
        }

        #endregion

        #region Navegación del proceso de recuperación

        // Volver al formulario desde el que se inició la recuperación
        private void btnVolver_Click(object sender, EventArgs e)
        {
            VolverAlOrigen();
        }

        // Recuperar el formulario de origen o volver al login
        private void VolverAlOrigen()
        {
            if (formularioAnterior != null && !formularioAnterior.IsDisposed)
            {
                formularioAnterior.Show();
                formularioAnterior.Activate();
            }
            else
            {
                Program.VolverAlLogin();
            }

            this.Close();
        }

        // Mostrar nuevamente el formulario de origen al cerrar la recuperación
        private void frmRecuperarContrasena_FormClosing(
            object? sender,
            FormClosingEventArgs e)
        {
            if (formularioAnterior != null &&
                !formularioAnterior.IsDisposed &&
                !formularioAnterior.Visible)
            {
                formularioAnterior.Show();
                formularioAnterior.Activate();
            }
        }
        #endregion

    }
}

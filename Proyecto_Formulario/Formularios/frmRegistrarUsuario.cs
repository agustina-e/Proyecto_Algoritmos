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
    public partial class frmRegistrarUsuario : Form
    {
        #region Inicialización y configuración de la interfaz

        // Inicializar los controles del formulario
        public frmRegistrarUsuario()
        {
            InitializeComponent();
        }

        // Distribuir y dimensionar los controles del formulario
        private void ConfigurarInterfaz()
        {
            this.Size = new Size(1000, 650);
            this.MinimumSize = new Size(1000, 650);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Configurar el encabezado del formulario
            lblTitulo.Text = "Torneos Liga  |  Registrar usuario";
            EstiloUI.EstilizarEncabezado(lblTitulo);
            lblTitulo.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;

            // Configurar las etiquetas del formulario
            ConfigurarEtiqueta(lblNombre, 80, 155, 350);
            ConfigurarEtiqueta(lblApellido, 80, 255, 350);
            ConfigurarEtiqueta(lblDni, 80, 355, 350);
            ConfigurarEtiqueta(lblTelefono, 80, 455, 350);

            ConfigurarEtiqueta(lblEmail, 550, 155, 350);
            ConfigurarEtiqueta(lblGenero, 550, 255, 350);
            ConfigurarEtiqueta(lblTipoUsuario, 550, 355, 350);
            ConfigurarEtiqueta(lblFechaNacimiento, 550, 455, 350);

            // Configurar los campos de entrada
            ConfigurarCampo(txtNombre, 80, 188, 350, 42);
            ConfigurarCampo(txtApellido, 80, 288, 350, 42);
            ConfigurarCampo(txtDni, 80, 388, 350, 42);
            ConfigurarCampo(txtTelefono, 80, 488, 350, 42);

            ConfigurarCampo(txtEmail, 550, 188, 350, 42);
            ConfigurarCampo(cboGenero, 550, 288, 350, 42);
            ConfigurarCampo(cboTipoUsuario, 550, 388, 350, 42);
            ConfigurarCampo(dtpFechaNacimiento, 550, 488, 350, 42);

            // Configurar los botones del formulario
            btnRegistrar.Size = new Size(150, 45);
            btnRegistrar.Location = new Point(715, 565);

            btnVolver.Size = new Size(90, 45);
            btnVolver.Location = new Point(880, 565);

            btnRegistrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVolver.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            // Configurar el mensaje de error
            lblError.Location = new Point(80, 565);
            lblError.Size = new Size(600, 35);
            lblError.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        // Configurar la posición y el estilo de una etiqueta
        private void ConfigurarEtiqueta(Label etiqueta, int x, int y, int ancho)
        {
            etiqueta.Location = new Point(x, y);
            etiqueta.Size = new Size(ancho, 28);
            etiqueta.Font = new Font("Segoe UI", 15);
            etiqueta.TextAlign = ContentAlignment.MiddleLeft;
            etiqueta.AutoSize = false;
        }

        // Configurar la posición y el tamaño de un campo
        private void ConfigurarCampo(Control campo, int x, int y, int ancho, int alto)
        {
            campo.Location = new Point(x, y);
            campo.Size = new Size(ancho, alto);
            campo.Font = new Font("Segoe UI", 16);
            campo.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            if (campo is TextBox txt)
            {
                txt.AutoSize = false;
            }
        }

        #endregion

        #region Inicialización del registro

        private void cboGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Configurar los controles y los límites de los campos
        private void frmRegistrarUsuario_Load(object sender, EventArgs e)
        {
            EstiloUI.AplicarBaseFormulario(this);

            EstiloUI.EstilizarTextBox(txtNombre);
            EstiloUI.EstilizarTextBox(txtApellido);
            EstiloUI.EstilizarTextBox(txtDni);
            EstiloUI.EstilizarTextBox(txtTelefono);
            EstiloUI.EstilizarTextBox(txtEmail);

            EstiloUI.EstilizarBotonPrimario(btnRegistrar);
            EstiloUI.EstilizarBotonSecundario(btnVolver);
            EstiloUI.EstilizarLabelError(lblError);

            cboGenero.Items.Clear();
            cboGenero.Items.AddRange(new string[] { "Masculino", "Femenino", "Otro" });

            cboTipoUsuario.Items.Clear();
            cboTipoUsuario.Items.AddRange(new string[] { "Administrador", "General" });

            dtpFechaNacimiento.ShowCheckBox = true;
            dtpFechaNacimiento.Checked = false;

            lblError.Text = "";

            txtNombre.MaxLength = 50;
            txtApellido.MaxLength = 50;
            txtDni.MaxLength = 8;
            txtTelefono.MaxLength = 10;
            txtEmail.MaxLength = 100;


            ConfigurarInterfaz();
        }

        #endregion

        #region Generación de credenciales

        // Generar un nombre de usuario único a partir de los datos personales
        private string GenerarNombreUsuario(string nombre, string apellido, string dni)
        {
            string inicial = nombre.Substring(0, 1).ToLower();
            string apellidoMinuscula = apellido.ToLower().Replace(" ", "");
            string ultimosTresDni = dni.Substring(dni.Length - 3);

            string usuarioBase = inicial + apellidoMinuscula + ultimosTresDni;
            string usuarioFinal = usuarioBase;

            int sufijo = 2;
            while (ExisteUsuarioEnBD(usuarioFinal))
            {
                usuarioFinal = usuarioBase + "_" + sufijo;
                sufijo++;
            }

            return usuarioFinal;
        }

        // Comprobar si el nombre de usuario ya está registrado
        private bool ExisteUsuarioEnBD(string usuario)
        {
            string query = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario";
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", usuario);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        // Generar una contraseña aleatoria para el nuevo usuario
        private string GenerarContrasenaAleatoria()
        {
            const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            char[] contrasena = new char[10];

            for (int i = 0; i < contrasena.Length; i++)
            {
                int indiceAleatorio = random.Next(caracteresPermitidos.Length);
                contrasena[i] = caracteresPermitidos[indiceAleatorio];
            }

            return new string(contrasena);
        }

        #endregion

        #region Validación y registro de usuarios

        // Validar los datos y registrar el nuevo usuario
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string dni = txtDni.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Verificar los campos obligatorios
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) ||
                string.IsNullOrEmpty(dni) || string.IsNullOrEmpty(telefono) ||
                string.IsNullOrEmpty(email) || cboGenero.SelectedItem == null ||
                cboTipoUsuario.SelectedItem == null)
            {
                lblError.Text = "Debe completar todos los campos obligatorios.";
                return;
            }

            if (!Validaciones.SoloLetras(nombre))
            {
                lblError.Text = "El nombre solo puede contener letras.";
                return;
            }

            if (!Validaciones.SoloLetras(apellido))
            {
                lblError.Text = "El apellido solo puede contener letras.";
                return;
            }

            if (dni.Length != 8 || !Validaciones.SoloNumeros(dni))
            {
                lblError.Text = "El DNI debe contener 8 dígitos numéricos.";
                return;
            }

            if (ExisteDniEnBD(dni))
            {
                lblError.Text = "Ya existe un usuario registrado con ese DNI.";
                return;
            }

            if (telefono.Length != 10 || !Validaciones.SoloNumeros(telefono))
            {
                lblError.Text = "El teléfono debe contener 10 dígitos numéricos.";
                return;
            }

            if (!Validaciones.EmailValido(email))
            {
                lblError.Text = "Ingrese un email con formato válido.";
                return;
            }

            if (!dtpFechaNacimiento.Checked)
            {
                lblError.Text = "Debe seleccionar una fecha de nacimiento.";
                return;
            }

            if (dtpFechaNacimiento.Value.Date > DateTime.Now.Date)
            {
                lblError.Text = "La fecha de nacimiento no puede ser futura.";
                return;
            }

            // Generar las credenciales después de validar los datos
            string nuevoUsuario = GenerarNombreUsuario(nombre, apellido, dni);
            string nuevaContrasena = GenerarContrasenaAleatoria();
            string tipoUsuario = cboTipoUsuario.SelectedItem?.ToString() ?? string.Empty;
            string genero = cboGenero.SelectedItem?.ToString() ?? string.Empty;

            string insertQuery = @"INSERT INTO Usuarios 
                (Usuario, Contrasena, Rol, PrimerIngreso, Nombre, Apellido, Dni, Telefono, Email, Genero, FechaNacimiento) 
                VALUES 
                (@Usuario, @Contrasena, @Rol, 1, @Nombre, @Apellido, @Dni, @Telefono, @Email, @Genero, @FechaNacimiento)";

            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", nuevoUsuario);
                        cmd.Parameters.AddWithValue("@Contrasena", nuevaContrasena);
                        cmd.Parameters.AddWithValue("@Rol", tipoUsuario);
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Apellido", apellido);
                        cmd.Parameters.AddWithValue("@Dni", dni);
                        cmd.Parameters.AddWithValue("@Telefono", telefono);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Genero", genero);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", dtpFechaNacimiento.Value.Date);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al registrar en la base de datos: " + ex.Message;
                return;
            }

            MessageBox.Show(
                "Se enviaron las credenciales al email " + email + ":\n\n" +
                "Usuario: " + nuevoUsuario + "\n" +
                "Contraseña: " + nuevaContrasena,
                "Simulación de envío de email",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            MessageBox.Show(
                "Usuario \"" + nuevoUsuario + "\" registrado correctamente.",
                "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarFormulario();
        }


        // Comprobar si el DNI ya está registrado en SQL Server
        private bool ExisteDniEnBD(string dni)
        {
            string query = "SELECT COUNT(*) FROM Usuarios WHERE Dni = @Dni";
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Dni", dni);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        // Restablecer los campos después del registro
        private void LimpiarFormulario()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDni.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            cboGenero.SelectedIndex = -1;
            cboTipoUsuario.SelectedIndex = -1;
            dtpFechaNacimiento.Value = DateTime.Now;
            lblError.Text = "";
            dtpFechaNacimiento.Checked = false;
        }

        #endregion

        #region Navegación del formulario

        // Volver al panel de administración
        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPrincipalAdmin frm = new frmPrincipalAdmin();

            Program.MostrarFormulario(frm);

            this.Close();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

    }
}

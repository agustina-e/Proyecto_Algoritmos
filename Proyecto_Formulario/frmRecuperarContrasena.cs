using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Formulario
{
    public partial class frmRecuperarContrasena : Form
    {
        // Índice del usuario que está recuperando su contraseña (-1 = todavía no validado)
        private int indiceUsuarioEnRecuperacion = -1;

        // Controla si ya se validó el código, para no permitir guardar sin ese paso
        private bool codigoValidado = false;

        // Código fijo de recuperación (hardcodeado, según la consigna)
        private const string CODIGO_RECUPERACION = "1234";

        public frmRecuperarContrasena()
        {
            InitializeComponent();
        }

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

            txtCodigo.Enabled = false;
            btnValidarCodigo.Enabled = false;
            txtNuevaContrasena.Enabled = false;
            txtConfirmarContrasena.Enabled = false;
            btnGuardar.Enabled = false;

            indiceUsuarioEnRecuperacion = -1;
            codigoValidado = false;
        }

        private void btnEnviarCodigo_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            string usuario = txtUsuarioRecuperar.Text.Trim();

            if (string.IsNullOrEmpty(usuario))
            {
                lblError.Text = "Debe ingresar un nombre de usuario.";
                return;
            }

            int indice = -1;
            for (int i = 0; i < DatosGlobales.usuarios.Count; i++)
            {
                if (DatosGlobales.usuarios[i] == usuario)
                {
                    indice = i;
                    break;
                }
            }

            if (indice == -1)
            {
                lblError.Text = "No existe un usuario con ese nombre.";
                return;
            }

            indiceUsuarioEnRecuperacion = indice;

            MessageBox.Show("Se envió un código a tu email registrado.", "Código enviado",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            lblEstadoProceso.Text = "Código enviado, ingresalo a continuación";

            // Habilitamos el paso siguiente, bloqueamos el usuario para que no lo cambie a mitad de camino
            txtUsuarioRecuperar.Enabled = false;
            btnEnviarCodigo.Enabled = false;
            txtCodigo.Enabled = true;
            btnValidarCodigo.Enabled = true;
        }

        private void btnValidarCodigo_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            // Defensa extra: no debería poder llegar acá sin haber pasado el paso 1
            if (indiceUsuarioEnRecuperacion == -1)
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            // Defensa extra: no debería poder llegar acá sin haber validado el código
            if (!codigoValidado || indiceUsuarioEnRecuperacion == -1)
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

            DatosGlobales.contrasenas[indiceUsuarioEnRecuperacion] = nueva;

            MessageBox.Show("Contraseña actualizada correctamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            frmLogin frm = new frmLogin();
            frm.Show();
            this.Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.Show();
            this.Close();
        }
    }
}

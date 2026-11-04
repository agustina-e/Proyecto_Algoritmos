
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Proyecto_Formulario
{
    public partial class frmPrincipalGeneral : Form
    {
        #region Controles dinámicos de jugadores

        // Mantener los controles dinámicos de los jugadores del equipo
        private List<JugadorControles> jugadores = new List<JugadorControles>();

        // Agrupar los controles correspondientes a cada jugador
        private class JugadorControles
        {
            public TextBox txtNombre;
            public TextBox txtApellido;
            public TextBox txtEdad;
            public TextBox txtDni;

            public JugadorControles(TextBox nombre, TextBox apellido, TextBox edad, TextBox dni)
            {
                txtNombre = nombre;
                txtApellido = apellido;
                txtEdad = edad;
                txtDni = dni;
            }
        }

        #endregion

        #region Inicialización del panel general

        // Inicializar los controles del panel general
        public frmPrincipalGeneral()
        {
            InitializeComponent();
        }

        // Configurar la interfaz y las opciones de inscripción
        private void frmPrincipalGeneral_Load(object sender, EventArgs e)
        {
            EstiloUI.AplicarBaseFormulario(this);
            EstiloUI.EstilizarTextoDestacado(lblBienvenida);
            EstiloUI.EstilizarBotonSecundario(btnCerrarSesion);
            EstiloUI.EstilizarBotonSecundario(btnEditarPerfil);

            EstiloUI.EstilizarEtiqueta(lblNombreEquipo);
            EstiloUI.EstilizarEtiqueta(lblCategoria);
            EstiloUI.EstilizarEtiqueta(lblCantidadJugadores);
            EstiloUI.EstilizarTextBox(txtNombreEquipo);
            EstiloUI.EstilizarBotonPrimario(btnInscribirme);
            EstiloUI.EstilizarBotonPrimario(btnGuardarEquipo);
            EstiloUI.EstilizarLabelError(lblEstado);

            lblBienvenida.Text = "¡Hola, " + DatosGlobales.usuarioActual + "!";
            lblEstado.Text = "";

            cboCategoria.Items.Clear();
            cboCategoria.Items.AddRange(new string[] { "Sub-15", "Sub-17", "Libre" });

            cboCantidadJugadores.Items.Clear();
            cboCantidadJugadores.Items.AddRange(new string[] { "5", "7", "9", "11" });

            flpJugadores.Controls.Clear();
            flpJugadores.Enabled = false;
            flpJugadores.TabStop = false;

            btnGuardarEquipo.Enabled = false;
        }

        #endregion

        #region Generación de fichas de inscripción

        // Validar los datos del equipo y generar las fichas de jugadores
        private void btnInscribirme_Click(object sender, EventArgs e)
        {
            lblEstado.Text = "";

            if (string.IsNullOrWhiteSpace(txtNombreEquipo.Text))
            {
                lblEstado.Text = "Debe ingresar el nombre del equipo.";
                return;
            }

            if (cboCategoria.SelectedItem == null)
            {
                lblEstado.Text = "Debe seleccionar una categoría.";
                return;
            }

            string? cantidadSeleccionada = cboCantidadJugadores.SelectedItem?.ToString();

            if (!int.TryParse(cantidadSeleccionada, out int cantidad))
            {
                lblEstado.Text = "La cantidad de jugadores seleccionada no es válida.";
                return;
            }

            // Generar una ficha para cada jugador
            jugadores.Clear();
            flpJugadores.Controls.Clear();

            for (int i = 0; i < cantidad; i++)
            {
                JugadorControles jugador = CrearFichaJugador(i + 1);

                jugadores.Add(jugador);
            }

            flpJugadores.Enabled = true;
            btnGuardarEquipo.Enabled = true;

            txtNombreEquipo.Enabled = false;
            cboCategoria.Enabled = false;
            cboCantidadJugadores.Enabled = false;
            btnInscribirme.Enabled = false;

            lblEstado.Text = "Completar los datos de los jugadores y presionar Guardar Equipo.";
        }

        // Crear el panel con los campos correspondientes a un jugador
        private JugadorControles CrearFichaJugador(int numero)
        {
            Panel panel = new Panel();

            panel.Width = flpJugadores.ClientSize.Width
              - SystemInformation.VerticalScrollBarWidth - 10;
            panel.Height = 100;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.BackColor = Color.White;
            panel.Margin = new Padding(3, 3, 3, 5);

            panel.TabIndex = numero - 1;
            panel.TabStop = false;

            Label lblTitulo = new Label();
            lblTitulo.Text = "Jugador " + numero;
            lblTitulo.Location = new Point(12, 5);
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            panel.Controls.Add(lblTitulo);

            int separacion = 15;
            int margen = 12;
            int anchoCampo = (panel.Width - (margen * 2) - (separacion * 3)) / 4;
            int posicionX = margen;

            TextBox nombre = CrearCampo(panel, "Nombre", posicionX, anchoCampo, 0);
            posicionX += anchoCampo + separacion;

            TextBox apellido = CrearCampo(panel, "Apellido", posicionX, anchoCampo, 1);
            posicionX += anchoCampo + separacion;

            TextBox edad = CrearCampo(panel, "Edad", posicionX, anchoCampo, 2);
            posicionX += anchoCampo + separacion;

            TextBox dni = CrearCampo(panel, "DNI", posicionX, anchoCampo, 3);

            flpJugadores.Controls.Add(panel);

            return new JugadorControles(nombre, apellido, edad, dni);
        }

        // Crear y configurar un campo de texto dentro de la ficha
        private TextBox CrearCampo(Panel panel, string titulo, int x, int ancho, int orden)
        {
            Label etiqueta = new Label();

            etiqueta.Text = titulo;
            etiqueta.Location = new Point(x, 27);
            etiqueta.AutoSize = true;
            etiqueta.Font = new Font("Segoe UI", 11);

            TextBox campo = new TextBox();

            campo.Location = new Point(x, 52);
            campo.Width = ancho;
            campo.Font = new Font("Segoe UI", 11);
            campo.TabIndex = orden;
            campo.TabStop = true;

            EstiloUI.EstilizarEtiqueta(etiqueta);
            EstiloUI.EstilizarTextBox(campo);

            etiqueta.Font = new Font("Segoe UI", 11);
            campo.Font = new Font("Segoe UI", 11);
            campo.Width = ancho;

            panel.Controls.Add(etiqueta);
            panel.Controls.Add(campo);

            return campo;
        }

        #endregion

        #region Validación y registro del equipo

        // Validar los jugadores y guardar el equipo en la base de datos
        private void btnGuardarEquipo_Click(object sender, EventArgs e)
        {
            lblEstado.Text = "";

            List<string[]> jugadoresValidados = new List<string[]>();
            List<string> dnisEnEsteEquipo = new List<string>();

            for (int i = 0; i < jugadores.Count; i++)
            {
                JugadorControles jugador = jugadores[i];

                string nombre = jugador.txtNombre.Text.Trim();
                string apellido = jugador.txtApellido.Text.Trim();
                string edadTexto = jugador.txtEdad.Text.Trim();
                string dni = jugador.txtDni.Text.Trim();

                int numeroFila = i + 1;

                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) ||
                    string.IsNullOrEmpty(edadTexto) || string.IsNullOrEmpty(dni))
                {
                    lblEstado.Text = "Jugador " + numeroFila + ": debe completar todos los campos.";
                    return;
                }

                if (!Validaciones.SoloLetras(nombre))
                {
                    lblEstado.Text = "Jugador " + numeroFila + ": el nombre solo puede contener letras.";
                    return;
                }

                if (!Validaciones.SoloLetras(apellido))
                {
                    lblEstado.Text = "Jugador " + numeroFila + ": el apellido solo puede contener letras.";
                    return;
                }

                int edad;

                if (!int.TryParse(edadTexto, out edad) || edad < 5 || edad > 60)
                {
                    lblEstado.Text = "Jugador " + numeroFila + ": la edad debe estar entre 5 y 60.";
                    return;
                }

                if (dni.Length != 8 || !Validaciones.SoloNumeros(dni))
                {
                    lblEstado.Text = "Jugador " + numeroFila + ": el DNI debe tener 8 dígitos numéricos.";
                    return;
                }

                if (dnisEnEsteEquipo.Contains(dni))
                {
                    lblEstado.Text = "Jugador " + numeroFila + ": hay un DNI repetido en el equipo.";
                    return;
                }

                dnisEnEsteEquipo.Add(dni);

                jugadoresValidados.Add(new string[]
                {
                    nombre,
                    apellido,
                    edad.ToString(),
                    dni
                });
            }

            string nombreEquipo = txtNombreEquipo.Text.Trim();
            string categoria = cboCategoria.SelectedItem?.ToString() ?? string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lblEstado.Text = "Debe seleccionar una categoría.";
                return;
            }
            int cantidadJugadores = jugadoresValidados.Count;

            string insertEquipoQuery = @"
                INSERT INTO Equipos (NombreEquipo, Categoria, CantidadJugadores)
                VALUES (@NombreEquipo, @Categoria, @CantidadJugadores);
                SELECT SCOPE_IDENTITY();";

            int idEquipoNuevo = 0;

            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();

                    using (SqlTransaction transaccion = conexion.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand cmdEquipo = new SqlCommand(insertEquipoQuery, conexion, transaccion))
                            {
                                cmdEquipo.Parameters.AddWithValue("@NombreEquipo", nombreEquipo);
                                cmdEquipo.Parameters.AddWithValue("@Categoria", categoria);
                                cmdEquipo.Parameters.AddWithValue("@CantidadJugadores", cantidadJugadores);

                                idEquipoNuevo = Convert.ToInt32(cmdEquipo.ExecuteScalar());
                            }

                            string insertJugadorQuery = @"
                    INSERT INTO Jugadores (Nombre, Apellido, Edad, Dni, IdEquipo)
                    VALUES (@Nombre, @Apellido, @Edad, @Dni, @IdEquipo)";

                            foreach (string[] jugador in jugadoresValidados)
                            {
                                using (SqlCommand cmdJugador = new SqlCommand(insertJugadorQuery, conexion, transaccion))
                                {
                                    cmdJugador.Parameters.AddWithValue("@Nombre", jugador[0]);
                                    cmdJugador.Parameters.AddWithValue("@Apellido", jugador[1]);
                                    cmdJugador.Parameters.AddWithValue("@Edad", int.Parse(jugador[2]));
                                    cmdJugador.Parameters.AddWithValue("@Dni", jugador[3]);
                                    cmdJugador.Parameters.AddWithValue("@IdEquipo", idEquipoNuevo);

                                    cmdJugador.ExecuteNonQuery();
                                }
                            }

                            transaccion.Commit();
                        }
                        catch
                        {
                            transaccion.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (SqlException ex) when (ex.Number == 2601 || ex.Number == 2627)
            {
                lblEstado.Text = "Ya existe un equipo con ese nombre. Ingrese otro nombre.";
                return;
            }
            catch (Exception)
            {
                lblEstado.Text = "No se pudo guardar el equipo. Intente nuevamente.";
                return;
            }

            MessageBox.Show(
                "Equipo \"" + nombreEquipo + "\" registrado correctamente con " +
                jugadoresValidados.Count + " jugadores.",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ReiniciarFormulario();
        }

        // Restablecer los controles para registrar otro equipo
        private void ReiniciarFormulario()
        {
            txtNombreEquipo.Text = "";
            txtNombreEquipo.Enabled = true;

            cboCategoria.SelectedIndex = -1;
            cboCategoria.Enabled = true;

            cboCantidadJugadores.SelectedIndex = -1;
            cboCantidadJugadores.Enabled = true;

            btnInscribirme.Enabled = true;

            jugadores.Clear();
            flpJugadores.Controls.Clear();
            flpJugadores.Enabled = false;

            btnGuardarEquipo.Enabled = false;

            lblEstado.Text = "";
        }

       
        #endregion

        #region Navegación del usuario general

        // Cerrar la sesión y volver al formulario de inicio
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Program.VolverAlLogin();
            this.Close();
        }

        // Abrir el formulario de edición del perfil
        private void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            frmEditarPerfil frm = new frmEditarPerfil();

            Program.MostrarFormulario(frm);

            this.Close();
        }
        #endregion

    }
}

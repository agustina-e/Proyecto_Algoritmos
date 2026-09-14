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
    public partial class frmPrincipalAdmin : Form
    {
        public frmPrincipalAdmin()
        {
            InitializeComponent();
        }

        private void frmPrincipalAdmin_Load(object sender, EventArgs e)
        {
            EstiloUI.AplicarBaseFormulario(this);
            EstiloUI.EstilizarTextoDestacado(lblBienvenida);
            EstiloUI.EstilizarBotonSecundario(btnCerrarSesion);
            EstiloUI.EstilizarBotonSecundario(btnEditarPerfil);
            EstiloUI.EstilizarBotonPrimario(btnRegistrarUsuario);
            EstiloUI.EstilizarGrilla(dgvEquipos);
            EstiloUI.EstilizarLabelError(lblEstado);

            lblBienvenida.Text = "¡Hola, " + DatosGlobales.usuarioActual + "!";
            lblEstado.Text = "";

            dgvEquipos.Columns.Clear();

            // Columna oculta para almacenar el IdEquipo de SQL Server
            dgvEquipos.Columns.Add("colIdEquipo", "ID");
            dgvEquipos.Columns["colIdEquipo"].Visible = false;

            dgvEquipos.Columns.Add("colNombreEquipo", "Equipo");
            dgvEquipos.Columns.Add("colCategoria", "Categoría");
            dgvEquipos.Columns.Add("colCantidadJugadores", "Jugadores");

            DataGridViewButtonColumn colEliminar = new DataGridViewButtonColumn();
            colEliminar.Name = "colEliminar";
            colEliminar.HeaderText = "";
            colEliminar.Text = "Eliminar";
            colEliminar.UseColumnTextForButtonValue = true; // todos los botones muestran "Eliminar"
            dgvEquipos.Columns.Add(colEliminar);

            // Las columnas de datos no se editan a mano; solo el botón es interactivo
            dgvEquipos.Columns["colNombreEquipo"].ReadOnly = true;
            dgvEquipos.Columns["colCategoria"].ReadOnly = true;
            dgvEquipos.Columns["colCantidadJugadores"].ReadOnly = true;

            CargarEquipos();
        }

        private void CargarEquipos()
        {
            dgvEquipos.Rows.Clear();

            // Cargar los equipos desde SQL Server
            string query = "SELECT IdEquipo, NombreEquipo, Categoria, CantidadJugadores FROM Equipos";

            int totalEquipos = 0;

            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                totalEquipos++;
                                dgvEquipos.Rows.Add(
                                    reader["IdEquipo"],
                                    reader["NombreEquipo"].ToString() ?? "",
                                    reader["Categoria"].ToString() ?? "",
                                    reader["CantidadJugadores"]
                                // la 5ta columna (botón) no necesita valor: UseColumnTextForButtonValue ya la completa
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Error al cargar equipos de la base de datos: " + ex.Message;
                return;
            }

            if (totalEquipos == 0)
            {
                lblEstado.Text = "Todavía no hay equipos registrados.";
            }
            else
            {
                lblEstado.Text = "";
            }
        }
        

        private void dgvEquipos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignoramos clics en encabezados (RowIndex = -1) o en columnas que no son el botón
            if (e.RowIndex < 0) return;
            if (dgvEquipos.Columns[e.ColumnIndex].Name != "colEliminar") return;

            // Obtenemos los datos de la fila seleccionada en el DataGridView
            var celdaNombre = dgvEquipos.Rows[e.RowIndex].Cells["colNombreEquipo"].Value;
            var celdaId = dgvEquipos.Rows[e.RowIndex].Cells["colIdEquipo"].Value;

            string nombreEquipo = celdaNombre?.ToString() ?? "";
            int idEquipo = Convert.ToInt32(celdaId);

            DialogResult confirmacion = MessageBox.Show(
                "¿Eliminar el equipo \"" + nombreEquipo + "\"? Esta acción no se puede deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion != DialogResult.Yes) return;

            // Eliminar equipo en SQL Server
            string deleteQuery = "DELETE FROM Equipos WHERE IdEquipo = @IdEquipo";

            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conexion))
                    {
                        cmd.Parameters.AddWithValue("@IdEquipo", idEquipo);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Error al eliminar el equipo: " + ex.Message;
                return;
            }

            CargarEquipos();

            MessageBox.Show("Equipo eliminado correctamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DatosGlobales.usuarioActual = "";
            DatosGlobales.rolActual = "";

            frmLogin frm = new frmLogin();
            frm.Show();
            this.Close();
        }

        private void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            frmEditarPerfil frm = new frmEditarPerfil();
            frm.Show();
            this.Close();
        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            frmRegistrarUsuario frm = new frmRegistrarUsuario();
            frm.Show();
            this.Close();
        }
    }
}

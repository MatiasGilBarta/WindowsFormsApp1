using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Configuration;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        ListarStock _e;
        public Form1()
        {
            InitializeComponent();
            _e = new ListarStock();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnIngresarRepuesto_Click(object sender, EventArgs e)
        {
            try
            {
                Stock nuevoStock = new Stock(
                    0,  // Id_stock no se envía porque es autonumerado
                    int.Parse(Interaction.InputBox("Nro de repuesto: ")),
                    Interaction.InputBox("Nombre del repuesto: "),
                    Interaction.InputBox("Descripcion: "),
                    int.Parse(Interaction.InputBox("Cantidad: "))
                );

                _e.AgregarStock(nuevoStock);
                Mostrar(dataGridView1, _e.RetornarStock());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Mostrar(DataGridView pDGV, Object pObject)
        {
            pDGV.DataSource = null;
            pDGV.DataSource = pObject;
        }

        private void btnDesahbilitarRepuesto_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int idStock = ((Stock)dataGridView1.SelectedRows[0].DataBoundItem).Id_stock;
                    _e.BorrarStock(idStock);
                    Mostrar(dataGridView1, _e.RetornarStock());
                }
                else
                {
                    MessageBox.Show("No hay registros para borrar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificarRepuesto_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    Stock stock = (Stock)dataGridView1.SelectedRows[0].DataBoundItem;
                    stock.Nombre_repuesto = Interaction.InputBox("Ingrese nombre del repuesto", "", stock.Nombre_repuesto);
                    stock.Descripcion = Interaction.InputBox("Ingrese descripcion del repuesto", "", stock.Descripcion);
                    stock.Cantidad = int.Parse(Interaction.InputBox("Ingrese la cantidad", "", stock.Cantidad.ToString()));

                    _e.ModificarStock(stock);
                    Mostrar(dataGridView1, _e.RetornarStock());
                }
                else
                {
                    MessageBox.Show("No hay registros para modificar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public class ListarStock
        {
            private string connectionString;

            public ListarStock()
            {
                connectionString = ConfigurationManager.ConnectionStrings["ProyectoGestor"].ConnectionString;
            }

            // 🟢 Método para Agregar un Stock a la base de datos
            public void AgregarStock(Stock pStock)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Stock (Nro_repuesto, Nombre_repuesto, Descripcion, Cantidad) " +
                                   "VALUES (@NroRepuesto, @Nombre, @Descripcion, @Cantidad)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NroRepuesto", pStock.Nro_repuesto);
                    cmd.Parameters.AddWithValue("@Nombre", pStock.Nombre_repuesto);
                    cmd.Parameters.AddWithValue("@Descripcion", pStock.Descripcion);
                    cmd.Parameters.AddWithValue("@Cantidad", pStock.Cantidad);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            // 🔵 Método para Listar los Stocks desde la base de datos
            public List<Stock> RetornarStock()
            {
                List<Stock> listaStock = new List<Stock>();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Id_stock, Nro_repuesto, Nombre_repuesto, Descripcion, Cantidad FROM Stock";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        listaStock.Add(new Stock(
                            reader.GetInt32(0),  // Id_stock (Autonumerado)
                            reader.GetInt32(1),  // Nro_repuesto
                            reader.GetString(2), // Nombre_repuesto
                            reader.GetString(3), // Descripcion
                            reader.GetInt32(4)   // Cantidad
                        ));
                    }
                }
                return listaStock;
            }

            // 🟠 Método para Eliminar un Stock
            public void BorrarStock(int idStock)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Stock WHERE Id_stock = @IdStock";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdStock", idStock);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            // 🔴 Método para Modificar un Stock
            public void ModificarStock(Stock pStock)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Stock SET Nombre_repuesto = @Nombre, Descripcion = @Descripcion, Cantidad = @Cantidad " +
                                   "WHERE Id_stock = @IdStock";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdStock", pStock.Id_stock);
                    cmd.Parameters.AddWithValue("@Nombre", pStock.Nombre_repuesto);
                    cmd.Parameters.AddWithValue("@Descripcion", pStock.Descripcion);
                    cmd.Parameters.AddWithValue("@Cantidad", pStock.Cantidad);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public class Stock
        {
            public int Id_stock { get; set; }  // Ahora tiene el ID autonumerado
            public int Nro_repuesto { get; set; }
            public string Nombre_repuesto { get; set; }
            public string Descripcion { get; set; }
            public int Cantidad { get; set; }

            public Stock(int pId_stock, int pNro_repuesto, string pNombre_repuesto, string pDescripcion, int pCantidad)
            {
                Id_stock = pId_stock;
                Nro_repuesto = pNro_repuesto;
                Nombre_repuesto = pNombre_repuesto;
                Descripcion = pDescripcion;
                Cantidad = pCantidad;
            }
        }
    }
}

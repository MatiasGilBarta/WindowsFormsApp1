using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL.Helpers
{
   /* public class SQLHelper
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
        }
    }*/
}
        /*public class ListarStock
        {
            private string connectionString;

            public ListarStock() //esta clase no la pudimos pasar, atencion a eso
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
}*/

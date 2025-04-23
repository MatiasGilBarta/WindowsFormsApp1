using DAL.Interfaces;
using Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Helpers;

namespace DAL.Implementations.SQLServer
{
    internal class StockRepository : IStockRepository
    {
        
        private readonly string connectionString;

        public StockRepository(string connectionString)
        {
            this.connectionString = connectionString;
            //implementamos un constructor para las conexiones a bases de datos
        }
        // aqui creo que para esto podriamos implemetar un singleton para la conexion a la base de datos

        public void Add(Stock pStock)
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

        public void Delete(int idStock)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Stock WHERE Id_stock = @IdStock";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdStock", idStock);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Stock> GetAll()
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

        public Stock GetbyId(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Stock pStock)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Stock SET Nombre_repuesto = @Nombre, Descripcion = @Descripcion, Cantidad = @Cantidad " +
                               "WHERE Id_stock = @IdStock";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdStock", pStock.Id_stock); //no deberia se numero repuesto en vez de id stock??
                cmd.Parameters.AddWithValue("@Nombre", pStock.Nombre_repuesto);
                cmd.Parameters.AddWithValue("@Descripcion", pStock.Descripcion);
                cmd.Parameters.AddWithValue("@Cantidad", pStock.Cantidad);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

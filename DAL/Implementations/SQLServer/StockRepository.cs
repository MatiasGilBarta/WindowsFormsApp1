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
using DAL.Tools;
using System.Data;
using DAL.Implementations.SQLServer.Adapters;

namespace DAL.Implementations.SQLServer
{
    internal class StockRepository : IStockRepository
    {


        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Stock] (Nro_repuesto, Nombre_repuesto, Descripcion, Cantidad) VALUES (@Nro_Repuesto, @Nombre, @Descripcion, @Cantidad)";
        }

        private string UpdateStatement
        {
            get => "UPDATE [dbo].[Stock] SET Nro_repuesto = @Nro_Repuesto, Nombre_repuesto = @Nombre, Descripcion = @Descripcion, Cantidad = @Cantidad WHERE Id_stock  = @Id_stock";
        }

        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[Stock] WHERE Id_stock = @Id_stock";
        }

        private string SelectOneStatement
        {
            get => "SELECT Id_stock, Nro_repuesto, Nombre_repuesto, Descripcion, Cantidad FROM [dbo].[Stock] WHERE Id_stock = @Id_stock";
        }

        private string SelectAllStatement
        {
            get => "SELECT Id_stock, Nro_repuesto, Nombre_repuesto, Descripcion, Cantidad FROM [dbo].[Stock]";
        }
        #endregion

        public void Add(Stock entity)
        {
            try
            {
                //Para Stored procedures se puede utilizar SELECT SCOPE_IDENTITY()
                object returnValue = SQLHelper.ExecuteScalar(InsertStatement, CommandType.Text,
                  new SqlParameter[] { new SqlParameter("@Nro_repuesto", entity.Nro_repuesto),
                                       new SqlParameter("@Nombre", entity.Nombre_repuesto),
                                       new SqlParameter("@Descripcion", entity.Descripcion),
                                       new SqlParameter("@Cantidad", entity.Cantidad) });

                /*entity.Id_stock = Guid.Parse(returnValue.ToString()); esta linea del profe la comentamos pq me estaba dando error*/
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public void Delete(Guid id)
        {

            //No se recomienda ejecutar delete directamente, aplicar update 
            //sobre algún campo "Habilitado", "Activo" = false
            //Persistir de alguna manera, fecha de baja, motivo, etc.
            throw new NotImplementedException();
        }

        public IEnumerable<Stock> GetAll()
        {
            List<Stock> listCustomers = new List<Stock>();

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SelectAllStatement,
                                                    CommandType.Text,
                                                    new SqlParameter[] { }))
            {

                //Mientras tenga un registro para la lectura...avanzo
                while (reader.Read())
                {
                    //Leemos cada tupla de la tabla
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    Stock stock = StockAdapter.Current.Get(data);
                    listCustomers.Add(stock);
                }
            }

            return listCustomers;
        }

        public IEnumerable<Stock> GetByCreationDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Stock GetbyId(Guid id)
        {
            Stock customer = default;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SelectOneStatement,
                                                 CommandType.Text,
                                                 new SqlParameter[] {
                                                     new SqlParameter("@Id_stock", id) }))
            {

                //Hacemos la lectura de un solo registro
                if (reader.Read())
                {
                    //Leemos cada tupla de la tabla
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    customer = StockAdapter.Current.Get(data);
                }
            }

            return customer;
        }

        public void Update(Stock entity)
        {
            try
            {
                int filasAfectadas = SQLHelper.ExecuteNonQuery(UpdateStatement, CommandType.Text,
                                     new SqlParameter[] {
                                             new SqlParameter("@Nro_repuesto", entity.Nro_repuesto),
                                             new SqlParameter("@Nombre", entity.Nombre_repuesto),
                                             new SqlParameter("@Descripcion", entity.Descripcion),
                                             new SqlParameter("@Cantidad", entity.Cantidad),
                                             new SqlParameter("@Id_stock", entity.Id_stock) });

                if (filasAfectadas == 0) new Exception("Algún problemita");

                Console.WriteLine($"Filas afectadas: {filasAfectadas.ToString()}");
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        //version anterior que no usaba ni sql helper ni, adapter

        /*public StockRepository(string connectionString)
        {
            this.connectionString = connectionString;
            //implementamos un constructor para las conexiones a bases de datos
        }
        // aqui creo que para esto podriamos implemetar un singleton para la conexion a la base de datos

        private readonly string connectionString;
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
        }*/
    }
}

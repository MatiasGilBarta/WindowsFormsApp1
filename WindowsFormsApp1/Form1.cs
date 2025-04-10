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
using System.Data.SqlClient;
using System.Configuration;
using Domain;
using BLL;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        

        private readonly StockService _stockService;
        public Form1()
        {
            InitializeComponent();
            _stockService = new StockService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Mostrar(dataGridView1, _stockService.ObtenerStock());
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

                _stockService.AgregarStock(nuevoStock);
                Mostrar(dataGridView1, _stockService.ObtenerStock());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Mostrar(DataGridView pDGV, IEnumerable<Stock> pStockList)
        {
            pDGV.DataSource = null;
            pDGV.DataSource = pStockList.ToList();
        }

        private void btnDesahbilitarRepuesto_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int idStock = ((Stock)dataGridView1.SelectedRows[0].DataBoundItem).Id_stock;
                    _stockService.EliminarStock(idStock);
                    Mostrar(dataGridView1, _stockService.ObtenerStock());
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

                    _stockService.ModificarStock(stock);
                    Mostrar(dataGridView1, _stockService.ObtenerStock());
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

        
    }
}

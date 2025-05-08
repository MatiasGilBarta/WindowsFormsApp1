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
using BLL.Servicies;

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
            Mostrar(dataGridView1, _stockService.GetAll());
        }

        private void btnIngresarRepuesto_Click(object sender, EventArgs e)
        {
            try
            {
                Stock nuevoStock = new Stock
                {
                    // Id_stock se deja como default (Guid.Empty) si lo maneja la BD
                    Nro_repuesto = int.Parse(Interaction.InputBox("Nro de repuesto: ")),
                    Nombre_repuesto = Interaction.InputBox("Nombre del repuesto: "),
                    Descripcion = Interaction.InputBox("Descripcion: "),
                    Cantidad = int.Parse(Interaction.InputBox("Cantidad: "))
                };
                    // esto es lo que usabamos antes de Adapter
                    /*(
                    Guid.Empty,  // Id_stock no se envía porque es autonumerado
                    int.Parse(Interaction.InputBox("Nro de repuesto: ")),
                    Interaction.InputBox("Nombre del repuesto: "),
                    Interaction.InputBox("Descripcion: "),
                    int.Parse(Interaction.InputBox("Cantidad: "))
                );*/

                _stockService.Add(nuevoStock);
                Mostrar(dataGridView1, _stockService.GetAll());
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
                    Stock seleccionado = (Stock)dataGridView1.SelectedRows[0].DataBoundItem;

                    if (seleccionado.Id_stock == Guid.Empty)
                    {
                        MessageBox.Show("Este repuesto no tiene un ID válido para ser eliminado.");
                        return;
                    }

                    _stockService.Delete(seleccionado.Id_stock);
                    Mostrar(dataGridView1, _stockService.GetAll());
                }
                else
                {
                    MessageBox.Show("No hay registros seleccionados.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
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

                    _stockService.Update(stock);
                    Mostrar(dataGridView1, _stockService.GetAll());
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

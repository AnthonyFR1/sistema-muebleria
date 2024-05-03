using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplicacion;

namespace Presentacion.Consultas
{
    public partial class FormConsultaProducto : Form
    {
        GestionarProductoServicio gestionarProductoServicio = new GestionarProductoServicio();
        

        public FormConsultaProducto()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void ConfigurarColumnasDataGridView()
        {


            this.tableProducto.DataSource = gestionarProductoServicio.ListarProductos();
            this.tableProducto.AutoGenerateColumns = false;

        }
        private void AlternarColores(DataGridView datagrid)
        {

            datagrid.AlternatingRowsDefaultCellStyle.BackColor = Color.Gold;

        }
        private void FormConsultaProducto_Load(object sender, EventArgs e)
        {
            ConfigurarColumnasDataGridView();
            AlternarColores(tableProducto);
        }

        private void tableProducto_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FormRealizarVenta formRealizarVenta = FormRealizarVenta.GetInstancia();
                string codigobarras, nombre;
                int stockactual;
                double precio;

                codigobarras = Convert.ToString(this.tableProducto.CurrentRow.Cells["codigobarras"].Value);
                nombre = Convert.ToString(this.tableProducto.CurrentRow.Cells["nombre"].Value);
                stockactual = Convert.ToInt32(this.tableProducto.CurrentRow.Cells["stockactual"].Value);
                precio = Convert.ToInt32(this.tableProducto.CurrentRow.Cells["precio"].Value);

                formRealizarVenta.setProducto(codigobarras, nombre, stockactual, precio);
                this.Hide();

            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }
    }
}

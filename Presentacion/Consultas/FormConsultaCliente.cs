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
    public partial class FormConsultaCliente : Form
    {
        GestionarClienteServicio gestionarClienteServicio = new GestionarClienteServicio();
        public FormConsultaCliente()
        {
            InitializeComponent();
        }
        private void ConfigurarColumnasDataGridView()
        {
            this.tableCliente.DataSource = gestionarClienteServicio.ListarClientes();
            this.tableCliente.AutoGenerateColumns = false;
        }
        private void AlternarColores(DataGridView datagrid)
        {
            datagrid.AlternatingRowsDefaultCellStyle.BackColor = Color.Gold;
        }
        private void FormConsultaCliente_Load(object sender, EventArgs e)
        {
            ConfigurarColumnasDataGridView();
            AlternarColores(tableCliente);
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void tableCliente_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FormRealizarVenta formRealizarVenta = FormRealizarVenta.GetInstancia();
                string nombres;
                int id;
                id = Convert.ToInt32(this.tableCliente.CurrentRow.Cells["idcliente"].Value);
                nombres = Convert.ToString(this.tableCliente.CurrentRow.Cells["nombres"].Value);
                formRealizarVenta.setCliente(id,nombres);
                this.Hide();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
          
        }
        private void tableCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

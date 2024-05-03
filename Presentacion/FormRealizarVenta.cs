using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentacion.Consultas;
using Dominio;
using Aplicacion;

namespace Presentacion
{
    public partial class FormRealizarVenta : Form
    {
        DetalleProducto detalleProducto = new DetalleProducto();
        DataTable detalle;
        RealizarVentaServicio realizarVenta = new RealizarVentaServicio();
        public int Idtrabajador;

        public void setCliente(int id,string nombres)
        {
            this.txtidcliente.Text = Convert.ToString(id);
            this.txtNombreCliente.Text = nombres;
            //  MessageBox.Show(id,nombre);
        }

        public void setProducto(string codigoBarras, string nombre, int stockactual, double precio)
        {
            this.txtCodigoBarras.Text = codigoBarras;
            this.txtNombreProducto.Text = nombre;
            this.txtStock.Text = Convert.ToString(stockactual);
            this.txtPrecio.Text = Convert.ToString(precio);
        }


        #region Singleton
        private static FormRealizarVenta _instancia;
        public static FormRealizarVenta GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new FormRealizarVenta();
            }
            return _instancia;
        }
        #endregion
    
        public FormRealizarVenta()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
           
            _instancia = null;
            this.Dispose();
        }


        private void btnBuscarClienteVenta_Click(object sender, EventArgs e)
        {
            FormConsultaCliente formConsultaCliente = new FormConsultaCliente();
            formConsultaCliente.ShowDialog();
        }

        public void Limpiar()
        {
            this.txtNombreCliente.Text = "";
            this.txtNombreProducto.Text = "";
            this.txtPrecio.Text = "";
            this.txtStock.Text = "";
            this.txtCodigoBarras.Text = "";
            this.txtStockActual.Text = "";
            this.txtTotal.Text = "";
        }
        public void LimpiarDetalleVenta()
        {
           
            this.txtNombreProducto.Text = "";
            this.txtPrecio.Text = "";
            this.txtStock.Text = "";
            this.txtCodigoBarras.Text = "";
            this.txtStockActual.Text = "";
            this.txtTotal.Text = "";
        }
        public void Desabilitar()
        {
            this.txtNombreCliente.Enabled = false;
            this.txtNombreProducto.Enabled = false;
            this.txtPrecio.Enabled = false;
            this.txtStock.Enabled = false;
            this.txtCodigoBarras.Enabled = false;
            this.btnBuscarClienteVenta.Enabled = false;
            this.btnProductoVenta.Enabled = false;
            this.txtStockActual.Enabled = false;
            this.txtTotal.Enabled = false;
            this.cbTipoDocumento.Enabled = false;
            this.dtFechaVenta.Enabled = false;
            this.btnAgregarProducto.Enabled = false;
            this.btnQuitarProducto.Enabled = false;
            this.txtSerie.ReadOnly = false;
            this.txtNumeroVenta.ReadOnly = false;
            this.txtSerie.Enabled = false;
            this.txtNumeroVenta.Enabled = false;
            this.btnGenerarVenta.Enabled = false;
            this.btnImporte.Enabled = false;
            this.btnRecibo.Enabled = false;
        }

        public void EvitarEscritura(bool valor)
        {
            this.txtPrecio.ReadOnly = !valor;
            this.txtCodigoBarras.ReadOnly = !valor;
            this.txtNombreProducto.ReadOnly = !valor;
            this.txtStock.ReadOnly = !valor;
        }

        public void Habilitar()
        {
            this.txtNombreProducto.Enabled = true;
            this.txtPrecio.Enabled = true;
            this.txtStock.Enabled = true;
            this.txtCodigoBarras.Enabled = true;
            this.btnBuscarClienteVenta.Enabled = true;
            this.btnProductoVenta.Enabled = true;
            this.btnGenerarVenta.Enabled = true;
            this.btnImporte.Enabled = true;
            this.btnRecibo.Enabled = true;
            this.txtStockActual.Enabled = true;
            this.txtTotal.Enabled = true;
            this.cbTipoDocumento.Enabled = true;
            this.dtFechaVenta.Enabled = true;
            this.btnAgregarProducto.Enabled = true;
            this.btnQuitarProducto.Enabled = true;
        }
        private void AlternarColores(DataGridView datagrid)
        {

            datagrid.AlternatingRowsDefaultCellStyle.BackColor = Color.Gold;

        }
        private void FormRealizarVenta_Load(object sender, EventArgs e)
        {
            Desabilitar();
            CrearTabla();
            EvitarEscritura(false);
            AlternarColores(tableventadetalle);
            this.txtNombreCliente.Text = "PUBLICO EN GENERAL";
        }

        private void btnProductoVenta_Click(object sender, EventArgs e)
        {
            FormConsultaProducto formConsultaProducto = new FormConsultaProducto();
            formConsultaProducto.ShowDialog();
        }

        private void FormRealizarVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Habilitar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Desabilitar();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCantidad_KeyPress_1(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtCantidad_KeyUp(object sender, KeyEventArgs e)
        {
         
        }

        private void txtCantidad_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void txtCantidad_MouseCaptureChanged(object sender, EventArgs e)
        {
        
        }
        public double CalcularTotalPorIngresoDeProducto()
        {

            double precio = 0; 
            double total = 0;
            int stockactual;

            stockactual = (int)txtStockActual.Value;
            precio= double.Parse(txtPrecio.Text);

            detalleProducto.Precio = precio;
            total = detalleProducto.CalcularTotalPorIngresoDeProducto(stockactual);
            return total;
            
        }
        private void txtCantidad_MouseDown(object sender, MouseEventArgs e)
        {
            if(this.txtPrecio.Text==string.Empty)
               MessageBox.Show("¡Complete los campos vacios!", "Muebleria - B.Paredes", MessageBoxButtons.OK, MessageBoxIcon.Question);
            else
               txtTotal.Text = Convert.ToString(CalcularTotalPorIngresoDeProducto());
        }

        private void txtCantidad_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.txtPrecio.Text == string.Empty)
                MessageBox.Show("¡Complete los campos vacios!", "Muebleria - B.Paredes", MessageBoxButtons.OK, MessageBoxIcon.Question);
            else
                txtTotal.Text = Convert.ToString(CalcularTotalPorIngresoDeProducto());
        }
        private void CrearTabla()
        {
            this.detalle = new DataTable("detalleventa");
            this.detalle.Columns.Add("cod.barras", System.Type.GetType("System.String"));
            this.detalle.Columns.Add("nombre", System.Type.GetType("System.String"));
            this.detalle.Columns.Add("cantidad", System.Type.GetType("System.Int32"));
            this.detalle.Columns.Add("precioventa", System.Type.GetType("System.Decimal"));
            this.detalle.Columns.Add("descuento", System.Type.GetType("System.Decimal"));
            this.detalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));
            this.detalle.Columns.Add("Impuesto", System.Type.GetType("System.Decimal"));
            //Relacionar nuestro DataGRidView con nuestro DataTable
            this.tableventadetalle.DataSource = this.detalle;

        }
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            DataRow row = this.detalle.NewRow();
            if(this.txtNombreProducto.Text == string.Empty )
            {
                MessageBox.Show("¡Complete los campos vacios!", "Muebleria - B.Paredes", MessageBoxButtons.OK, MessageBoxIcon.Question);

            }
            else
            {
                row["cod.barras"] = this.txtCodigoBarras.Text;
                row["nombre"] = this.txtNombreProducto.Text;
                row["cantidad"] = this.txtStockActual.Value;
                row["precioventa"] = this.txtPrecio.Text;
                row["subtotal"] = this.txtTotal.Text;
                this.detalle.Rows.Add(row);
                LimpiarDetalleVenta();
            }
          
        }

        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {
            int indiceFila = this.tableventadetalle.CurrentCell.RowIndex;
            DataRow row = this.detalle.Rows[indiceFila];

            this.detalle.Rows.Remove(row);
        }

        private void txtStockActual_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnGenerarVenta_Click(object sender, EventArgs e)
        {
            Venta venta = new Venta();
            LineaDeVenta lineaDeVenta = new LineaDeVenta();
            List<LineaDeVenta> listaLineaDeVenta = new List<LineaDeVenta>();
            List<DetalleProducto> listaDetalleProducto = new List<DetalleProducto>();
            Cliente cliente = new Cliente();
            Trabajador trabajador = new Trabajador();
            Persona persona = new Persona();
            //Agregar al carrito de compras - agregar a la lista
            DetalleProducto detalleProducto = new DetalleProducto();
            /*detalleProducto.Producto.CodigoBarras = txtCodigoBarras.Text;
            detalleProducto.Producto.Nombre = txtNombreProducto.Text;*/
            //detalleProducto.Precio = double.Parse(txtPrecio.Text);
            //detalleProducto.Cantidad = (int)txtStockActual.Value;

            //lineaDeVenta.Cantidad = int.Parse(txtStockActual.Value);
            //lineaDeVenta.Precio= double.Parse(txtPrecio.Text);

            venta.Fecha = dtFechaVenta.Value;
            cliente.IdCliente = Convert.ToInt32(txtidcliente.Text);
            trabajador.IdTrabajador = Idtrabajador;

            //Agregar a una lista el detalle de la venta
            //listaDetalleProducto.Add(detalleProducto);
            listaLineaDeVenta.Add(lineaDeVenta);
            //Referenciar clases a la clase venta
            venta.Cliente = cliente;
            venta.ListaLineaDeVenta = listaLineaDeVenta;
            venta.Trabajador = trabajador;       
            //lineaDeVenta.ListaDetalleProducto = listaDetalleProducto;
            venta.ListaLineaDeVenta = listaLineaDeVenta;

            bool inserto = realizarVenta.RegistrarVenta(venta);
            
            if (inserto)
            {
                MessageBox.Show("¡Venta registrada con éxito!", "Muebleria - B.Paredes", MessageBoxButtons.OK, MessageBoxIcon.Question);
                Limpiar();
                Desabilitar();
            }
            else
            {
                MessageBox.Show("¡Error al registrar venta!", "Muebleria - B.Paredes", MessageBoxButtons.OK, MessageBoxIcon.Question);

            }

        }
    }
}
 
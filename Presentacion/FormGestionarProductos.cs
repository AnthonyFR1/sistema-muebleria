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
using Dominio;
namespace Presentacion
{
    public partial class FormGestionarProductos : Form
    {
        GestionarProductoServicio gestionarArticuloServicio = new GestionarProductoServicio();
        
        public FormGestionarProductos()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            tbArticulos.SelectedIndex = 1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tbArticulos.SelectedIndex = 0;
        }

        public void CargarTipoMadera()
        {
            cbTipoMadera.DataSource = gestionarArticuloServicio.ListarMadera();
            cbTipoMadera.ValueMember = "idmadera";
            cbTipoMadera.DisplayMember = "nombre";
        }

        public void CargarPresentacion()
        {
            cbPresentacion.DataSource = gestionarArticuloServicio.ListarPresentacion();
            cbPresentacion.ValueMember = "idpresentacion";
            cbPresentacion.DisplayMember = "nombre";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            Madera madera = new Madera();
            PresentacionProducto presentacion = new PresentacionProducto();
            DetalleProducto detalleArticulo = new DetalleProducto();
            List<DetalleProducto> listaDetalleArticulo = new List<DetalleProducto>();

            madera.IdMadera = Convert.ToInt32(cbTipoMadera.SelectedValue);
            presentacion.IdPresentacion = Convert.ToInt32(cbPresentacion.SelectedValue);

            producto.CodigoBarras = txtCodigo.Text;
            producto.Nombre = txtNombres.Text;
            producto.Descripcion = txtDescripcion.Text;
            producto.Serie = txtSerie.Text;

            detalleArticulo.Cantidad = int.Parse(txtCantidad.Text);
            detalleArticulo.Precio = int.Parse(txtPrecio.Text);
            listaDetalleArticulo.Add(detalleArticulo);

            producto.Madera = madera;
            producto.PresentacionProducto = presentacion;
            producto.ListaDetalleProducto = listaDetalleArticulo;

            bool inserta = gestionarArticuloServicio.RegistrarProducto(producto);
            if (this.txtNombres.Text == string.Empty) { 

                MessageBox.Show("¡Complete los campos vacios!", "Muebleria - VillaCorta", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else{

                if (inserta)
                {

                    MessageBox.Show("¡REGISTRO   EXITOSO!", "Muebleria - VillaCorta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    tbArticulos.SelectedIndex = 0;
                    ConfigurarColumnasDataGridView();
                }
                else
                {
                    MessageBox.Show("¡ERROR   AL   REGISTRAR!", "Muebleria - VillaCorta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void Limpiar()
        {
            this.txtNombres.Text = "";
            this.txtSerie.Text = "";
            this.txtDescripcion.Text = "";
            this.txtCodigo.Text = "";
            this.txtCantidad.Text = "";
            this.txtPrecio.Text = "";
        }
        private void ConfigurarColumnasDataGridView()
        {


            this.tableArticulos.DataSource = gestionarArticuloServicio.ListarProductos();
            this.tableArticulos.AutoGenerateColumns = false;

        }
        private void AlternarColores(DataGridView datagrid)
        {

            datagrid.AlternatingRowsDefaultCellStyle.BackColor = Color.Gold;

        }
        private void FormGestionarArticulos_Load(object sender, EventArgs e)
        {
            CargarTipoMadera();
            CargarPresentacion();
            ConfigurarColumnasDataGridView();
            AlternarColores(tableArticulos);
        }
    }
}

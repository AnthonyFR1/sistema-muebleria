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
    public partial class FormGestionarCliente : Form
    {
        GestionarClienteServicio gestionarClienteServicio = new GestionarClienteServicio();
        GestionarTrabajadorServicio gestionarTrabajadorServicio = new GestionarTrabajadorServicio();
        
        public FormGestionarCliente()
        {
            InitializeComponent();
        }
        public void DesabilitarOpcionNuevo()
        {
            this.btnNuevo.Enabled = false;
            this.btnEliminar.Enabled = false;
        }
        public void HabilitarOpcionNuevo()
        {
            this.btnNuevo.Enabled = true;
            this.btnEliminar.Enabled = true;
        }

        public void CargarSexo()
        {
            cbSexo.DataSource = gestionarTrabajadorServicio.ListarSexos();
            cbSexo.ValueMember = "idsexo";
            cbSexo.DisplayMember = "nombre";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            tbClientes.SelectedIndex = 1;
            DesabilitarOpcionNuevo();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tbClientes.SelectedIndex = 0;
            HabilitarOpcionNuevo();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        
        public void Limpiar()
        {
            this.txtNombres.Text = string.Empty;
            this.txtApellidoPaterno.Text = string.Empty;
            this.txtApellidoMaterno.Text = string.Empty;
            this.txtDni.Text = string.Empty;
    
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            Persona persona = new Persona();
            Sexo sexo = new Sexo();

            persona.Nombres = txtNombres.Text.ToUpper();
            persona.ApellidoPaterno = txtApellidoPaterno.Text.ToUpper();
            persona.ApellidoMaterno = txtApellidoMaterno.Text.ToUpper();
            persona.Direccion = txtDireccion.Text.ToUpper();
            persona.Dni = txtDni.Text;
            persona.FechaNacimiento= dtFechaNacimiento.Value;
            sexo.IdSexo = Convert.ToInt32(cbSexo.SelectedValue);

            cliente.Persona = persona;
            cliente.Sexo = sexo;

            if (this.txtNombres.Text == string.Empty || this.txtApellidoPaterno.Text == string.Empty || this.txtApellidoMaterno.Text == string.Empty || this.txtDni.Text == string.Empty || this.cbSexo.Text == string.Empty)
            {
                MessageBox.Show("¡Complete los campos vacios!", "Muebleria - B.Paredes", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                bool valida = gestionarClienteServicio.ValidarMaximoCaracteresDni(persona);
                if (valida)
                {
                    MessageBox.Show("¡Excedio el máximo de carácteres válidos en el DNI!", "Muebleria - B.Paredes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    bool inserto = gestionarClienteServicio.InsertarCliente(cliente);
                    if (inserto)
                    {

                        MessageBox.Show("¡REGISTRO   EXITOSO!", "Muebleria - B.Paredes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        tbClientes.SelectedIndex = 0;
                        ConfigurarColumnasDataGridView();
                        HabilitarOpcionNuevo();

                    }
                    else
                    {
                        MessageBox.Show("¡ERROR   AL   REGISTRAR!", "Muebleria - VillaCorta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }


        }
        private void ConfigurarColumnasDataGridView()
        {


            this.tableClientes.DataSource = gestionarClienteServicio.ListarClientes();
            this.tableClientes.AutoGenerateColumns = false;

        }
        private void AlternarColores(DataGridView datagrid)
        {

            datagrid.AlternatingRowsDefaultCellStyle.BackColor = Color.Gold;

        }
        private void FormGestionarCliente_Load(object sender, EventArgs e)
        {
            CargarSexo();
            ConfigurarColumnasDataGridView();
            AlternarColores(tableClientes);
        }
    }
}

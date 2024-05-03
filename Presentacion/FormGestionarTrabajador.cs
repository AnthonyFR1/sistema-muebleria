using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Dominio.Contratos;
using Aplicacion;

namespace Presentacion
{
    public partial class FormGestionarTrabajador : Form
    {
        GestionarTrabajadorServicio _gestionarTrabajador = new GestionarTrabajadorServicio();

        public int IdTrabajador { get; set; }

        private static FormGestionarTrabajador _instancia;

        public static FormGestionarTrabajador GetInstancia()
        {
            if (_instancia == null)
                _instancia = new FormGestionarTrabajador();
            return _instancia;
        }
        public void setTrabajador(string idtrabajador)
        {
            this.txtidtrabajador.Text = idtrabajador;

        }
        public FormGestionarTrabajador()
        {
            InitializeComponent();
        }
        public void CargarRoles()
        {
            cboRol.DataSource = _gestionarTrabajador.ListarRoles();
            cboRol.ValueMember = "idrol";
            cboRol.DisplayMember = "nombre";
        }
        
        public void CargarSexo()
        {
            cbSexo.DataSource = _gestionarTrabajador.ListarSexos();
            cbSexo.ValueMember = "idsexo";
            cbSexo.DisplayMember = "nombre";
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Muebleria - VillaCorta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Limpiar()
        {
            this.txtNombres.Text = string.Empty;
            this.txtApellidoPaterno.Text = string.Empty;
            this.txtApellidoMaterno.Text = string.Empty;
            this.txtDni.Text = string.Empty;
            this.txtNombreUsuario.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
            this.cboRol.Text = string.Empty;
        }

        private void ConfigurarColumnasDataGridView()
        {


            this.tableTrabajadores.DataSource = _gestionarTrabajador.ListarTrabajadores();
            this.tableTrabajadores.AutoGenerateColumns = false;

        }
        private void AlternarColores(DataGridView datagrid)
        {

            datagrid.AlternatingRowsDefaultCellStyle.BackColor = Color.Gold;

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
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void FormGestionarTrabajador_Load(object sender, EventArgs e)
        {
            CargarRoles();
            CargarSexo();
            ConfigurarColumnasDataGridView();
            AlternarColores(tableTrabajadores);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Trabajador trabajador = new Trabajador();
                Persona persona = new Persona();
                Rol rol = new Rol();
                Sexo sexo = new Sexo();

                persona.Nombres = txtNombres.Text.ToUpper();
                persona.ApellidoPaterno = txtApellidoPaterno.Text.ToUpper();
                persona.ApellidoMaterno = txtApellidoMaterno.Text.ToUpper();
                persona.Dni = txtDni.Text.ToUpper();
                persona.FechaNacimiento = dtFechaNacimiento.Value;

                trabajador.NombreUsuario = txtNombreUsuario.Text;
                trabajador.PasswordUsuario = txtPassword.Text;


                rol.IdRol = Convert.ToInt32(cboRol.SelectedValue);
                sexo.IdSexo = Convert.ToInt32(cbSexo.SelectedValue);

                trabajador.Persona = persona;
                trabajador.Rol = rol;
                trabajador.Sexo = sexo;

                
                //bool valida = _gestionarTrabajador.ValidarMaximoCaracteresDni(persona);

                if (this.txtNombres.Text == string.Empty || this.txtApellidoPaterno.Text==string.Empty || this.txtApellidoMaterno.Text==string.Empty||this.txtDni.Text==string.Empty || this.txtNombreUsuario.Text==string.Empty || this.txtPassword.Text==string.Empty|| this.cboRol.Text==string.Empty||this.cbSexo.Text==string.Empty)
                { 
                    MessageBox.Show("¡Complete los campos vacios!", "Muebleria - JYE", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    bool valida = _gestionarTrabajador.ValidarMaximoCaracteresDni(persona);
                    if (valida)
                    {
                        MessageBox.Show("¡Excedio el máximo de carácteres válidos en el DNI!", "Muebleria - JYE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        bool inserto = _gestionarTrabajador.InsertarTrabajador(trabajador);
                        if (inserto)
                        {

                            MessageBox.Show("¡REGISTRO   EXITOSO!", "Muebleria - JYE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                            ConfigurarColumnasDataGridView();
                            tbTrabajadores.SelectedIndex = 0;
                            HabilitarOpcionNuevo();
                        }
                        else
                        {
                            MessageBox.Show("¡ERROR   AL   REGISTRAR!", "Muebleria - VillaCorta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    
                }   
            }
            catch (Exception ex)
            {

                throw ex;
            }
           

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            tbTrabajadores.SelectedIndex = 1;
            DesabilitarOpcionNuevo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tbTrabajadores.SelectedIndex = 0;
            HabilitarOpcionNuevo();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FormGestionarTrabajador_Show(object sender, EventArgs e)
        {
   
        }

        private void tableTrabajadores_DoubleClick(object sender, EventArgs e)
        {
            this.txtidtrabajador.Text = Convert.ToString(this.tableTrabajadores.CurrentRow.Cells["id"].Value);
            this.tbTrabajadores.SelectedIndex = 1;
        }
    }
}

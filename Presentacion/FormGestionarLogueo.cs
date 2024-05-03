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
using Dominio.Contratos;

namespace Presentacion
{
    public partial class FormGestionarLogueo : Form
    {
        GestionarLogueoServicio _gestionarLogueo = new GestionarLogueoServicio();
        public FormGestionarLogueo()
        {
            InitializeComponent();
        }
        //Métodos
        public void Barra()
        {
            int contador = 0;
            int rowMax = 500;
            int coltMax = 500;

            decimal pdDone;

            for (int r = 0; r < rowMax; r++)
            {
                for (int c = 0; c < coltMax; c++)
                {
                    contador++;

                }
                pdDone = (decimal)contador / (rowMax * coltMax);
                bc.Text = ((int)(pdDone * 100)).ToString() + "%";
                bc.Refresh();
                lblCarga.Width = Convert.ToInt32(pdDone * (bc.Width - 0));


            }
        }
        public void Limpiar() {

            // LIMPIA LAS CAJAS DE TEXTO
            this.txtUsuario.Text = "";
            this.txtPassword.Text = "";
            this.lblCarga.Refresh();

            // LIMPIA EL PROGRESS BAR
            int counter = 0;
            int rowMax = 500;
            int coltMax = 500;

            decimal pdDone;

            for (int r = 0; r < rowMax; r++)
            {
                for (int c = 0; c < coltMax; c++)
                {
                    counter--;

                }
                pdDone = (decimal)counter / (rowMax * coltMax);
                bc.Text = ((int)(pdDone * 0)).ToString() + "%";
              
                lblCarga.Width = Convert.ToInt32(pdDone * (bc.Width - 0));


            }
            
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Muebleria - VillaCorta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void VerificarAcceso()
        {
            try
            {
                string usuarioAcceso = txtUsuario.Text;
                string passwordAcceso = txtPassword.Text;
                string mensaje;
                Barra();
                Trabajador trabajador = _gestionarLogueo.VerificarAcceso(usuarioAcceso, passwordAcceso, out mensaje);
                if (mensaje.Equals(""))
                {
                    MessageBox.Show("¡Bievenido " + trabajador.Rol.Nombre + " "
                                                  + trabajador.Persona.ApellidoPaterno + " !",
                                    "Sistema Muebleria", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FormMenuPrincipal formMenuPrincipal = new FormMenuPrincipal();
                    formMenuPrincipal.Idtrabajador = Convert.ToInt32(trabajador.IdTrabajador.ToString());
                    
                    

                    formMenuPrincipal.Show();
                 
                    Hide();
                }
                else
                {
                    Limpiar();
                    MensajeError(mensaje);
                }
            }
            catch (Exception ex)
            {
                MensajeError(ex.Message);
            }
       
        }

        private void FormGestionarLogueo_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            VerificarAcceso();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

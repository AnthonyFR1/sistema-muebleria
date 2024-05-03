using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Contratos;
namespace Dominio
{
    public class Trabajador:ITrabajadorContrato
    {
        public int IdTrabajador { get; set; }
        public string NombreUsuario { get; set; }
        public string PasswordUsuario { get; set; }
        
        public Persona Persona { get; set; }
        public Rol Rol { get; set; }
        public Sexo Sexo { get; set; }
        public bool Activo { get; set; }

        public Trabajador() { }

     

        #region Reglas de Negocio
        public Trabajador VerificarAcceso(Trabajador usuario, out string mensaje)
        {
            try
            {
                mensaje = "";
                if (usuario != null)
                {
                    if (!usuario.Activo)
                        mensaje = "¡El usuario está dado de baja!";
                
                }
                else
                {
                    mensaje = "¡Usuario o Password no válido!";
                }
                return usuario;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool ValidarMaximoCaracteresDni(Persona persona)
        {
            bool excedioValor = false;
            try
            {
                if (persona != null)
                {
                    if (persona.Dni.Length > 8)
                        excedioValor = true;
                }
                else
                {
                    if (persona.Dni.Length <=8)
                        excedioValor= false;
                }
                return excedioValor;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
    
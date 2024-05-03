using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Contratos;
namespace Dominio
{
    public class Cliente:IClienteContrato
    {
        public int IdCliente { get; set; }
        public Persona Persona { get; set; }
        public Sexo Sexo { get; set; }
        public Boolean Activo { get; set; }

        #region Reglas de Negocio
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
                    if (persona.Dni.Length <= 8)
                        excedioValor = false;
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

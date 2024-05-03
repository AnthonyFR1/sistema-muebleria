using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Contratos;

namespace Dominio
{
    public class Venta:IVentaContrato
    {
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }
        public Trabajador Trabajador { get; set; }
        public Cliente Cliente { get; set; }
        public List<LineaDeVenta> ListaLineaDeVenta { get; set; }

        public Venta()
        {
            ListaLineaDeVenta = new List<LineaDeVenta>();
        }
        #region Reglas de Negocio

        public double CalcularIgv()
        {
            throw new NotImplementedException();
        }

        public double CalcularSubTotal()
        {
            throw new NotImplementedException();
        }

        public double CalcularTotal()
        {
            throw new NotImplementedException();
        }

        public double DescuentoTotal()
        {
            throw new NotImplementedException();
        }

    

        #endregion
    }
}

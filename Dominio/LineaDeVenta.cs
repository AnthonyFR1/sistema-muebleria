using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Contratos;

namespace Dominio
{
    public class LineaDeVenta:ILineaDeVentaContrato
    {
        public int IdLineaDeVenta { get; set; }
        public int Cantidad { get; set; }
        public Venta Venta { get; set; }
        public double Precio { get; set; }
        public List<DetalleProducto> ListaDetalleProducto { get; set; }

        #region Reglas de negocio

        public double CalcularTotal()
        {
            throw new NotImplementedException();

        }

        public double DescuentoTotalLinea()
        {
            throw new NotImplementedException();
        }

       

        #endregion
    }
}

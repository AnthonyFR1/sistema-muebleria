using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Contratos;

namespace Dominio
{
    public class DetalleProducto:IDetalleProductoContrato
    {
        public int IdDetalleProducto{ get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public Producto Producto { get; set; }
        public int StockMinimo { get; set; }
        public int StockActual { get; set; }
       

        public double CalcularTotalPorIngresoDeProducto(int cantidad)
        {
            double total = 0;
            if (cantidad > 0)
                total = Precio * cantidad;
            return total;
        }

    }
}

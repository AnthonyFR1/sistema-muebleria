using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Contratos
{
    public interface IDetalleProductoContrato
    {
        double CalcularTotalPorIngresoDeProducto(int cantidad);
    }
}

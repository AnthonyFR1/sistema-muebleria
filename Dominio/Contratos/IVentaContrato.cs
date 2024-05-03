using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Contratos
{
    public interface IVentaContrato
    {
        double CalcularIgv();
        double CalcularSubTotal();
        double CalcularTotal();
        double DescuentoTotal();
        
    }
}

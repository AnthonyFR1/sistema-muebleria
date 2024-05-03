using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Contratos
{
    public interface ITrabajadorContrato
    {
        Trabajador VerificarAcceso(Trabajador usuario, out string mensaje);
        bool ValidarMaximoCaracteresDni(Persona persona);
    }
}

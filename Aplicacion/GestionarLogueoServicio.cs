using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using Dominio;
using Dominio.Contratos;

namespace Aplicacion
{
    public class GestionarLogueoServicio
    {
        #region Constructor
        private readonly GestorDaoSql _gestorDaoSql;
        private readonly TrabajadorDao _usuarioDao;
        private readonly ITrabajadorContrato _trabajadorContrato;
        public GestionarLogueoServicio()
        {
            _gestorDaoSql = new GestorDaoSql();
            _usuarioDao = new TrabajadorDao(_gestorDaoSql);
            _trabajadorContrato = new Trabajador();
        }
        #endregion

        public Trabajador VerificarAcceso(string usuario,string password,out string mensaje)
        {
            try
            {
                _gestorDaoSql.AbrirConexion();
                Trabajador trabajadorVerifica = _usuarioDao.VerificarAcceso(usuario, password);
                _gestorDaoSql.CerrarConexion();
                Trabajador trabajadorContrato = _trabajadorContrato.VerificarAcceso(trabajadorVerifica, out mensaje);
                return trabajadorContrato;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
    }
}

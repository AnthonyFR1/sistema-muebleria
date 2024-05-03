using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using Dominio;
using Dominio.Contratos;
using System.Data;

namespace Aplicacion
{
    public class GestionarTrabajadorServicio
    {
        #region Constructor
        private readonly GestorDaoSql _gestorDaoSql;
        private readonly TrabajadorDao _trabajadorDao;
        private readonly RolDao _rolDao;
        private readonly SexoDao _sexoDao;
        private readonly ITrabajadorContrato _trabajadorContrato;

        public GestionarTrabajadorServicio()
        {
            _gestorDaoSql = new GestorDaoSql();
            _trabajadorDao = new TrabajadorDao(_gestorDaoSql);
            _trabajadorContrato = new Trabajador();
            _rolDao = new RolDao(_gestorDaoSql);
            _sexoDao = new SexoDao(_gestorDaoSql);
        }
        #endregion
        public bool InsertarTrabajador(Trabajador trabajador)
        {
            try
            {
                _gestorDaoSql.IniciarTransaccion();
                bool inserto = _trabajadorDao.InsertarTrabajador(trabajador);
                if (inserto)
                    _gestorDaoSql.TerminarTransaccion();
                else
                    _gestorDaoSql.CancelarTransaccion();

                return inserto;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Rol> ListarRoles()
        {
            try
            {
                _gestorDaoSql.AbrirConexion();
                List<Rol> lista = _rolDao.ListarRoles();
                _gestorDaoSql.CerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Sexo> ListarSexos()
        {
            try
            {
                _gestorDaoSql.AbrirConexion();
                List<Sexo> listaSexo = _sexoDao.ListarSexos();
                _gestorDaoSql.CerrarConexion();
                return listaSexo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool ValidarMaximoCaracteresDni(Persona persona)
        {
            try
            {
                _gestorDaoSql.IniciarTransaccion();
                bool valida = _trabajadorContrato.ValidarMaximoCaracteresDni(persona);
                if (valida)
                    _gestorDaoSql.TerminarTransaccion();
                else
                    _gestorDaoSql.CancelarTransaccion();
                return valida;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable ListarTrabajadores()
        {
            try
            {
                _gestorDaoSql.AbrirConexion();
                DataTable listaTrabajadores = _trabajadorDao.ListarTrabajadores();
                _gestorDaoSql.CerrarConexion();
                return listaTrabajadores;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

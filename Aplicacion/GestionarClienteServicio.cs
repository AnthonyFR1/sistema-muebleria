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
    public class GestionarClienteServicio
    {
        #region Constructor
        private readonly GestorDaoSql _gestorDaoSql;
        private readonly ClienteDao _clienteDao;
        private readonly RolDao _rolDao;
        private readonly SexoDao _sexoDao;
        private readonly IClienteContrato _clienteContrato;

        public GestionarClienteServicio()
        {
            _gestorDaoSql = new GestorDaoSql();
            _clienteDao = new ClienteDao(_gestorDaoSql);
            _rolDao = new RolDao(_gestorDaoSql);
            _sexoDao = new SexoDao(_gestorDaoSql);
            _clienteContrato = new Cliente();
        }
        #endregion

        public bool InsertarCliente(Cliente Cliente)
        {
            try
            {
                _gestorDaoSql.IniciarTransaccion();
                bool inserto = _clienteDao.InsertarCliente(Cliente);
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

        public bool ValidarMaximoCaracteresDni(Persona persona)
        {
            try
            {
                _gestorDaoSql.IniciarTransaccion();
                bool valida = _clienteContrato.ValidarMaximoCaracteresDni(persona);
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

        public DataTable ListarClientes()
        {
            try
            {
                _gestorDaoSql.AbrirConexion();
                DataTable listaClientes = _clienteDao.ListarClientes();
                _gestorDaoSql.CerrarConexion();
                return listaClientes;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

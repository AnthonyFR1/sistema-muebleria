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
    public class GestionarProductoServicio
    {
        #region Constructor
        private readonly GestorDaoSql _gestorDaoSql;
        private readonly ClienteDao _clienteDao;
        private readonly SexoDao _sexoDao;
        private readonly ProductoDao _productoDao;
        private readonly MaderaDao _maderaDao;
        private readonly PresentacionDao _presentacionDao;
        private readonly DetalleProductoDao _detalleArticuloDao;

        public GestionarProductoServicio()
        {
            _gestorDaoSql = new GestorDaoSql();
            _clienteDao = new ClienteDao(_gestorDaoSql);
            _sexoDao = new SexoDao(_gestorDaoSql);
            _productoDao = new ProductoDao(_gestorDaoSql);
            _presentacionDao = new PresentacionDao(_gestorDaoSql);
            _maderaDao = new MaderaDao(_gestorDaoSql);
            _detalleArticuloDao = new DetalleProductoDao(_gestorDaoSql);
                
        }
        #endregion


        public int InsertarProducto(Producto producto)
        {
            try
            {
                _gestorDaoSql.IniciarTransaccion();
                int inserto = _productoDao.InsertarArticulo(producto);
                if (inserto>0)
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

        public int InsertarDetalleProducto(List<DetalleProducto> detalleArticulo,int idproducto)
        {
            try
            {
                foreach (DetalleProducto detalle in detalleArticulo)
                {
                    _gestorDaoSql.IniciarTransaccion();
                    int inserto = _detalleArticuloDao.InsertarDetalleProducto(detalle, idproducto);
                    if (inserto <= 0)
                        _gestorDaoSql.CancelarTransaccion();
                    return 1;
                }
                return 1;
                     
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool RegistrarProducto(Producto articulo)
        {
            try
            {
                _gestorDaoSql.IniciarTransaccion();
                int idarticulo = InsertarProducto(articulo);
                if (idarticulo <= 0)
                {
                    _gestorDaoSql.CancelarTransaccion();
                    return false;
                }
                int inserto = InsertarDetalleProducto(articulo.ListaDetalleProducto, idarticulo);
                if (inserto <= 0)
                {
                    _gestorDaoSql.CancelarTransaccion();
                    return false;
                }
                _gestorDaoSql.TerminarTransaccion();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Madera> ListarMadera()
        {
            try
            {
                _gestorDaoSql.AbrirConexion();
                List<Madera> listaMadera = _maderaDao.ListarMaderas();
                _gestorDaoSql.CerrarConexion();
                return listaMadera;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<PresentacionProducto> ListarPresentacion()
        {
            try
            {
                _gestorDaoSql.AbrirConexion();
                List<PresentacionProducto> listaPresentacion = _presentacionDao.ListarPresentacion();
                _gestorDaoSql.CerrarConexion();
                return listaPresentacion;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //La función de tipo datable permite de manera rapida listar datos a un datagridview
        public DataTable ListarProductos()
        {
            try
            {
                _gestorDaoSql.AbrirConexion();
                DataTable listaArticulos = _productoDao.ListarProductos();
                _gestorDaoSql.CerrarConexion();
                return listaArticulos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}

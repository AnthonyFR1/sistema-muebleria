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
    public class RealizarVentaServicio
    {
        #region Constructor
        private readonly GestorDaoSql _gestorDaoSql;
        private readonly ClienteDao _clienteDao;
        private readonly SexoDao _sexoDao;
        private readonly ProductoDao _productoDao;
        private readonly MaderaDao _maderaDao;
        private readonly PresentacionDao _presentacionDao;
        private readonly DetalleProductoDao _detalleArticuloDao;
        private readonly LineaDeVentaDao _lineaDeVentaDao;
        private readonly VentaDao _ventaDao;
        public RealizarVentaServicio()
        {
            _gestorDaoSql = new GestorDaoSql();
            _clienteDao = new ClienteDao(_gestorDaoSql);
            _sexoDao = new SexoDao(_gestorDaoSql);
            _productoDao = new ProductoDao(_gestorDaoSql);
            _presentacionDao = new PresentacionDao(_gestorDaoSql);
            _maderaDao = new MaderaDao(_gestorDaoSql);
            _detalleArticuloDao = new DetalleProductoDao(_gestorDaoSql);
            _lineaDeVentaDao = new LineaDeVentaDao(_gestorDaoSql);
            _ventaDao = new VentaDao(_gestorDaoSql);

        }
        #endregion

        public int InsertarVenta(Venta venta)
        {
            try
            {
                int inserto = _ventaDao.InsertarVenta(venta);
                if (inserto < 0)
                    _gestorDaoSql.CancelarTransaccion();
                return inserto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

     
        public int InsertarLineaDeVenta(List<LineaDeVenta> lineaDeVenta, int idVenta)
        {
            try
            {
                foreach (LineaDeVenta lineaDetalleDeVenta in lineaDeVenta)
                {
                    int inserto = _lineaDeVentaDao.InsertarLineaDeVenta(lineaDetalleDeVenta,idVenta);
                    if (inserto <= 0)
                        _gestorDaoSql.CancelarTransaccion();
                }
                return 1;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool RegistrarVenta(Venta venta)
        {
            try
            {
                _gestorDaoSql.IniciarTransaccion();
                int idVenta = InsertarVenta(venta);
                if (idVenta <= 0)
                {
                    _gestorDaoSql.CancelarTransaccion();
                    return false;
                }                
                int inserto = InsertarLineaDeVenta(venta.ListaLineaDeVenta, idVenta);
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
    }
}

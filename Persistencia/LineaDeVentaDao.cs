using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dominio;

namespace Persistencia
{
    public class LineaDeVentaDao
    {
        #region Constructor
        private readonly GestorDaoSql _gestorDaoSql;

        public LineaDeVentaDao(GestorDaoSql gestorDaoSql)
        {
            _gestorDaoSql = gestorDaoSql;
        }
        #endregion

        public int InsertarLineaDeVenta(LineaDeVenta lineaDeVenta, int idVenta)
        {
            SqlCommand comando = new SqlCommand("spInsertarLineaDeVenta");
            try
            {
                comando = _gestorDaoSql.ObtenerComandoSp(comando);
                comando.Parameters.AddWithValue("@parcantidad", lineaDeVenta.Cantidad);
                comando.Parameters.AddWithValue("@paridventa", idVenta);
                comando.Parameters.AddWithValue("@parprecio", lineaDeVenta.Precio);
                //comando.Parameters.AddWithValue("@pariddetalleproducto", idDetalleProducto);
                comando.Parameters.Add(new SqlParameter("@idlineadeventa", DbType.Int32) { Direction = ParameterDirection.ReturnValue });
                comando.ExecuteNonQuery();
                int idLineaDeVenta = Convert.ToInt32(comando.Parameters["@idlineadeventa"].Value);
                return idLineaDeVenta;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

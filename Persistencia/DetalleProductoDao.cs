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
    public class DetalleProductoDao
    {
        #region Constructor
        private readonly GestorDaoSql _gestorDaoSql;

        public DetalleProductoDao(GestorDaoSql gestorDaoSql)
        {
            _gestorDaoSql = gestorDaoSql;
        }
        #endregion

        public int InsertarDetalleProducto(DetalleProducto detalleProducto, int idproducto)
        {
            SqlCommand comando = new SqlCommand("spInsertarDetalleProducto");
            try
            {
                comando = _gestorDaoSql.ObtenerComandoSp(comando);

                comando.Parameters.AddWithValue("@parstockactual", detalleProducto.Cantidad);
                comando.Parameters.AddWithValue("@parprecio", detalleProducto.Precio);
                comando.Parameters.AddWithValue("@paridproducto", idproducto);
                comando.Parameters.Add(new SqlParameter("@iddetalleproducto", DbType.Int32) { Direction = ParameterDirection.ReturnValue });
                comando.ExecuteNonQuery();
                int idDetalleProducto = Convert.ToInt32(comando.Parameters["@iddetalleproducto"].Value);
                return idDetalleProducto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

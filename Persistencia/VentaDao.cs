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
    public class VentaDao
    {
        #region Constructor
        private readonly GestorDaoSql _gestorDaoSql;

        public VentaDao(GestorDaoSql gestorDaoSql)
        {
            _gestorDaoSql = gestorDaoSql;
        }
        #endregion

        public int InsertarVenta(Venta venta)
        {
            SqlCommand comando = new SqlCommand("spInsertarVenta");
            try
            {
                comando = _gestorDaoSql.ObtenerComandoSp(comando);
                comando.Parameters.AddWithValue("@parfecha", venta.Fecha);
                comando.Parameters.AddWithValue("@paridtrabajador", venta.Trabajador.IdTrabajador);
                comando.Parameters.AddWithValue("@paridcliente", venta.Cliente.IdCliente);
                comando.Parameters.Add(new SqlParameter("@idventa", DbType.Int32) { Direction = ParameterDirection.ReturnValue });
                comando.ExecuteNonQuery();
                int idventa = Convert.ToInt32(comando.Parameters["@idventa"].Value);
                return idventa;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

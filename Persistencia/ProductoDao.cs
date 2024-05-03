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
    public class ProductoDao
    {
        #region Constructor
        private readonly GestorDaoSql _gestorDaoSql;

        public ProductoDao(GestorDaoSql gestorDaoSql)
        {
            _gestorDaoSql = gestorDaoSql;
        }
        #endregion

        public int InsertarArticulo(Producto articulo)
        {
            SqlCommand comando = new SqlCommand("spInsertarProducto");
            try
            {
                comando = _gestorDaoSql.ObtenerComandoSp(comando);

                comando.Parameters.AddWithValue("@parnombre", articulo.Nombre);
                comando.Parameters.AddWithValue("@pardescripcion", articulo.Descripcion);
                comando.Parameters.AddWithValue("@parserie", articulo.Serie);
                comando.Parameters.AddWithValue("@paridmadera", articulo.Madera.IdMadera);
                comando.Parameters.AddWithValue("@paridpresentacion", articulo.PresentacionProducto.IdPresentacion);
                comando.Parameters.AddWithValue("@parcodigobarras",articulo.CodigoBarras);

                comando.Parameters.Add(new SqlParameter("@idproducto", DbType.Int32) { Direction = ParameterDirection.ReturnValue });
                comando.ExecuteNonQuery();
                int idproducto = Convert.ToInt32(comando.Parameters["@idproducto"].Value);
                return idproducto;

                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable ListarProductos()
        {
            string comando = "spListarProductos";
            try
            {
                DataTable adaptador = _gestorDaoSql.EjecutarComandoDataTable(comando);
                return adaptador;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}

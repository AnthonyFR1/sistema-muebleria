using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
namespace Persistencia
{
    public class PresentacionDao
    {
        #region Constructor
        private readonly GestorDaoSql _gestorDaoSql;
        public PresentacionDao(GestorDaoSql gestorDaoSql)
        {
            _gestorDaoSql = gestorDaoSql;
        }
        #endregion

        public List<PresentacionProducto> ListarPresentacion()
        {
            SqlCommand comando = new SqlCommand("spListarPresentacion");
            List<SqlParameter> parametros = new List<SqlParameter>();
            List<PresentacionProducto> listaPresentacion = new List<PresentacionProducto>();
            PresentacionProducto presentacionArticulo = null;
            try
            {
                SqlDataReader resultado = _gestorDaoSql.EjecutarComandoSp(comando, parametros);
                while (resultado.Read())
                {
                    presentacionArticulo = new PresentacionProducto()
                    {
                        IdPresentacion = Convert.ToInt32(resultado["idpresentacion"]),
                        Nombre = resultado["nombre"].ToString()
                    };
                    listaPresentacion.Add(presentacionArticulo);
                }
                resultado.Close();
                return listaPresentacion;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

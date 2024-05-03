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
    public class MaderaDao
    {
        #region Constructor
        private readonly GestorDaoSql _gestorDaoSql;
        public MaderaDao(GestorDaoSql gestorDaoSql)
        {
            _gestorDaoSql = gestorDaoSql;
        }
        #endregion

        public List<Madera> ListarMaderas()
        {
            SqlCommand comando = new SqlCommand("spListarMaderas");
            List<SqlParameter> parametros = new List<SqlParameter>();
            List<Madera> listaMadera = new List<Madera>();
            Madera maderaEntidad = null;
            try
            {
                SqlDataReader resultado = _gestorDaoSql.EjecutarComandoSp(comando, parametros);
                while (resultado.Read())
                {
                    maderaEntidad = new Madera()
                    {
                        IdMadera = Convert.ToInt32(resultado["idmadera"]),
                        Nombre = resultado["nombre"].ToString()
                    };
                    listaMadera.Add(maderaEntidad);
                }
                resultado.Close();
                return listaMadera;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

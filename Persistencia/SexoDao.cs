using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    public class SexoDao
    {
        #region Constructor
        private readonly GestorDaoSql _gestorDaoSql;
        public SexoDao(GestorDaoSql gestorDaoSql)
        {
            _gestorDaoSql = gestorDaoSql;
        }
        #endregion

        public List<Sexo> ListarSexos()
        {
            SqlCommand comando = new SqlCommand("spListarSexos");
            List<Sexo> listaSexo = new List<Sexo>();
            List<SqlParameter> parametros = new List<SqlParameter>();
            Sexo sexoEntidad = null;
            try
            {
                SqlDataReader resultado = _gestorDaoSql.EjecutarComandoSp(comando,parametros);
                while (resultado.Read())
                {
                    sexoEntidad = new Sexo()
                    {
                        IdSexo = Convert.ToInt32(resultado["idsexo"]),
                        Nombre = resultado["nombre"].ToString()
                    };
                    listaSexo.Add(sexoEntidad);
                }
                resultado.Close();
                return listaSexo;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

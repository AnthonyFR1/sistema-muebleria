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
    public class RolDao
    {
        #region Constructor
        private readonly GestorDaoSql _gestorDaoSql;
        public RolDao(GestorDaoSql gestorDaoSql)
        {
            _gestorDaoSql = gestorDaoSql;
        }
        #endregion

        public List<Rol> ListarRoles()
        {
            SqlCommand comando = new SqlCommand("spListarRol");
            List<SqlParameter> parametros = new List<SqlParameter>();
            List<Rol> listaRol = new List<Rol>();
            Rol rolEntidad = null;
            try
            {
                SqlDataReader resultado = _gestorDaoSql.EjecutarComandoSp(comando, parametros);
                while (resultado.Read())
                {
                    rolEntidad = new Rol()
                    {
                        IdRol=Convert.ToInt32(resultado["idrol"]),
                        Nombre = resultado["nombre"].ToString()
                    };
                    listaRol.Add(rolEntidad);
                }
                resultado.Close();
                return listaRol;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

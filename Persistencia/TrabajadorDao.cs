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
    public class TrabajadorDao
    {
        #region Constructor
        private readonly GestorDaoSql _gestorDaoSql;

        public TrabajadorDao(GestorDaoSql gestorDaoSql)
        {
            _gestorDaoSql = gestorDaoSql;
        }
        #endregion

        public Trabajador VerificarAcceso(string usuario,string password)
        {
            SqlCommand comando = new SqlCommand("spVerificarAcceso");

            Trabajador trabajadorEntidad = null;
            Persona personaEntidad = null;
            Rol rolEntidad = null;

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter("@parusuario",usuario),
                new SqlParameter("@parpassword",password)
            };

            try
            {
                SqlDataReader resultado = _gestorDaoSql.EjecutarComandoSp(comando, parametros);
                if (resultado.Read())
                {
                    trabajadorEntidad = new Trabajador()
                    {
                        IdTrabajador = Convert.ToInt32(resultado["idtrabajador"]),
                        NombreUsuario = resultado["nombreusuario"].ToString(),
                        PasswordUsuario = resultado["passwordusuario"].ToString(),
                        Activo=Convert.ToBoolean(resultado["activo"])
                        
                    };
                    personaEntidad = new Persona()
                    {
                        Nombres = resultado["nombres"].ToString(),
                        ApellidoPaterno = resultado["apellidopaterno"].ToString(),
                        ApellidoMaterno = resultado["apellidomaterno"].ToString()
                    };
                    rolEntidad = new Rol()
                    {
                        Nombre = resultado["nombre"].ToString()
                    };
                    trabajadorEntidad.Persona = personaEntidad;
                    trabajadorEntidad.Rol = rolEntidad;
                }
                resultado.Close();
                return trabajadorEntidad;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public bool InsertarTrabajador(Trabajador trabajador)
        {
            SqlCommand comando = new SqlCommand("spInsertarTrabajador");
            bool inserto = false;
            try
            {
                comando = _gestorDaoSql.ObtenerComandoSp(comando);

                comando.Parameters.AddWithValue("@parnombres",trabajador.Persona.Nombres);
                comando.Parameters.AddWithValue("@parapellidopaterno",trabajador.Persona.ApellidoPaterno);
                comando.Parameters.AddWithValue("@parapellidomaterno",trabajador.Persona.ApellidoMaterno);
                comando.Parameters.AddWithValue("@pardni", trabajador.Persona.Dni);
                comando.Parameters.AddWithValue("@parnombreusuario",trabajador.NombreUsuario);
                comando.Parameters.AddWithValue("@parpasswordusuario",trabajador.PasswordUsuario);
                comando.Parameters.AddWithValue("@paridrol",trabajador.Rol.IdRol);
                comando.Parameters.AddWithValue("@parfechanacimiento",trabajador.Persona.FechaNacimiento);
                comando.Parameters.AddWithValue("@paridsexo", trabajador.Sexo.IdSexo);

                int i = comando.ExecuteNonQuery();
                if (i > 0) { inserto = true; }
                return inserto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable ListarTrabajadores()
        {
            string comando = "spListarTrabajadores";
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

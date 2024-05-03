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
    public class ClienteDao
    {
        #region Constructor
        private readonly GestorDaoSql _gestorDaoSql;

        public ClienteDao(GestorDaoSql gestorDaoSql)
        {
            _gestorDaoSql = gestorDaoSql;
        }
        #endregion

        public bool InsertarCliente(Cliente Cliente)
        {
            SqlCommand comando = new SqlCommand("spInsertarCliente");
            bool inserto = false;
            try
            {
                comando = _gestorDaoSql.ObtenerComandoSp(comando);

                comando.Parameters.AddWithValue("@parnombres", Cliente.Persona.Nombres);
                comando.Parameters.AddWithValue("@parapellidopaterno", Cliente.Persona.ApellidoPaterno);
                comando.Parameters.AddWithValue("@parapellidomaterno", Cliente.Persona.ApellidoMaterno);
                comando.Parameters.AddWithValue("@pardni", Cliente.Persona.Dni);
                comando.Parameters.AddWithValue("@parfechanacimiento", Cliente.Persona.FechaNacimiento);
                comando.Parameters.AddWithValue("@paridsexo", Cliente.Sexo.IdSexo);
                comando.Parameters.AddWithValue("@pardireccion",Cliente.Persona.Direccion);

                int i = comando.ExecuteNonQuery();
                if (i > 0) { inserto = true; }
                return inserto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable ListarClientes()
        {
            string comando = "spListarClientes";
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

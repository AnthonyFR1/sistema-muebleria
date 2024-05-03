using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    public class GestorDaoSql
    {
        private SqlConnection _conexion;
        private SqlTransaction _transaccion;

        public void AbrirConexion()
        {
            try
            {
                _conexion = new SqlConnection
                {
                    ConnectionString = "Data source=.; Initial Catalog=bdmuebleria_moanso; Integrated Security=true"
                };
                _conexion.Open();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void CerrarConexion()
        {
            try
            {
                _conexion.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void IniciarTransaccion()
        {
            try
            {
                AbrirConexion();
                _transaccion = _conexion.BeginTransaction();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void TerminarTransaccion()
        {
            try
            {
                _transaccion.Commit();
                _conexion.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void CancelarTransaccion()
        {
            try
            {
                _transaccion.Rollback();
                _conexion.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public SqlDataReader EjecutarConsulta(string sentenciaSql)
        {
            try
            {
                SqlCommand comando = _conexion.CreateCommand();
                if (_transaccion != null)
                    comando.Transaction = _transaccion;
                comando.CommandText = sentenciaSql;
                comando.CommandType = CommandType.Text;
                SqlDataReader resultado = comando.ExecuteReader();
                return resultado;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public SqlCommand ObtenerComandoSql(string sentenciaSql)
        {
            try
            {
                SqlCommand comando = _conexion.CreateCommand();
                if (_transaccion != null)
                    comando.Transaction = _transaccion;
                comando.CommandText = sentenciaSql;
                comando.CommandType = CommandType.Text;
                return comando;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public SqlCommand ObtenerComandoSp(SqlCommand command)
        {
            try
            {
                SqlCommand comando = _conexion.CreateCommand();
                if (_transaccion != null)
                    comando.Transaction = _transaccion;
                comando.CommandText = command.CommandText;
                comando.CommandType = CommandType.StoredProcedure;
                return comando;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public SqlDataReader EjecutarComandoSp(SqlCommand command, List<SqlParameter> parametros)
        {
            try
            {
                SqlCommand comando = _conexion.CreateCommand();
                if (_transaccion != null)
                    comando.Transaction = _transaccion;
                comando.CommandText = command.CommandText;
                comando.Parameters.AddRange(parametros.ToArray());
                comando.CommandType = CommandType.StoredProcedure;
                var resultado = comando.ExecuteReader();
                return resultado;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable EjecutarComandoDataTableConParametros(List<SqlParameter> parametros, string comando)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter();
            DataTable listaTabla = new DataTable();
            AbrirConexion();
            adaptador.SelectCommand = new SqlCommand(comando, _conexion);
            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter Parametro in parametros)
            {
                adaptador.SelectCommand.Parameters.Add(Parametro);
            }
            adaptador.Fill(listaTabla);
            adaptador.Dispose();
            CerrarConexion();
            return listaTabla;
        }

        public DataTable EjecutarComandoDataTable(string comando)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter();
            DataTable listaTabla = new DataTable();
            AbrirConexion();
            adaptador.SelectCommand = new SqlCommand(comando, _conexion);
            adaptador.SelectCommand.CommandType = CommandType.Text;
            adaptador.Fill(listaTabla);
            adaptador.Dispose();
            CerrarConexion();
            return listaTabla;
        }
    }
}

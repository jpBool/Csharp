using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using System.Data.SqlClient;

namespace ProjetoFinal2
{
    class ConexaoBanco
    {
        static string stringConexao = "Server = banco72a.postgresql.dbaas.com.br; " +
                                        "Database = banco72a; Port=5432;" +
                                        "User ID = banco72a; password = b@nco@unesp356;";
        /*static string stringConexao = "Server = 200.145.153.175; " +
                                        "Database = a08gatosant; Port=5432;" +
                                        "User ID = a08gatosant; password = cti;";*/


        static NpgsqlConnection cn;
        public static void Conectar()
        {
            if (cn == null)
                cn = new NpgsqlConnection();
            try
            {
                if (cn.State != ConnectionState.Open)
                {
                    cn.ConnectionString = stringConexao;
                    cn.Open();
                }
            }
            catch (NpgsqlException ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
        public static void Desconectar()
        {
            cn.Close();
            cn.Dispose();
            cn = null;
        }

        public static void executar(string sql)
        {
            try
            {
                Conectar();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        public static void executar(string sql, List<object> parametros)
        {
            try
            {
                Conectar();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = cn;
                int i = 1;
                foreach (object parametro in parametros)
                    cmd.Parameters.AddWithValue(i++.ToString(), parametro);
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        public static int executar(string sql, List<object> parametros, string campoRetorno)
        {
            try
            {
                Conectar();
                NpgsqlCommand cmd = new NpgsqlCommand();
                int modificado = 0;
                cmd.CommandText = sql + " RETURNING " + campoRetorno;
                cmd.Connection = cn;
                int i = 1;
                foreach (object parametro in parametros)
                    cmd.Parameters.AddWithValue(i++.ToString(), parametro);
                modificado = Convert.ToInt32(cmd.ExecuteScalar());
                return modificado;
            }
            catch (NpgsqlException ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        public static NpgsqlDataReader selecionar(string sql)
        {
            try
            {
                Conectar();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, cn);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                throw new ApplicationException(ex.Message);
            }
        }

        public static NpgsqlDataReader selecionar(string sql, List<object> parametros)
        {
            try
            {
                Conectar();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = cn;
                int i = 1;
                foreach (object parametro in parametros)
                    cmd.Parameters.AddWithValue(i++.ToString(), parametro);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (NpgsqlException ex)
            {
                Desconectar();
                throw new ApplicationException(ex.Message);
            }
        }

        public static DataTable selecionarDataTable(string sql)
        {
            try
            {
                Conectar();

                DataTable dt = new DataTable();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, cn);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (NpgsqlException ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public static DataSet selecionarDataSet(string sql)
        {
            try
            {
                Conectar();

                DataSet ds = new DataSet();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, cn);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (NpgsqlException ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public static DataSet selecionarDataSet(string tabela, string campos, string where = "", string orderBy = "")
        {
            try
            {
                Conectar();

                DataSet ds = new DataSet();
                string sql = @"select " + campos + " from " + tabela;
                if (where != "")
                    sql += @" where " + where + " ";
                if (orderBy != "")
                    sql += @" order by " + orderBy + " ";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, cn);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                da.Fill(ds, tabela);
                return ds;
            }
            catch (NpgsqlException ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
    }
}

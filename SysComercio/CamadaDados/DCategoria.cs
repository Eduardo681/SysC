using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace CamadaDados
{
    public class DCategoria
    {
        /*Variaveis*/
        private int _Idcategoria;
        private string _Nome;
        private string _Descricao;
        private string _TextoBuscar;

        /**GET AND SET*/
        public int Idcategoria { get => _Idcategoria; set => _Idcategoria = value; }
        public string Nome { get => _Nome; set => _Nome = value; }
        public string Descricao { get => _Descricao; set => _Descricao = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        /*Contrutores */
        public DCategoria() { }
 
        public DCategoria(int idcategoria, string nome, string descricao, string textobuscar) {
            this.Idcategoria = idcategoria;
            this.Nome = nome;
            this.Descricao = descricao;
            this.TextoBuscar = textobuscar;
        }

        /*Metodos*/

        public string Inserir(DCategoria Categoria)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();
                
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinserir_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@id";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Direction = ParameterDirection.Output;

                SqlParameter ParNomecategoria = new SqlParameter();
                ParNomecategoria.ParameterName = "@nome";
                ParNomecategoria.SqlDbType = SqlDbType.VarChar;
                ParNomecategoria.Size = 50;
                ParNomecategoria.Value = Categoria.Nome;

                SqlParameter ParDescricaocategoria = new SqlParameter();
                ParDescricaocategoria.ParameterName = "@descricao";
                ParDescricaocategoria.SqlDbType = SqlDbType.VarChar;
                ParDescricaocategoria.Size = 100;
                ParDescricaocategoria.Value = Categoria.Descricao;

                SqlCmd.Parameters.Add(ParIdcategoria);
                SqlCmd.Parameters.Add(ParNomecategoria);
                SqlCmd.Parameters.Add(ParDescricaocategoria);

                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Erro ao inserir";

            } catch(Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return resp;
        }

        public string Editar(DCategoria Categoria)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@id";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Value = Categoria.Idcategoria;

                SqlParameter ParNomecategoria = new SqlParameter();
                ParNomecategoria.ParameterName = "@nome";
                ParNomecategoria.SqlDbType = SqlDbType.VarChar;
                ParNomecategoria.Size = 50;
                ParNomecategoria.Value = Categoria.Nome;

                SqlParameter ParDescricaocategoria = new SqlParameter();
                ParDescricaocategoria.ParameterName = "@descricao";
                ParDescricaocategoria.SqlDbType = SqlDbType.VarChar;
                ParDescricaocategoria.Size = 100;
                ParDescricaocategoria.Value = Categoria.Descricao;

                SqlCmd.Parameters.Add(ParIdcategoria);
                SqlCmd.Parameters.Add(ParNomecategoria);
                SqlCmd.Parameters.Add(ParDescricaocategoria);

                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Erro ao editar";

            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return resp;
        }

        public string Excluir(DCategoria Categoria)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spdeletar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@id";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Value = Categoria.Idcategoria;

                SqlCmd.Parameters.Add(ParIdcategoria);

                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Erro ao excluir";

            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return resp;
        }

        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDat = new SqlDataAdapter(SqlCmd);
                sqlDat.Fill(DtResultado);
            }catch(Exception ex)
            {
                DtResultado = null;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return DtResultado;
        }
        public DataTable BuscarNome(DCategoria Categoria)
        {
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_nome";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDat = new SqlDataAdapter(SqlCmd);
                sqlDat.Fill(DtResultado);

                SqlParameter ParNomecategoria = new SqlParameter();
                ParNomecategoria.ParameterName = "@textobuscar";
                ParNomecategoria.SqlDbType = SqlDbType.VarChar;
                ParNomecategoria.Size = 50;
                ParNomecategoria.Value = Categoria.TextoBuscar;
                SqlCmd.Parameters.Add(ParNomecategoria);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return DtResultado;
        }
    }
}

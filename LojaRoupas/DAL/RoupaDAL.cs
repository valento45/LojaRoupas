using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LojaRoupas.DAL
{
    class RoupaDAL
    {
        Conexao con = new Conexao();
        
        public void Cadastrar(BLL.Roupa roupa)
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO LOJA.ROUPA (DESCRICAO, IDCATEGORIA, QUANTIDADE, PRECOBRUTO, PRECOVENDA, OBSERVACOES) VALUES (@DESCRICAO, @IDCATEGORIA, @QUANTIDADE, @PRECOBRUTO, @PRECOVENDA, @OBSERVACOES)", con.Conectar());
            cmd.Parameters.AddWithValue("@DESCRICAO", roupa.Descricao);
            cmd.Parameters.AddWithValue("@IDCATEGORIA", roupa.Idcategoria);
            cmd.Parameters.AddWithValue("@QUANTIDADE", roupa.Quantidade);
            cmd.Parameters.AddWithValue("@PRECOBRUTO", roupa.Precobruto);
            cmd.Parameters.AddWithValue("@PRECOVENDA", roupa.Precovenda);
            cmd.Parameters.AddWithValue("@OBSERVACOES", roupa.Observacoes);
            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public void Atualizar(BLL.Roupa roupa)
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE LOJA.ROUPA SET DESCRICAO = @DESCRICAO, IDCATEGORIA = @IDCATEGORIA, QUANTIDADE = @QUANTIDADE, PRECOBRUTO = @PRECOBRUTO, PRECOVENDA = @PRECOVENDA, OBSERVACOES = @OBSERVACOES WHERE IDROUPA = @IDROUPA", con.Conectar());
            cmd.Parameters.AddWithValue("@IDROUPA", roupa.Idroupa);
            cmd.Parameters.AddWithValue("@DESCRICAO", roupa.Descricao);
            cmd.Parameters.AddWithValue("@IDCATEGORIA", roupa.Idcategoria);
            cmd.Parameters.AddWithValue("@QUANTIDADE", roupa.Quantidade);
            cmd.Parameters.AddWithValue("@PRECOBRUTO", roupa.Precobruto);
            cmd.Parameters.AddWithValue("@PRECOVENDA", roupa.Precovenda);
            cmd.Parameters.AddWithValue("@OBSERVACOES", roupa.Observacoes);
            cmd.ExecuteNonQuery();
            con.Desconectar();
        }
        public void BaixarEstoque(BLL.Roupa produto)
        {
            SqlCommand cmd = new SqlCommand("UPDATE LOJA.ROUPA SET QUANTIDADE = QUANTIDADE - @QUANTIDADE WHERE IDROUPA = @IDROUPA", con.Conectar());
            cmd.Parameters.AddWithValue("@IDROUPA", produto.Idroupa);
            cmd.Parameters.AddWithValue("@QUANTIDADE", produto.Quantidade);
            cmd.ExecuteNonQuery();
            con.Desconectar();
        }
        public void Excluir(BLL.Roupa roupa)
        {
            SqlCommand cmd = new SqlCommand(@"DELETE FROM LOJA.ROUPA WHERE IDROUPA = @IDROUPA",con.Conectar());
            cmd.Parameters.AddWithValue("@IDROUPA", roupa.Idroupa);
            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public BLL.Roupa RetornarDados(BLL.Roupa roupa)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM LOJA.ROUPA WHERE IDROUPA = @IDROUPA",con.Conectar());
            cmd.Parameters.AddWithValue("@IDROUPA", roupa.Idroupa);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                roupa.Idroupa = Convert.ToInt16(dr["IDROUPA"]);
                roupa.Idcategoria = Convert.ToInt16(dr["IDCATEGORIA"]);
                roupa.Descricao = dr["DESCRICAO"].ToString();
                roupa.Quantidade = Convert.ToInt16(dr["QUANTIDADE"]);
                roupa.Precobruto = Convert.ToDecimal(dr["PRECOBRUTO"]);
                roupa.Precovenda = Convert.ToDecimal(dr["PRECOVENDA"]);
                roupa.Observacoes = dr["OBSERVACOES"].ToString();
            }
            dr.Close();
            con.Desconectar();
            return roupa;
        }

        public DataTable ConsultarTodos()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT IDROUPA AS CÓDIGO, IDCATEGORIA AS CATEGORIA, DESCRICAO, QUANTIDADE, PRECOBRUTO, PRECOVENDA, OBSERVACOES FROM LOJA.ROUPA",con.Conectar());
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Desconectar();
            return dt;
        }

        public DataTable ConsultarPorDescricao(BLL.Roupa roupa)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT IDROUPA AS CÓDIGO, IDCATEGORIA AS CATEGORIA, DESCRICAO, QUANTIDADE, PRECOBRUTO, PRECOVENDA, OBSERVACOES FROM LOJA.ROUPA WHERE DESCRICAO LIKE @DESCRICAO", con.Conectar());
            da.SelectCommand.Parameters.AddWithValue("@DESCRICAO", roupa.Descricao + "%");
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Desconectar();
            return dt;
        }

        public DataTable ConsultarPorCodigo(BLL.Roupa roupa)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT IDROUPA AS CÓDIGO, IDCATEGORIA AS CATEGORIA, DESCRICAO, QUANTIDADE, PRECOVENDA, OBSERVACOES FROM LOJA.ROUPA WHERE IDROUPA LIKE @IDROUPA",con.Conectar());
            da.SelectCommand.Parameters.AddWithValue("@IDROUPA", roupa.Idroupa + "%");
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Desconectar();
            return dt;

        }
    }
}

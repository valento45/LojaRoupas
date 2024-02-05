using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LojaRoupas.DAL
{
    class CategoriaDAL
    {
        Conexao con = new Conexao();

        public void Cadastrar(BLL.Categorias categorias)
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO LOJA.CATEGORIA (CATEGORIA) VALUES (@CATEGORIA)",con.Conectar());
            cmd.Parameters.AddWithValue("@CATEGORIA", categorias.Categoria);
            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public void Atualizar(BLL.Categorias categorias)
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE LOJA.CATEGORIA SET CATEGORIA = @CATEGORIA WHERE IDCATEGORIA = @IDCATEGORIA",con.Conectar());
            cmd.Parameters.AddWithValue("@CATEGORIA", categorias.Categoria);
            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public void Excluir(BLL.Categorias categorias)
        {
            SqlCommand cmd = new SqlCommand(@"DELETE FROM LOJA.CATEGORIA WHERE IDCATEGORIA = @IDCATEGORIA",con.Conectar());
            cmd.Parameters.AddWithValue("@IDCATEGORIA", categorias.Idcategoria);
            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public BLL.Categorias RetornarDados(BLL.Categorias categorias)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM LOJA.CATEGORIA WHERE IDCATEGORIA = @IDCATEGORIA",con.Conectar());
            cmd.Parameters.AddWithValue("@IDCATEGORIA", categorias.Idcategoria);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                categorias.Idcategoria = Convert.ToInt16(dr["IDCATEGORIA"]);
                categorias.Categoria = dr["CATEGORIA"].ToString();
            }
            dr.Close();
            con.Desconectar();
            return categorias;
        }

        public DataTable ConsultarTodos()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT IDCATEGORIA, CATEGORIA FROM LOJA.CATEGORIA",con.Conectar());
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Desconectar();
            return dt;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LojaRoupas.DAL
{
    class ItenDAL
    {
        Conexao con = new Conexao();

        public void Cadastrar(BLL.Iten iten)
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO LOJA.ITEN (IDVENDA, IDROUPA, PRECOUNITARIO, QUANTPEDIDO) VALUES (@IDVENDA, @IDROUPA, @PRECOUNITARIO, @QUANTPEDIDO)", con.Conectar());
            cmd.Parameters.AddWithValue("@IDVENDA", iten.Idvenda);
            cmd.Parameters.AddWithValue("@IDROUPA", iten.Idroupa);
            cmd.Parameters.AddWithValue("@PRECOUNITARIO", iten.Precounitario);
            cmd.Parameters.AddWithValue("@QUANTPEDIDO", iten.Quantpedido);
            cmd.ExecuteNonQuery();
            con.Desconectar();
        }
        public void Atualizar(BLL.Iten iten)
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE LOJA.ITEN SET IDVENDA = @IDVENDA, IDROUPA = @IDROUPA, PRECOUNITARIO = @PRECOUNITARIO, QUANTPEDIDO = @QUANTPEDIDO WHERE IDITEN = @IDITEN",con.Conectar());
            cmd.Parameters.AddWithValue("@IDVENDA", iten.Idvenda);
            cmd.Parameters.AddWithValue("@IDROUPA", iten.Idroupa);
            cmd.Parameters.AddWithValue("@PRECOUNITARIO", iten.Precounitario);
            cmd.Parameters.AddWithValue("@QUANTPEDIDO", iten.Quantpedido);
            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public void Excluir(BLL.Iten iten)
        {
            SqlCommand cmd = new SqlCommand(@"DELETE FROM LOJA.ROUPA WHERE IDITEN = @IDITEN",con.Conectar());
            cmd.Parameters.AddWithValue("@IDITEN", iten.Iditen);
            cmd.ExecuteNonQuery();
            con.Desconectar();
        }
        public BLL.Iten RetornarDados(BLL.Iten iten)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM LOJA.ITEN WHERE IDITEN = @IDITEN", con.Conectar());
            cmd.Parameters.AddWithValue("@IDITEN", iten.Iditen);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                iten.Iditen = Convert.ToInt16(dr["IDITEN"]);
                iten.Idvenda = Convert.ToInt16(dr["IDVENDA"]);
                iten.Idroupa = Convert.ToInt16(dr["IDROUPA"]);
                iten.Precounitario = Convert.ToDecimal(dr["PRECOUNITARIO"]);
                iten.Quantpedido = Convert.ToInt16(dr["QUANTPEDIDO"]);
            }
            dr.Close();
            con.Desconectar();
            return iten;     
        }
        public DataTable ConsultarTodos()
        {
           SqlDataAdapter da = new SqlDataAdapter("SELECT I.IDITEN, I.IDVENDA, I.IDROUPA AS IDPRODUTO, I.PRECOUNITARIO, I.QUANTPEDIDO, V.PRECOTOTAL FROM LOJA.ITEN AS I, LOJA.VENDA AS V WHERE I.IDVENDA = V.IDVENDA", con.Conectar());
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Desconectar();
            return dt;
            

        }
    }
}

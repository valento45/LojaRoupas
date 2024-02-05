using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LojaRoupas.DAL
{
    class vendaDAL
    {
        Conexao con = new Conexao();

        public int Cadastrar(BLL.Venda venda)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO LOJA.VENDA (DATAVENDA, IDCLIENTE, PRECOTOTAL, PAGAMENTO) VALUES (GETDATE(),@IDCLIENTE, @PRECOTOTAL, @PAGAMENTO);SELECT SCOPE_IDENTITY();", con.Conectar());
            cmd.Parameters.AddWithValue("@DATAVENDA", venda.Datavenda);
            cmd.Parameters.AddWithValue("@IDCLIENTE", venda.Idcliente);
            cmd.Parameters.AddWithValue("@PRECOTOTAL", venda.Precototal);
            cmd.Parameters.AddWithValue("@PAGAMENTO", venda.Pagamento);
            int chave_gerada = 0;
            chave_gerada = Convert.ToInt16(cmd.ExecuteScalar());
            con.Desconectar();
            return chave_gerada;
        }

        public void Atualizar(BLL.Venda venda)
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE LOJA.VENDA SET DATAVENDA = @DATAVENDA, IDCLIENTE = @IDCLIENTE, PRECOTOTAL = @PRECOTOTAL, PAGAMENTO = @PAGAMENTO WHERE IDVENDA = @IDVENDA",con.Conectar());
            cmd.Parameters.AddWithValue("@DATAVENDA", venda.Datavenda);
            cmd.Parameters.AddWithValue("@IDCLIENTE", venda.Idcliente);
            cmd.Parameters.AddWithValue("@PRECOTOTAL", venda.Precototal);
            cmd.Parameters.AddWithValue("@PAGAMENTO", venda.Pagamento);
            cmd.ExecuteNonQuery();
            con.Desconectar();
        }
        
        public void Excluir(BLL.Venda venda)
        {
            SqlCommand cmd = new SqlCommand(@"DELETE FROM LOJA.VENDA WHERE IDVENDA = @IDVENDA", con.Conectar());
            cmd.Parameters.AddWithValue("@IDVENDA", venda.Idvenda);
            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public BLL.Venda RetornarDados(BLL.Venda venda)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM LOJA.VENDA WHERE IDVENDA = @IDVENDA",con.Conectar());
            cmd.Parameters.AddWithValue("@IDVENDA", venda.Idvenda);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                venda.Idvenda = Convert.ToInt16(dr["IDVENDA"]);                
                venda.Datavenda = Convert.ToDateTime(dr["DATAVENDA"]);
                venda.Idcliente = Convert.ToInt16(dr["IDCLIENTE"]);
                venda.Precototal = Convert.ToDecimal(dr["PRECOTOTAL"]);
                venda.Pagamento = dr["PAGAMENTO"].ToString();
            }
            dr.Close();
            con.Desconectar();
            return venda;
        }

        public DataTable ConsultarTodos()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT IDVENDA, DATAVENDA, PRECOTOTAL, PAGAMENTO FROM LOJA.VENDA", con.Conectar());
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Desconectar();
            return dt; //retornar tabela preenchida
        }
    }
}

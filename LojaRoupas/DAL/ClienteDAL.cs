using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LojaRoupas.DAL
{
    class ClienteDAL
    {
        Conexao con = new Conexao();

        public void Cadastrar(BLL.Cliente cliente)
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO LOJA.CLIENTE (NOME, RG, CPF, TELEFONE, ENDERECO) VALUES (@NOME, @RG, @CPF, @TELEFONE, @ENDERECO)", con.Conectar());
            cmd.Parameters.AddWithValue("@NOME", cliente.Nome);
            cmd.Parameters.AddWithValue("@RG", cliente.Rg);
            cmd.Parameters.AddWithValue("@CPF", cliente.Cpf);
            cmd.Parameters.AddWithValue("@TELEFONE", cliente.Telefone);
            cmd.Parameters.AddWithValue("@ENDERECO", cliente.Endereco);
            cmd.ExecuteNonQuery();
            con.Desconectar();
        }
        public void Atualizar(BLL.Cliente cliente)
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE LOJA.CLIENTE SET NOME = @NOME, RG = @RG, CPF = @CPF, TELEFONE = @TELEFONE, ENDERECO = @ENDERECO WHERE IDCLIENTE = @IDCLIENTE",con.Conectar());
            cmd.Parameters.AddWithValue("@IDCLIENTE", cliente.Idcliente);
            cmd.Parameters.AddWithValue("@NOME", cliente.Nome);
            cmd.Parameters.AddWithValue("@RG", cliente.Rg);
            cmd.Parameters.AddWithValue("@CPF", cliente.Cpf);
            cmd.Parameters.AddWithValue("@TELEFONE", cliente.Telefone);
            cmd.Parameters.AddWithValue("@ENDERECO", cliente.Endereco);            
            cmd.ExecuteNonQuery();            
            con.Desconectar();
            
            
        }

        public void Excluir(BLL.Cliente cliente)
        {
            SqlCommand cmd = new SqlCommand(@"DELETE FROM LOJA.CLIENTE WHERE IDCLIENTE = @IDCLIENTE",con.Conectar());
            cmd.Parameters.AddWithValue("@IDCLIENTE", cliente.Idcliente);
            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public BLL.Cliente RetornarDados(BLL.Cliente cliente)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM LOJA.CLIENTE WHERE IDCLIENTE = @IDCLIENTE",con.Conectar());
            cmd.Parameters.AddWithValue("@IDCLIENTE", cliente.Idcliente);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                cliente.Idcliente = Convert.ToInt16(dr["IDCLIENTE"]);
                cliente.Nome = dr["NOME"].ToString();
                cliente.Rg = dr["RG"].ToString();
                cliente.Cpf = dr["CPF"].ToString();
                cliente.Telefone = dr["TELEFONE"].ToString();
                cliente.Endereco = dr["ENDERECO"].ToString();
            }
            dr.Close();
            con.Desconectar();
            return cliente;
        }
        public DataTable ConsultarTodos()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT IDCLIENTE AS CLIENTE, NOME, RG, CPF, TELEFONE, ENDERECO FROM LOJA.CLIENTE",con.Conectar());
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Desconectar();
            return dt;
        }
        public DataTable ConsultarPorCliente(BLL.Cliente cliente)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT IDCLIENTE AS CLIENTE, NOME, RG, CPF, TELEFONE, ENDERECO FROM LOJA.CLIENTE WHERE NOME LIKE @NOME", con.Conectar());
            da.SelectCommand.Parameters.AddWithValue("@NOME", cliente.Nome + "%");
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Desconectar();
            return dt;

        }

    }
}

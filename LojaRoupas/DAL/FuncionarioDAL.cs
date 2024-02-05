using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LojaRoupas.DAL
{
    class FuncionarioDAL
    {
        Conexao con = new Conexao();

        //METODO CADASTRAR
        public void Cadastrar(BLL.Funcionario funcionario)
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO LOJA.FUNCIONARIO (NOME, RG, CPF, TELEFONE, ENDERECO, CARGO, SALARIO) VALUES (@NOME, @RG, @CPF, @TELEFONE, @ENDERECO, @CARGO, @SALARIO)", con.Conectar());
            cmd.Parameters.AddWithValue("@NOME", funcionario.Nome);
            cmd.Parameters.AddWithValue("@RG", funcionario.Rg);
            cmd.Parameters.AddWithValue("@CPF", funcionario.Cpf);
            cmd.Parameters.AddWithValue("@TELEFONE", funcionario.Telefone);
            cmd.Parameters.AddWithValue("@ENDERECO", funcionario.Endereco);
            cmd.Parameters.AddWithValue("@CARGO", funcionario.Cargo);
            cmd.Parameters.AddWithValue("@SALARIO", funcionario.Salario);
            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public void Atualizar(BLL.Funcionario funcionario)
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE LOJA.FUNCIONARIO SET NOME = @NOME, RG = @RG, CPF = @CPF, TELEFONE = @TELEFONE, ENDERECO = @ENDERECO, CARGO = @CARGO, SALARIO = @SALARIO WHERE IDFUNCIONARIO = @IDFUNCIONARIO",con.Conectar());
            cmd.Parameters.AddWithValue("@IDFUNCIONARIO", funcionario.Idfuncionario);
            cmd.Parameters.AddWithValue("@NOME", funcionario.Nome);
            cmd.Parameters.AddWithValue("@RG", funcionario.Rg);
            cmd.Parameters.AddWithValue("@CPF", funcionario.Cpf);
            cmd.Parameters.AddWithValue("@TELEFONE", funcionario.Telefone);
            cmd.Parameters.AddWithValue("@ENDERECO", funcionario.Endereco);
            cmd.Parameters.AddWithValue("@CARGO", funcionario.Cargo);
            cmd.Parameters.AddWithValue("@SALARIO", funcionario.Salario);
            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public void Excluir(BLL.Funcionario funcionario)
        {
            SqlCommand cmd = new SqlCommand(@"DELETE FROM LOJA.FUNCIONARIO WHERE IDFUNCIONARIO = @IDFUNCIONARIO",con.Conectar());
            cmd.Parameters.AddWithValue("@IDFUNCIONARIO", funcionario.Idfuncionario);
            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public BLL.Funcionario RetornarDados(BLL.Funcionario funcionario)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM LOJA.FUNCIONARIO WHERE IDFUNCIONARIO = @IDFUNCIONARIO",con.Conectar());
            cmd.Parameters.AddWithValue("@IDFUNCIONARIO",funcionario.Idfuncionario);
            SqlDataReader dr = cmd.ExecuteReader();//executa leitura dos dados
            if(dr.Read())//conseguiu ler?
            {
                funcionario.Idfuncionario = Convert.ToInt16(dr["IDFUNCIONARIO"]);
                funcionario.Nome = dr["NOME"].ToString();
                funcionario.Rg = dr["RG"].ToString();
                funcionario.Cpf = dr["CPF"].ToString();
                funcionario.Telefone = dr["TELEFONE"].ToString();
                funcionario.Cargo = dr["CARGO"].ToString();
                funcionario.Salario = Convert.ToDecimal(dr["SALARIO"]);
            }
            dr.Close();
            con.Desconectar();
            return funcionario;
        }

        public DataTable ConsultarTodos()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT IDFUNCIONARIO AS FUNCIONÁRIO, NOME, RG, CPF, ENDERECO AS ENDEREÇO, CARGO, SALARIO FROM LOJA.FUNCIONARIO",con.Conectar());
            DataTable dt = new DataTable();//criando tabela de dados
            da.Fill(dt);
            con.Desconectar();
            return dt;
        }
        public DataTable ConsultarPorNome(BLL.Funcionario funcionario)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT IDFUNCIONARIO AS FUNCIONÁRIO, NOME, RG, CPF, ENDERECO, CARGO, SALARIO FROM LOJA.FUNCIONARIO WHERE NOME LIKE @NOME", con.Conectar());
            da.SelectCommand.Parameters.AddWithValue("@NOME", funcionario.Nome + "%");

            DataTable dt = new DataTable();//criando tabela de dados
            da.Fill(dt);
            con.Desconectar();
            return dt;

        }
    }
}

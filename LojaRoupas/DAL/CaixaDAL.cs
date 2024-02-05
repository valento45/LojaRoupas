using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LojaRoupas.DAL
{
    class CaixaDAL
    {
        Conexao con = new Conexao();

        public void Cadastrar(BLL.Caixa caixa)
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO LOJA.CAIXA (IDUSUARIO, DATA, VALOR) VALUES (@IDUSUARIO, @DATA, @VALOR)", con.Conectar());
            cmd.Parameters.AddWithValue("@IDUSUARIO", caixa.Idusuario);
            cmd.Parameters.AddWithValue("@DATA", caixa.Data);
            cmd.Parameters.AddWithValue("@VALOR", caixa.Valor);
            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public void Atualizar(BLL.Caixa caixa)
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE FROM LOJA.CAIXA SET IDUSUARIO = @IDUSUARIO, DATA = @DATA, VALOR = @VALOR WHERE IDCAIXA = @IDCAIXA",con.Conectar());
            cmd.Parameters.AddWithValue("@IDUSUARIO", caixa.Idusuario);
            cmd.Parameters.AddWithValue("@DATA", caixa.Data);
            cmd.Parameters.AddWithValue("VALOR", caixa.Valor);
            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public void Excluir(BLL.Caixa caixa)
        {
            SqlCommand cmd = new SqlCommand(@"DELETE FROM LOJA.CAIXA WHERE IDCAIXA = @IDCAIXA", con.Conectar());
            cmd.Parameters.AddWithValue("@IDCAIXA", caixa.Idcaixa);
            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public BLL.Caixa RetornarDados(BLL.Caixa caixa)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM LOJA.CAIXA WHERE IDCAIXA = @IDCAIXA", con.Conectar());
            cmd.Parameters.AddWithValue("@IDCAIXA", caixa.Idcaixa);
            SqlDataReader dr = cmd.ExecuteReader();//executa leitura dos dados
            if(dr.Read())//conseguiu ler?
            {//preencher os atributos da classe
                caixa.Idcaixa = Convert.ToInt16(dr["IDCAIXA"]);
                caixa.Idusuario = Convert.ToInt16(dr["IDUSUARIO"]);
                caixa.Data = Convert.ToDateTime(dr["DATA"]);
                caixa.Valor = Convert.ToDecimal(dr["VALOR"]);                 
            }
            dr.Close();
            con.Desconectar();
            return caixa;
        }

        public DataTable ConsultarTodos()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT IDCAIXA AS CAIXA, IDUSUARIO AS USUÁRIO, DATA, VALOR FROM LOJA.CAIXA",con.Conectar());
            DataTable dt = new DataTable();//criando tabela de dados
            da.Fill(dt);//preenchendo tabelade dados criada
            con.Desconectar();
            return dt; //retornar tabela preenchhida
        }

    }
}

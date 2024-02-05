using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LojaRoupas.DAL
{
    class UsuarioDAL
    { 
        //instanciar con da classe conexao
        Conexao con = new Conexao();

       public void Cadastrar(BLL.Usuario usuario)
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO LOJA.USUARIO (NOME, USUARIO, SENHA, EMAIL, TIPO) VALUES (@NOME, @USUARIO, @SENHA, @EMAIL, @TIPO)", con.Conectar());
            cmd.Parameters.AddWithValue("@NOME", usuario.Nome);
            cmd.Parameters.AddWithValue("@USUARIO", usuario.User);
            cmd.Parameters.AddWithValue("@SENHA", usuario.Senha);
            cmd.Parameters.AddWithValue("@EMAIL", usuario.Email);
            cmd.Parameters.AddWithValue("@TIPO", usuario.Tipo);
            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public void Atualizar(BLL.Usuario usuario)
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE LOJA.USUARIO SET NOME = @NOME, USUARIO = @USUARIO, SENHA = @SENHA, EMAIL = @EMAIL, TIPO = @TIPO WHERE IDUSUARIO = @IDUSUARIO", con.Conectar());
            cmd.Parameters.AddWithValue("@NOME", usuario.Nome);
            cmd.Parameters.AddWithValue("@USUARIO", usuario.User);
            cmd.Parameters.AddWithValue("@SENHA", usuario.Senha);
            cmd.Parameters.AddWithValue("@EMAIL", usuario.Email);
            cmd.Parameters.AddWithValue("@TIPO", usuario.Tipo);
            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public void Excluir(BLL.Usuario usuario)
        {
            SqlCommand cmd = new SqlCommand(@"DELETE FROM LOJA.USUARIO WHERE IDUSUARIO = @IDUSUARIO", con.Conectar());
            cmd.Parameters.AddWithValue("@IDUSUARIO", usuario.Idusuario);
            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public BLL.Usuario RetornarDados(BLL.Usuario usuario)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM LOJA.USUARIO WHERE IDUSUARIO = @IDUSUARIO", con.Conectar());
            cmd.Parameters.AddWithValue("@IDUSUARIO", usuario.Idusuario);
            SqlDataReader dr = cmd.ExecuteReader();//executa uma leitura dos dados
            if(dr.Read())//conseguiur ler?
            {//preencher os atributos da classe
                usuario.Idusuario = Convert.ToInt16(dr["IDUSUARIO"]);
                usuario.Nome = dr["NOME"].ToString();
                usuario.Senha = dr["SENHA"].ToString();
                usuario.Email = dr["EMAIL"].ToString();
                usuario.Tipo = Convert.ToBoolean(dr["TIPO"]);
            }
            dr.Close();
            con.Desconectar();
            return usuario;
        }

        public DataTable ConsultarTodos()
        {
            //passando comando de consulta
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT IDUSUARIO, NOME, USUARIO, EMAIL, TIPO FROM LOJA.USUARIO",con.Conectar());
            DataTable dt = new DataTable();//criando tabela de dados
            da.Fill(dt);//preenchendo tabela de dados
            con.Desconectar();
            return dt;//retornando tabela preenchida
        }

        public DataTable ConsultarPorUsuario(BLL.Usuario usuario)
        {
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT IDUSUARIO, NOME, USUARIO, EMAIL, TIPO FROM LOJA.USUARIO WHERE USUARIO LIKE @USUARIO ",con.Conectar());
            DataTable dt = new DataTable();//criando tabela de dados
            da.Fill(dt);
            con.Desconectar();
            return dt;
        }


        public BLL.Usuario Logar(BLL.Usuario usuario)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM LOJA.USUARIO WHERE USUARIO = @USUARIO AND SENHA = @SENHA", con.Conectar());
            cmd.Parameters.AddWithValue("@USUARIO", usuario.User);
            cmd.Parameters.AddWithValue("@SENHA", usuario.Senha);

            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                usuario.Idusuario = Convert.ToInt16(dr["IDUSUARIO"]);
                usuario.User = dr["USUARIO"].ToString();
                usuario.Senha = dr["SENHA"].ToString();
            }
            else
            {
                usuario.Idusuario = 0;
            }
            dr.Close();
            con.Desconectar();
            return usuario;
        }
    }
}

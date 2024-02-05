using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace LojaRoupas.DAL
{
    class Conexao
    {
        SqlConnection con = new SqlConnection(@"Data Source=RMX\SQLEXPRESS;Initial Catalog=BDLOJA;Integrated Security=True");

        public SqlConnection Conectar()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();//abrindo conexão
            }

            return con;//retorna a conexão aberta
        }

        public void Desconectar()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

    }
}


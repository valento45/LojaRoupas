using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LojaRoupas.UI
{
    public partial class frmCadUsuario : Form
    {
        BLL.Usuario usuario = new BLL.Usuario();
        DAL.UsuarioDAL usuarioDAL = new DAL.UsuarioDAL();

        bool alterar = false;

        public frmCadUsuario()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.Trim() == "" || txtNome.Text.Trim() == "" || txtSenha.Text.Trim() == "" || txtConfirmarSenha.Text.Trim() == "" || txtUsuario.Text.Trim() == "" || cmbTipo.Text.Trim() == "")
            {
                MessageBox.Show("Todos os campos são de preenchimento obrigatório!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtSenha.Text.Trim() != txtConfirmarSenha.Text.Trim())
            {
                MessageBox.Show("As senhas não conferem", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



                usuario.Nome = txtNome.Text.ToString();
                usuario.User = txtUsuario.Text.ToString();
                usuario.Senha = txtSenha.Text.ToString();
                usuario.Email = txtEmail.Text.ToString();               
                if(cmbTipo.Text == "Admnistrador")
                {
                    usuario.Tipo = true;
                   
                }
                else
                {                   
                    usuario.Tipo = false;

                }

                if (alterar == true)
                {
                    usuarioDAL.Atualizar(usuario);
                    MessageBox.Show("Dados Atualizado com Sucesso!");

                }
                else
                {
                    usuarioDAL.Cadastrar(usuario);
                    MessageBox.Show("Usuário Cadastrado com Sucesso!","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtNome.Text = "";
                txtUsuario.Text = "";
                txtSenha.Text = "";
                txtConfirmarSenha.Text = "";
                txtEmail.Text = "";
                cmbTipo.Text = "";
                }
            
           

           

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCadUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}

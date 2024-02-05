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
    public partial class frmCadCliente : Form
    {
        BLL.Cliente cliente = new BLL.Cliente();
        DAL.ClienteDAL clienteDAL = new DAL.ClienteDAL();
        bool alterar = false;

        public frmCadCliente()
        {
            InitializeComponent();
        }

        public frmCadCliente(int codcli)
        {
            InitializeComponent();

            cliente.Idcliente = codcli;
            clienteDAL.RetornarDados(cliente);

            txtNome.Text = cliente.Nome;
            txtRg.Text = cliente.Rg;
            txtCpf.Text = cliente.Cpf;
            txtTelefone.Text = cliente.Telefone;
            txtEndereco.Text = cliente.Endereco;

            alterar = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            cliente.Nome = txtNome.Text.ToString();
            cliente.Rg = txtRg.Text.ToString();
            cliente.Cpf = txtCpf.Text.ToString();
            cliente.Telefone = txtTelefone.Text.ToString();
            cliente.Endereco = txtEndereco.Text.ToString();
            
            if(alterar == true)
            {
                clienteDAL.Atualizar(cliente);
                MessageBox.Show("Dados Alterados com Sucesso!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                clienteDAL.Cadastrar(cliente);
                MessageBox.Show("Cliente Salvo com Sucesso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Clear();
                txtRg.Clear();
                txtCpf.Clear();
                txtTelefone.Clear();
                txtEndereco.Clear();
            }
        }

        private void frmCadCliente_Load(object sender, EventArgs e)
        {

        }
    }
}

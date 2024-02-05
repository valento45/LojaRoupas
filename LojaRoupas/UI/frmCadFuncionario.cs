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
    public partial class frmCadFuncionario : Form
    {
        BLL.Funcionario funcionario = new BLL.Funcionario();
        DAL.FuncionarioDAL funcionarioDAL = new DAL.FuncionarioDAL();
        bool alterar = false;
        public frmCadFuncionario()
        {
            InitializeComponent();
        }

        public frmCadFuncionario(int codfuncionario)
        {
            InitializeComponent();

            funcionario.Idfuncionario = codfuncionario;
            funcionarioDAL.RetornarDados(funcionario);

            txtNome.Text = funcionario.Nome;
            txtRg.Text = funcionario.Rg;
            txtCpf.Text = funcionario.Cpf;
            txtTelefone.Text = funcionario.Telefone;
            txtEndereco.Text = funcionario.Endereco;
            txtCargo.Text = funcionario.Cargo;
            txtSalario.Text = funcionario.Salario.ToString();
            alterar = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            funcionario.Nome = txtNome.Text.ToString();
            funcionario.Rg = txtRg.Text.ToString();
            funcionario.Cpf = txtCpf.Text.ToString();
            funcionario.Telefone = txtTelefone.Text.ToString();
            funcionario.Endereco = txtEndereco.Text.ToString();
            funcionario.Cargo = txtCargo.Text.ToString();
            funcionario.Salario = Convert.ToDecimal(txtSalario.Text);

            if(alterar == true)
            {
                funcionarioDAL.Atualizar(funcionario);
                MessageBox.Show("Dados Alterados com Sucesso!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);         
            }
            else
            {
                funcionarioDAL.Cadastrar(funcionario);
                MessageBox.Show("Dados Salvo com Sucesso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Clear();
                txtRg.Clear();
                txtCpf.Clear();
                txtTelefone.Clear();
                txtEndereco.Clear();
                txtSalario.Clear();

            }
               
        }

        private void frmCadFuncionario_Load(object sender, EventArgs e)
        {

        }
    }
}

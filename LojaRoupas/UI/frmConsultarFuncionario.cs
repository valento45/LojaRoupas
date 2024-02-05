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
    public partial class frmConsultarFuncionario : Form
    {
        BLL.Funcionario funcionario = new BLL.Funcionario();
        DAL.FuncionarioDAL funcionarioDAL = new DAL.FuncionarioDAL();

        public frmConsultarFuncionario()
        {
            InitializeComponent();
        }

        private void excluirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Deseja realmente Excluir este Funcionário?","Atenção!",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    funcionario.Idfuncionario = Convert.ToInt16(dgvConsultarCliente.SelectedCells[0].Value);
                    funcionarioDAL.Excluir(funcionario);
                    MessageBox.Show("Funcionário Excluído com sucesso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvConsultarCliente.DataSource = funcionarioDAL.ConsultarTodos();
                }
                catch
                {
                    MessageBox.Show("Não foi possível Excluir este Funcionário!!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void frmConsultarFuncionario_Load(object sender, EventArgs e)
        {
            btnAdicionar.Visible = false;
            dgvConsultarCliente.DataSource = funcionarioDAL.ConsultarTodos();
            
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            funcionario.Nome = txtFiltro.Text;
            dgvConsultarCliente.DataSource = funcionarioDAL.ConsultarPorNome(funcionario);
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //abrir formulário passando código como argumento
            //o código virá do datagridview (primeira coluna)
            frmCadFuncionario funcionario = new frmCadFuncionario(Convert.ToInt16(dgvConsultarCliente.SelectedCells[0].Value));
            funcionario.ShowDialog();

            dgvConsultarCliente.DataSource = funcionarioDAL.ConsultarTodos();
            
          
        }
    }
}

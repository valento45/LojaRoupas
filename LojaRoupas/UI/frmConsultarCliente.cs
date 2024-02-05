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
    public partial class frmConsultarCliente : Form
    {
        BLL.Cliente cliente = new BLL.Cliente();
        DAL.ClienteDAL clienteDAL = new DAL.ClienteDAL();
        public int codcli { get; set;}

        public frmConsultarCliente()
        {
            InitializeComponent();
        }

        private void dgvConsultarCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmConsultarCliente_Load(object sender, EventArgs e)
        {
            
            dgvConsultarCliente.DataSource = clienteDAL.ConsultarTodos();
        }

        private void excluirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Deseja realmente Excluir este Cliente?","Atenção",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    cliente.Idcliente = Convert.ToInt16(dgvConsultarCliente.SelectedCells[0].Value);
                    clienteDAL.Excluir(cliente);
                    MessageBox.Show("Cliente Excluído com Sucesso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgvConsultarCliente.DataSource = clienteDAL.ConsultarTodos();
                }
                catch
                {
                    MessageBox.Show("Não é possível Excluir este Cliente!!!", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (dgvConsultarCliente.RowCount > 0)
            {
                codcli = Convert.ToInt16(dgvConsultarCliente.SelectedCells[0].Value.ToString());
                this.Close();
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            cliente.Nome = txtFiltro.Text;
            dgvConsultarCliente.DataSource = clienteDAL.ConsultarPorCliente(cliente);
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //abrir formulário passando código como argumento
            //o código virá do datagridview (primeira coluna)
            frmCadCliente cli = new frmCadCliente(Convert.ToInt16(dgvConsultarCliente.SelectedCells[0].Value));
            cli.ShowDialog();
            //atualizar a consulta
            dgvConsultarCliente.DataSource = clienteDAL.ConsultarTodos();
        }
    }
}

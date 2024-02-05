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
    public partial class frmConsultarProduto : Form
    {
        BLL.Roupa roupa = new BLL.Roupa();
        DAL.RoupaDAL roupaDAL = new DAL.RoupaDAL();
        public int codproduto { get; set; }

        public frmConsultarProduto()
        {
            InitializeComponent();
        }

        private void frmConsultarProduto_Load(object sender, EventArgs e)
        {
            
            dgvConsultarProduto.DataSource = roupaDAL.ConsultarTodos();
        }

        private void excluirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Deseja Realmente Excluir este Produto?","Atenção!",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    roupa.Idroupa = Convert.ToInt16(dgvConsultarProduto.SelectedCells[0].Value);
                    roupaDAL.Excluir(roupa);
                    dgvConsultarProduto.DataSource = roupaDAL.ConsultarTodos();
                }
                catch
                {
                    MessageBox.Show("Não foi possível Excluir este Produto!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if(dgvConsultarProduto.RowCount > 0)
            {
                codproduto = Convert.ToInt16(dgvConsultarProduto.SelectedCells[0].Value.ToString());
                this.Close();
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            try
            {
                roupa.Idroupa = Convert.ToInt16(txtFiltro.Text);
                dgvConsultarProduto.DataSource = roupaDAL.ConsultarPorCodigo(roupa);
            }
            catch
            {
                dgvConsultarProduto.DataSource = roupaDAL.ConsultarTodos();

                roupa.Descricao = txtFiltro.Text;
                dgvConsultarProduto.DataSource = roupaDAL.ConsultarPorDescricao(roupa);
                
            }
            
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadProduto produto = new frmCadProduto(Convert.ToInt16(dgvConsultarProduto.SelectedCells[0].Value));
            produto.ShowDialog();
            dgvConsultarProduto.DataSource = roupaDAL.ConsultarTodos();
        }

        private void rdbCodigo_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

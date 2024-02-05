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
    public partial class frmEstoque : Form
    {
        BLL.Roupa roupa = new BLL.Roupa();
        DAL.RoupaDAL roupaDAL = new DAL.RoupaDAL();

        public frmEstoque()
        {
            InitializeComponent();
        }

        private void frmEstoque_Load(object sender, EventArgs e)
        {

                dgvConsultarProduto.DataSource = roupaDAL.ConsultarTodos();
           

            
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}

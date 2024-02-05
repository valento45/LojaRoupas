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
    public partial class frmConsultarCategoria : Form
    {
        BLL.Categorias categoria = new BLL.Categorias();
        DAL.CategoriaDAL categoriaDAL = new DAL.CategoriaDAL();
        public frmConsultarCategoria()
        {
            InitializeComponent();
        }

        private void frmConsultarCategoria_Load(object sender, EventArgs e)
        {
            
            btnAdicionar.Visible = false;

            dgvConsultarCategoria.DataSource = categoriaDAL.ConsultarTodos();
        }

        private void excluirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Deseja Realmente Excluir esta Categoria?","Atenção!",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    categoria.Idcategoria = Convert.ToInt16(dgvConsultarCategoria.SelectedCells[0].Value);
                    categoriaDAL.Excluir(categoria);
                    MessageBox.Show("Categoria Excluída com Sucesso!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvConsultarCategoria.DataSource = categoriaDAL.ConsultarTodos();
                }
                catch
                {
                    MessageBox.Show("Não foi possível Excluir esta Categoria!!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dgvConsultarCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
           
            //categoria.Categoria = txtFiltro.Text;
            
        }
    }
}

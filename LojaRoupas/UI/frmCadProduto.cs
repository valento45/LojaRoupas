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
    public partial class frmCadProduto : Form
    {
        BLL.Roupa roupa = new BLL.Roupa();
        DAL.RoupaDAL roupaDAL = new DAL.RoupaDAL();
        BLL.Categorias categoria = new BLL.Categorias();
        DAL.CategoriaDAL categoriaDAL = new DAL.CategoriaDAL();

        bool alterar = false;

        public frmCadProduto()
        {
            InitializeComponent();
        }
        public frmCadProduto(int codproduto)
        {
            InitializeComponent();

            roupa.Idroupa = codproduto;
            roupaDAL.RetornarDados(roupa);

            txtDescricao.Text = roupa.Descricao;
            txtQuantidade.Text = roupa.Quantidade.ToString();
            txtPrecoBruto.Text = roupa.Precobruto.ToString();
            txtPrecoVenda.Text = roupa.Precovenda.ToString();
            txtObservacoes.Text = roupa.Observacoes;
            alterar = true;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmCadProduto_Load(object sender, EventArgs e)
        {
            cmbCategoria.DataSource = categoriaDAL.ConsultarTodos();
            cmbCategoria.DisplayMember = "CATEGORIA";
            cmbCategoria.ValueMember = "IDCATEGORIA";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            roupa.Descricao = txtDescricao.Text.ToString();
            roupa.Idcategoria = Convert.ToInt16(cmbCategoria.SelectedValue.ToString());
            roupa.Quantidade = Convert.ToInt16(txtQuantidade.Text);
            roupa.Precobruto = Convert.ToDecimal(txtPrecoBruto.Text);
            roupa.Precovenda = Convert.ToDecimal(txtPrecoVenda.Text);
            roupa.Observacoes = txtObservacoes.Text.ToString();
            
            if(alterar == true)
            {
                roupaDAL.Atualizar(roupa);
                MessageBox.Show("Dados Alterados com Sucesso!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                roupaDAL.Cadastrar(roupa);
                MessageBox.Show("Produto Cadastrado com Sucesso!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtDescricao.Clear();
                cmbCategoria.Text = "";
                txtQuantidade.Clear();
                txtPrecoBruto.Clear();
                txtPrecoVenda.Clear();
                txtObservacoes.Clear();

            }
        }

        private void btnCadastrarCategoria_Click(object sender, EventArgs e)
        {
            UI.frmCadCategoria cadastrocategoria = new frmCadCategoria();
            cadastrocategoria.ShowDialog();

            cmbCategoria.DataSource = categoriaDAL.ConsultarTodos();
            cmbCategoria.DisplayMember = "CATEGORIA";
            cmbCategoria.ValueMember = "IDCATEGORIA";
        }
    }
}

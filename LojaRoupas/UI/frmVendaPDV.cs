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
    public partial class frmVendaPDV : Form
    {
        BLL.Cliente clienteBLL = new BLL.Cliente();
        DAL.ClienteDAL clienteDAL = new DAL.ClienteDAL();

        BLL.Roupa roupaBLL = new BLL.Roupa();
        DAL.RoupaDAL roupaDAL = new DAL.RoupaDAL();

        BLL.Venda venda = new BLL.Venda();
        DAL.vendaDAL vendaDAL = new DAL.vendaDAL();

        BLL.Iten iten = new BLL.Iten();
        DAL.ItenDAL itenDAL = new DAL.ItenDAL();

        Decimal total = 0;



        public frmVendaPDV()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelecionarCliente_Click(object sender, EventArgs e)
        {
            frmConsultarCliente cli = new frmConsultarCliente();
            cli.ShowDialog();

            if (cli.codcli != 0)
            {
                clienteBLL.Idcliente = cli.codcli;
                clienteBLL = clienteDAL.RetornarDados(clienteBLL);
                txtCliente.Text = clienteBLL.Nome;
            }
        }

        public void CalcularTotal()
        {

            total = 0;
            for (int i = 0; i < dgvItens.RowCount; i++)
            {
                total += Convert.ToDecimal(dgvItens[4, i].Value);
            }
            txtTotal.Text = total.ToString("c");
        }

        public bool VerificarQuantidadeDisponivel()
        {
            int qtd = 0;
            for (int i = 0; i < dgvItens.RowCount; i++)
            {
                if (roupaBLL.Idroupa.ToString() == dgvItens[0, i].Value.ToString())
                {
                    qtd += Convert.ToInt16(dgvItens[2, i].Value);
                }
            }
            qtd += Convert.ToInt16(txtQuantidade.Value);
            if (qtd > roupaBLL.Quantidade)
                return false;
            else
                return true;
        }


        private void btnSelecionarProduto_Click(object sender, EventArgs e)
        {

            frmConsultarProduto produto = new frmConsultarProduto();
            produto.ShowDialog();

            /*roupaBLL.Idroupa = produto.codproduto;
            roupaBLL = roupaDAL.RetornarDados(roupaBLL);
            txtProduto.Text = roupaBLL.Descricao;
            txtPreco.Text = roupaBLL.Precovenda.ToString();*/
            if (produto.codproduto != 0)
            {
                roupaBLL.Idroupa = produto.codproduto;
                roupaBLL = roupaDAL.RetornarDados(roupaBLL);

                txtProduto.Text = roupaBLL.Descricao;
                txtPreco.Text = roupaBLL.Precovenda.ToString();

                txtQuantidade.Select(0, txtQuantidade.Text.Length);//selecionando o texto para alteração
                txtQuantidade.Focus();//focando a caixa de quantidade
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (roupaBLL.Idroupa != 0)
            {

                if (VerificarQuantidadeDisponivel() == false)
                {
                    MessageBox.Show("QUANTIDADE INSUFICIENTE NO ESTOQUE!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal total = Convert.ToInt16(txtQuantidade.Value) * roupaBLL.Precovenda;

                dgvItens.Rows.Add(roupaBLL.Idroupa, roupaBLL.Descricao, txtQuantidade.Value, roupaBLL.Precovenda.ToString("n"), total.ToString("n"));

                //calcular total
                CalcularTotal();

                //limpar
                roupaBLL.Idroupa = 0;
                txtProduto.Clear();
                txtQuantidade.Value = 1;
                txtPreco.Clear();

            }
            else
            {
                MessageBox.Show("SELECIONE UM PRODUTO", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dgvItens.RowCount > 0)
            {
                dgvItens.Rows.Remove(dgvItens.CurrentRow);
                CalcularTotal();
            }
        }

        private void frmVendaPDV_Load(object sender, EventArgs e)
        {

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if(dgvItens.RowCount > 0 && clienteBLL.Idcliente != 0 && cmbForma.Text.Trim() != "")
            {
                //cadastrando itens
                venda.Idcliente = clienteBLL.Idcliente;
                venda.Precototal = total;
                venda.Pagamento = cmbForma.Text;
                venda.Datavenda = Convert.ToDateTime(txtData.Text);         
                iten.Idvenda = vendaDAL.Cadastrar(venda);


                for ( int i = 0; i < dgvItens.RowCount; i++)
                {
                    iten.Idroupa = Convert.ToInt16(dgvItens[0, i].Value);
                    iten.Quantpedido = Convert.ToInt16(dgvItens[2, i].Value);
                    iten.Precounitario = Convert.ToDecimal(dgvItens[3, i].Value);                  
                    itenDAL.Cadastrar(iten);

                    //baixar estoque
                    roupaBLL.Quantidade = iten.Quantpedido;
                    roupaBLL.Idroupa = iten.Idroupa;
                    roupaDAL.BaixarEstoque(roupaBLL);
                }
                MessageBox.Show("DADOS GRAVADOS COM SUCESSO!", "GRAVAR", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //LIMPANDO OS CAMPOS
                roupaBLL.Idroupa = 0;
                clienteBLL.Idcliente = 0;
                txtProduto.Clear();
                txtQuantidade.Value = 1;
                txtPreco.Clear();
                txtTotal.Clear();
                txtCliente.Clear();
                dgvItens.Rows.Clear();

            }
            else
            {
                MessageBox.Show("VERIFIQUE O PREENCHIMENTO DOS CAMPOS!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProduto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPreco_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQuantidade_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvItens_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


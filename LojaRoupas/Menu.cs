using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LojaRoupas
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void gggToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.frmCadCategoria cadastrocategoria = new UI.frmCadCategoria();
            cadastrocategoria.ShowDialog();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.frmCadUsuario usuario = new UI.frmCadUsuario();
            usuario.ShowDialog();
        }

        private void funcionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.frmCadFuncionario cadastrofuncionario = new UI.frmCadFuncionario();
            cadastrofuncionario.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Encerrar o sistema?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UI.frmCadCliente cadastrocliente = new UI.frmCadCliente();
            cadastrocliente.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.frmCadCliente cadastrocliente = new UI.frmCadCliente();
            cadastrocliente.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UI.frmConsultarCliente consultarcliente = new UI.frmConsultarCliente();
            consultarcliente.ShowDialog();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UI.frmConsultarCliente consultarcliente = new UI.frmConsultarCliente();
            consultarcliente.ShowDialog();
        }

        private void funcionáriosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UI.frmConsultarFuncionario consultarfuncionario = new UI.frmConsultarFuncionario();
            consultarfuncionario.ShowDialog();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.frmConsultarCategoria consultarcategoria = new UI.frmConsultarCategoria();
            consultarcategoria.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Deseja realmente Encerrrar o sistema?","Atenção!",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UI.frmCadProduto cadastroproduto = new UI.frmCadProduto();
            cadastroproduto.ShowDialog();
        }

        private void roupasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.frmCadProduto cadastroproduto = new UI.frmCadProduto();
            cadastroproduto.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UI.frmConsultarProduto consultarproduto = new UI.frmConsultarProduto();
            consultarproduto.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UI.frmEstoque estoque = new UI.frmEstoque();
            estoque.Show();
        }

        private void roupasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UI.frmConsultarProduto consultarproduto = new UI.frmConsultarProduto();
            consultarproduto.ShowDialog();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.frmEstoque estoque = new UI.frmEstoque();
            estoque.ShowDialog();
        }

        private void atualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.frmConsultarProduto consultarproduto = new UI.frmConsultarProduto();
            consultarproduto.ShowDialog();
        }

        private void btnVenda_Click(object sender, EventArgs e)
        {
            UI.frmVendaPDV vendapdv = new UI.frmVendaPDV();
            vendapdv.ShowDialog();
        }

        private void abrirFrenteCaixaPDVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.frmVendaPDV vendapdv = new UI.frmVendaPDV();
            vendapdv.ShowDialog();
        }

        private void vendasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UI.frmConsultarVendas consultarvendas = new UI.frmConsultarVendas();
            consultarvendas.ShowDialog();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class frmCadCategoria : Form
    {
        BLL.Categorias categoria = new BLL.Categorias();
        DAL.CategoriaDAL categoriaDAL = new DAL.CategoriaDAL();
        bool alterar = false;
        public frmCadCategoria()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            categoria.Categoria = txtCategoria.Text.ToString();
            if(alterar == true)
            {
                categoriaDAL.Atualizar(categoria);
            }
            else
            {
                categoriaDAL.Cadastrar(categoria);
                MessageBox.Show("Categoria Salva com Sucesso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCategoria.Clear();
            }


        }
    }
}

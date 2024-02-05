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
    public partial class frmConsultarVendas : Form
    {
        BLL.Venda venda = new BLL.Venda();
        DAL.vendaDAL vendaDAL = new DAL.vendaDAL();

        BLL.Iten iten = new BLL.Iten();
        DAL.ItenDAL itenDAL = new DAL.ItenDAL();


        public frmConsultarVendas()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConsultarVendas_Load(object sender, EventArgs e)
        {
            dgvConsultarVendas.DataSource = vendaDAL.ConsultarTodos();
        }

        private void dgvConsultarVendas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

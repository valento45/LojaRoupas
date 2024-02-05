using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupas.BLL
{
    class Venda
    {
        int idvenda;
        DateTime datavenda;
        int idcliente;
        Decimal precototal;
        string pagamento;

        public int Idvenda
        {
            get
            {
                return idvenda;
            }

            set
            {
                idvenda = value;
            }
        }

        public DateTime Datavenda
        {
            get
            {
                return datavenda;
            }

            set
            {
                datavenda = value;
            }
        }

        public int Idcliente
        {
            get
            {
                return idcliente;
            }

            set
            {
                idcliente = value;
            }
        }

        public decimal Precototal
        {
            get
            {
                return precototal;
            }

            set
            {
                precototal = value;
            }
        }

        public string Pagamento
        {
            get
            {
                return pagamento;
            }

            set
            {
                pagamento = value;
            }
        }
    }
}

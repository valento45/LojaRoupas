using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupas.BLL
{
    class Iten
    {
        int iditen;
        int idvenda;
        int idroupa;
        Decimal precounitario;
        int quantpedido;

        public int Iditen
        {
            get
            {
                return iditen;
            }

            set
            {
                iditen = value;
            }
        }

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

        public int Idroupa
        {
            get
            {
                return idroupa;
            }

            set
            {
                idroupa = value;
            }
        }

        public decimal Precounitario
        {
            get
            {
                return precounitario;
            }

            set
            {
                precounitario = value;
            }
        }

        public int Quantpedido
        {
            get
            {
                return quantpedido;
            }

            set
            {
                quantpedido = value;
            }
        }
    }
}

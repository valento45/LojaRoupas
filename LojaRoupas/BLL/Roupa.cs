using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupas.BLL
{
    class Roupa
    {
        int idroupa;
        string descricao;
        int idcategoria;
        int quantidade;
        Decimal precobruto;
        Decimal precovenda;
        string observacoes;

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

        public string Descricao
        {
            get
            {
                return descricao;
            }

            set
            {
                descricao = value;
            }
        }

        public int Idcategoria
        {
            get
            {
                return idcategoria;
            }

            set
            {
                idcategoria = value;
            }
        }

        public int Quantidade
        {
            get
            {
                return quantidade;
            }

            set
            {
                quantidade = value;
            }
        }

        public decimal Precobruto
        {
            get
            {
                return precobruto;
            }

            set
            {
                precobruto = value;
            }
        }

        public decimal Precovenda
        {
            get
            {
                return precovenda;
            }

            set
            {
                precovenda = value;
            }
        }

        public string Observacoes
        {
            get
            {
                return observacoes;
            }

            set
            {
                observacoes = value;
            }
        }
    }
}

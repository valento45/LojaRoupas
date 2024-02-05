using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupas.BLL
{
    class Caixa
    {
        int idcaixa;
        int idusuario;
        DateTime data;
        Decimal valor;

        public int Idcaixa
        {
            get
            {
                return idcaixa;
            }

            set
            {
                idcaixa = value;
            }
        }

        public int Idusuario
        {
            get
            {
                return idusuario;
            }

            set
            {
                idusuario = value;
            }
        }

        public DateTime Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
            }
        }

        public decimal Valor
        {
            get
            {
                return valor;
            }

            set
            {
                valor = value;
            }
        }
    }
}

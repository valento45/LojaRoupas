using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupas.BLL
{
    class Funcionario
    {
        int idfuncionario;
        string nome;
        string rg;
        string cpf;
        string telefone;
        string endereco;
        string cargo;
        Decimal salario;

        public int Idfuncionario
        {
            get
            {
                return idfuncionario;
            }

            set
            {
                idfuncionario = value;
            }
        }

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public string Rg
        {
            get
            {
                return rg;
            }

            set
            {
                rg = value;
            }
        }

        public string Cpf
        {
            get
            {
                return cpf;
            }

            set
            {
                cpf = value;
            }
        }

        public string Telefone
        {
            get
            {
                return telefone;
            }

            set
            {
                telefone = value;
            }
        }

        public string Endereco
        {
            get
            {
                return endereco;
            }

            set
            {
                endereco = value;
            }
        }

        public string Cargo
        {
            get
            {
                return cargo;
            }

            set
            {
                cargo = value;
            }
        }

        public decimal Salario
        {
            get
            {
                return salario;
            }

            set
            {
                salario = value;
            }
        }
    }
}

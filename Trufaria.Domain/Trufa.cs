using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trufaria.Infra;

namespace Trufaria.Domain
{
    public class Trufa : IObjectValidation
    {
        public int Id { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int Quantidade { get; set; }
        public string Tamanho { get; set; }
        public double Valor { get; set; }

        
        public virtual List<Sabor> Sabores { get; set; }

        public void Validate()
        {
            if (DateTime.Today < DataFabricacao)
                throw new Exception("Data Fabricação Inválida");
            if (string.IsNullOrEmpty(Tamanho))
                throw new Exception("Tamanho Inválido");
            if (double.IsNegativeInfinity(Valor))
            {
                    throw new Exception("Valor Inválidao");
            }
        }
    }
}

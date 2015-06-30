using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trufaria.Infra;

namespace Trufaria.Domain
{
    public class Sabor : IObjectValidation
    {
        public int Id { set; get; }

        public string NameSabor { get; set; }

        public int? TrufaId { set; get; }

        public virtual Trufa Trufa { set; get; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(NameSabor))
                throw new Exception("Nome Inválido");
        }
    }
}


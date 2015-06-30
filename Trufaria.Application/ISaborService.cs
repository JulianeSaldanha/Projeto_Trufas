using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trufaria.Domain;

namespace Trufaria.Application
{
    public interface ISaborService
    {
        Sabor Create(Sabor sabor);
        Sabor Retrieve(int id);
        Sabor Update(Sabor sabor);
        Sabor Delete(int id);
        List<Sabor> RetrieveAll();
    }
}

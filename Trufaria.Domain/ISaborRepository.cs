using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trufaria.Domain
{
    public interface ISaborRepository
    {
        Sabor Save(Sabor sabor);
        Sabor Get(int id);
        Sabor Update(Sabor sabor);
        Sabor Delete(int i);

        List<Sabor> GetAll();
    }

}
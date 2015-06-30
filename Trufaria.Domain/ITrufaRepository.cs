using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trufaria.Domain
{
    public interface ITrufaRepository
    {
        Trufa Save(Trufa trufa);
        Trufa Get(int id);
        Trufa Update(Trufa trufa);
        Trufa Delete(int id);
        List<Trufa> GetAll();
    }
}

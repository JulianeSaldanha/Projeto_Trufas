using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trufaria.Domain;


namespace Trufaria.Application
{
    public interface ITrufaService
    {
        Trufa Create(Trufa trufa);
        Trufa Retrieve(int id);
        Trufa Update(Trufa trufa);
        Trufa Delete(int id);
        List<Trufa> RetrieveAll();
    }
}

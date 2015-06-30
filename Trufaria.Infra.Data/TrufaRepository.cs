using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trufaria.Domain;

namespace Trufaria.Infra.Data
{
    public class TrufaRepository : ITrufaRepository
    {
        private TrufaContext context;

        public TrufaRepository()
        {
            context = new TrufaContext();
        }

        public Trufa Save(Trufa trufa)
        {
            var newTrufa = context.Trufas.Add(trufa);
            context.SaveChanges();
            return newTrufa;
        }


        public Trufa Get(int id)
        {
            var trufa = context.Trufas.Find(id);
            return trufa;
        }


        public Trufa Update(Trufa trufa)
        {
            DbEntityEntry entry = context.Entry(trufa);
            entry.State = EntityState.Modified;
            context.SaveChanges();
            return trufa;
        }


        public Trufa Delete(int id)
        {
            var trufa = context.Trufas.Find(id);
            DbEntityEntry entry = context.Entry(trufa);
            entry.State = EntityState.Deleted;
            context.SaveChanges();
            return trufa;
        }


        public List<Trufa> GetAll()
        {
            return context.Trufas.ToList();
        }

    }
}

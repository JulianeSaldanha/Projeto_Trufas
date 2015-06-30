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
    public class SaborRepository : ISaborRepository
    {
        private TrufaContext context;

        public SaborRepository()
        {
            context = new TrufaContext();
        }

        public Sabor Save(Sabor sabor)
        {
            var newSabor = context.Sabores.Add(sabor);
            context.SaveChanges();
            return newSabor;
        }


        public Sabor Get(int id)
        {
            var sabor = context.Sabores.Find(id);
            return sabor;
        }


        public Sabor Update(Sabor sabor)
        {
            DbEntityEntry entry = context.Entry(sabor);
            entry.State = EntityState.Modified;
            context.SaveChanges();
            return sabor;
        }


        public Sabor Delete(int id)
        {
            var sabor = context.Sabores.Find(id);
            DbEntityEntry entry = context.Entry(sabor);
            entry.State = EntityState.Deleted;
            context.SaveChanges();
            return sabor;
        }

        public List<Sabor> GetAll()
        {
            return context.Sabores.ToList();
        }

    }
}


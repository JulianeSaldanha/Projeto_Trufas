using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trufaria.Domain;
using Trufaria.Infra;

namespace Trufaria.Application
{
   public class SaborService : ISaborService
    {
        private ISaborRepository _saborRepository;

        public SaborService(ISaborRepository saborRepository)
        {
            _saborRepository = saborRepository;
        }

        public Sabor Create(Sabor sabor)
        {
            Validator.Validate(sabor);

            var savedSabor = _saborRepository.Save(sabor);

            return savedSabor;
        }


        public Sabor Retrieve(int id)
        {
            return _saborRepository.Get(id);
        }


        public Sabor Update(Sabor sabor)
        {
            Validator.Validate(sabor);

            var updatedSabor = _saborRepository.Update(sabor);

            return updatedSabor;
        }


        public Sabor Delete(int id)
        {
            return _saborRepository.Delete(id);
        }


        public List<Sabor> RetrieveAll()
        {
            return _saborRepository.GetAll();
        }

    }
}

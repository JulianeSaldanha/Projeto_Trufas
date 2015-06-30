using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trufaria.Domain;
using Trufaria.Infra;

namespace Trufaria.Application
{
    public class TrufaService : ITrufaService
    {
        private ITrufaRepository _trufaRepository;

        public TrufaService(ITrufaRepository trufaRepository)
        {
            _trufaRepository = trufaRepository;
        }

        public Trufa Create(Trufa trufa)
        {
            Validator.Validate(trufa);

            var savedTrufa = _trufaRepository.Save(trufa);

            return savedTrufa;
        }


        public Trufa Retrieve(int id)
        {
            return _trufaRepository.Get(id);
        }


        public Trufa Update(Trufa trufa)
        {
            Validator.Validate(trufa);

            var updatedTrufa = _trufaRepository.Update(trufa);

            return updatedTrufa;
        }


        public Trufa Delete(int id)
        {
            return _trufaRepository.Delete(id);
        }


        public List<Trufa> RetrieveAll()
        {
            return _trufaRepository.GetAll();
        }
    }
}
using BA.Domain.Domain;
using BA.Repository.Interface;
using BA.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.Service.Implementation
{
    public class ApartmentService : IApartmentService
    {
        private readonly IRepository<Apartment> _repository;

        public ApartmentService (IRepository<Apartment> repository)
        {
            _repository = repository;
        }
        public Apartment CreateNewApartment(Apartment apartment)
        {
            _repository.Insert(apartment);
            return apartment;
        }

        public Apartment DeleteApartment(Guid id)
        {
            var apartment = _repository.Get(id);
            _repository.Delete(apartment);
            return apartment;
        }

        public Apartment GetApartmentById(Guid? id)
        {
            return _repository.Get(id);
        }

        public List<Apartment> GetApartments()
        {
            return _repository.GetAll().ToList();
        }

        public Apartment UpdateApartment(Apartment apartment)
        {
            _repository.Update(apartment);
            return apartment;
        }
    }
}

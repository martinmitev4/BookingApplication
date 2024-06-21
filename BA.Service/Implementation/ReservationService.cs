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
    public class ReservationService : IReservationsServices 
    {
            private readonly IRepository<Reservation>_repository;

            public ReservationService(IRepository<Reservation> repository)
            {
                _repository = repository;
            }
            public Reservation CreateNewReservation(Reservation apartment)
            {
                _repository.Insert(apartment);
                return apartment;
            }

            public Reservation DeleteReservation(Guid id)
            {
                var apartment = _repository.Get(id);
                _repository.Delete(apartment);
                return apartment;
            }

            public Reservation GetReservationById(Guid? id)
            {
                return _repository.Get(id);
            }

            public List<Reservation> GetReservations()
            {
                return _repository.GetAll().ToList();
            }

            public Reservation UpdateReservation(Reservation apartment)
            {
                _repository.Update(apartment);
                return apartment;
            }
    }

}

using BA.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.Service.Interface
{
    public interface IReservationsServices
    {
        public List<Reservation> GetReservations();
        public Reservation GetReservationById(Guid? id);
        public Reservation CreateNewReservation(Reservation reservation);
        public Reservation UpdateReservation(Reservation reservation);
        public Reservation DeleteReservation(Guid id);
    }
}

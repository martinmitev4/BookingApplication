using BA.Domain.Domain;
using BA.Domain.DTO;
using BA.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.Service.Implementation
{
    public class BookingListService : IBookingListService
    {
        public bool AddToListConfirmed(BookReservation model, string userId)
        {
            throw new NotImplementedException();
        }

        public bool deleteApartmentFromList(string userId, Guid reservationId)
        {
            throw new NotImplementedException();
        }

        public BookingListDTO getBookingLisInfo(string userId)
        {
            throw new NotImplementedException();
        }

        public bool order(string userId)
        {
            throw new NotImplementedException();
        }
    }
}

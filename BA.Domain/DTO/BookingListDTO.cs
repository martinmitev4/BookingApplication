using BA.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.Domain.DTO
{
    public class BookingListDTO
    {
        public List<BookReservation> AllReservations { get; set; }
        public int TotalPrice { get; set; }
    }
}

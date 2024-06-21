using BA.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.Domain.Domain
{
    public class BookingList : BaseEntity
    {
        public string OwnerId { get; set; }
        public BookingApplicationUser Owner { get; set; }
        public ICollection<BookReservation>? Reservations { get; set; }
    }
}

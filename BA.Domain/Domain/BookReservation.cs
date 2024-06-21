using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.Domain.Domain
{
    public class BookReservation : BaseEntity
    {
        public Guid ReservationId { get; set; }
        public Reservation? Reservation { get; set; }
        public Guid BookingListId { get; set; }
        public BookingList? BookingList { get; set; }
        public int Num_Of_Nights { get; set; }
    }
}

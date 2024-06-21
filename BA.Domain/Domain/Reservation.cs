using BA.Domain.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BA.Domain.Domain
{
    public class Reservation : BaseEntity
    {
        [Required]
        public DateTime Check_in_date { get; set; }
        [ForeignKey("Apartments")]
        public Guid ApartmentId { get; set; }
        public Apartment? Apartment { get; set; }
        public virtual BookingApplicationUser? User { get; set; }
        public virtual ICollection<BookReservation>? BookReservations { get; set; }
    }
}

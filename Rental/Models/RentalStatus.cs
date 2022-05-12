using System;

namespace Rental.Models
{
    public class RentalStatus
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public bool Rented { get; set; }
        public bool Reserved { get; set; }
        public DateTime ReservedTime { get; set; }
    }
}

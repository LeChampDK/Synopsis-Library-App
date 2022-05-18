using System;
using System.ComponentModel.DataAnnotations;

namespace Rental.Models
{
    public class RentalStatus
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public bool Rented { get; set; }
        public bool Reserve { get; set; }
        public DateTime? ReservedTime { get; set; }
    }
}

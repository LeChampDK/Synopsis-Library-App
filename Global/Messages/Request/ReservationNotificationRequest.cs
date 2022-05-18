using Global.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Messages.Request
{
    public class ReservationNotificationRequest
    {
        public BookDetailsDTO BookDetails { get; set; }
        public int UserId { get; set; }
    }
}

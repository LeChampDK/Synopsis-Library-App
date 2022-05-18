using Global.Messages.Request;
using Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Messages.Response
{
    public class BookServiceResponse : BaseMessage
    {
        public BookServiceResponse() : base() { }
        public BookServiceResponse(BookServiceRequest arg) : base(arg) { }
        public BookQuantity BookQuantity { get; set; }
    }
}

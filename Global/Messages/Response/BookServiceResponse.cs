using Global.Messages.Request;
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
        public BookServiceResponse(BookServiceReceive arg) : base(arg) { }
        public int BookId { get; set; }
        public int MaxQuantity { get; set; }
    }
}

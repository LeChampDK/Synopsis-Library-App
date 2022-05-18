using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Messages.Request
{
    public class BookServiceReceive : BaseMessage
    {
        public int BookId { get; set; }
    }
}

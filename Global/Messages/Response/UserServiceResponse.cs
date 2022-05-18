using Global.Messages.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Messages.Response
{
    public class UserServiceResponse : BaseMessage
    {
        public UserServiceResponse() : base() { }
        public UserServiceResponse(UserServiceReceive arg) : base(arg) { }
        public int UserId { get; set; }
        public bool UserExist { get; set; }
    }
}

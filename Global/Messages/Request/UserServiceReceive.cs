﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Messages.Request
{
    public class UserServiceReceive : BaseMessage
    {
        public int UserId { get; set; }
    }
}
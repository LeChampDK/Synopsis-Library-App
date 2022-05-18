using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Messages
{
    public abstract class BaseMessage
    {
        public BaseMessage()
        {
            this.Guid = Guid.NewGuid();
        }

        public BaseMessage(Guid guid)
        {
            this.Guid = guid;
        }

        public BaseMessage(BaseMessage previous)
        {
            if (previous == null)
            {
                this.Guid = Guid.NewGuid();
            }
            else
            {
                this.Guid = previous.Guid;
            }
        }

        public Guid Guid { get; internal set; }

        private string _error = null;
        public string Error
        {
            get
            {
                if (_error != null)
                    return _error;

                if (ErrorException != null)
                    return ErrorException.Message;

                return null;
            }

            set
            {
                _error = value;
            }
        }

        public Exception ErrorException { get; set; } = null;

        public bool IsSuccessfull { get { if (this.Error == null) return true; else return false; } }

    }
}

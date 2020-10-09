using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBroker
{
    public interface IMessage
    {
        public object Data { get; set; }
    }
}

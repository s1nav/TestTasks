using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBroker
{
    public class Message : IMessage
    {
        public object Data { get; set; }
    }
}

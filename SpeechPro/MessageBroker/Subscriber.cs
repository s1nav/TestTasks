using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBroker
{
    public class Subscriber : ISubscriber
    {
        public object Data { get; set; }


        public void Invoke(IMessage message)
        {
            Data = message.Data;
        }
    }
}

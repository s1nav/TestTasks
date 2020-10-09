using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBroker
{
    public interface IMessageBroker
    {
        public void Post(IMessage message);

        public void Subscribe(ISubscriber subscriber);
        
        public void Unsubscribe(ISubscriber subscriber);
    }
}

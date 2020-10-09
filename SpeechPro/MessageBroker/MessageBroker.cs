using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBroker
{
    public class MessageBroker : IMessageBroker
    {
        private List<ISubscriber> subscribers;


        public List<ISubscriber> Subscribers { get => subscribers; }


        public MessageBroker()
        {
            subscribers = new List<ISubscriber>();
        }


        public void Post(IMessage message)
        {
            foreach (var s in subscribers)
            {
                s?.Invoke(message);
            }        
        }

        public void Subscribe(ISubscriber subscriber)
        {
            subscribers.Add(subscriber);
        }

        public void Unsubscribe(ISubscriber subscriber)
        {
            subscribers.Remove(subscriber);
        }
    }
}

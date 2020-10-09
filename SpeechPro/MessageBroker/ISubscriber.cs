using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBroker
{
    public interface ISubscriber
    {
        public void Invoke(IMessage message);
    }
}

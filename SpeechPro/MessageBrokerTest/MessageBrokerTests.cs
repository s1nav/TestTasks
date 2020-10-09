using MessageBroker;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBrokerTest
{
    public class MessageBrokerTests
    {
        [Test]
        public void Subscribe_Exist()
        {
            var mb = new MessageBroker.MessageBroker();
            var subscriber = new Subscriber();

            mb.Subscribe(subscriber);

            CollectionAssert.Contains(mb.Subscribers, subscriber);
        }

        [Test]
        public void Unsubscribe_NotExist()
        {
            var mb = new MessageBroker.MessageBroker();
            var subscriber = new Subscriber();

            mb.Subscribe(subscriber);
            mb.Unsubscribe(subscriber);

            CollectionAssert.DoesNotContain(mb.Subscribers, subscriber);
        }

        [Test]
        public void Post_PostMessage_InvokeSubscriber()
        {
            var mb = new MessageBroker.MessageBroker();
            var subscriber = new Subscriber();
            var message = new Message { Data = "data" };

            mb.Subscribe(subscriber);
            mb.Post(message);

            Assert.AreEqual(subscriber.Data, message.Data);
        }
    }
}

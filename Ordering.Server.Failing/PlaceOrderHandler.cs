using System;
using NServiceBus;
using Ordering.Messages;

namespace Ordering.Server.Failing
{
    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        public IBus Bus { get; set; }

        public void Handle(PlaceOrder message)
        {
            Console.WriteLine(@"Order for Product:{0} placed with id: {1}", message.Product, message.Id);

            throw new Exception("Uh oh - something went wrong....");
        }
    }
}

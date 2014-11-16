﻿using System;
using NServiceBus;
using Ordering.Messages;

namespace Ordering.Client
{
    public class SendOrder : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start()
        {
            Console.WriteLine("Press 'Enter' to send a message.  To exit, Ctrl + C");

            while (Console.ReadLine() != null)
            {
                var id = Guid.NewGuid();

                Bus.Send("Ordering.Server", new PlaceOrder() { Product = "New shoes", Id = id, EncryptedUser = "Todd Meinershagen" });
                
                Console.WriteLine("==========================================================================");
                Console.WriteLine("Send a new PlaceOrder message with id: {0}", id.ToString("N"));
            }
        }
        public void Stop()
        {
        }
    }
}

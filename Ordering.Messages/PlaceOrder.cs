using System;
using NServiceBus;

namespace Ordering.Messages
{
    public class PlaceOrder : ICommand
    {
        public Guid Id { get; set; }

        public string Product { get; set; }
        public string EncryptedUser { get; set; }
    }
}

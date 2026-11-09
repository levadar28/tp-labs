using System;

namespace Lab5
{
    public class ParcelLockerDelivery : IDelivery
    {
        public void Deliver(string address)
        {
            Console.WriteLine(
                $"Посылка будет доставлена в постамат: {address}.");
        }
    }
}
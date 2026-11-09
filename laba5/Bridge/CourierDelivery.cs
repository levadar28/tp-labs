using System;

namespace Lab5
{
    public class CourierDelivery : IDelivery
    {
        public void Deliver(string address)
        {
            Console.WriteLine(
                $"Курьер доставит посылку по адресу: {address}.");
        }
    }
}
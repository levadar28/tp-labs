using System;

namespace Lab5
{
    public class RegularParcel : Parcel
    {
        public RegularParcel(IDelivery delivery)
            : base(delivery)
        {
        }

        public override void Send(string address)
        {
            Console.WriteLine("Упаковываем обычную посылку.");

            delivery.Deliver(address);
        }
    }
}
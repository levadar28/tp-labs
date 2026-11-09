using System;

namespace Lab5
{
    public class FragileParcel : Parcel
    {
        public FragileParcel(IDelivery delivery)
            : base(delivery)
        {
        }

        public override void Send(string address)
        {
            Console.WriteLine(
                "Добавляем защитную упаковку для хрупкой посылки.");

            delivery.Deliver(address);
        }
    }
}
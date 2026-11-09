namespace Lab5
{
    public abstract class Parcel
    {
        protected readonly IDelivery delivery;

        protected Parcel(IDelivery delivery)
        {
            this.delivery = delivery;
        }

        public abstract void Send(string address);
    }
}
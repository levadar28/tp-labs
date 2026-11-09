using Lab5;
using System;

namespace lab5
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Proxy: музыкальный сервис");

            IMusicService musicService = new MusicService();

            IMusicService freeAccount =
                new MusicServiceProxy(musicService, false);

            IMusicService premiumAccount =
                new MusicServiceProxy(musicService, true);

            Console.WriteLine("Аккаунт без подписки:");
            freeAccount.DownloadSong("Любимая песня");

            Console.WriteLine();

            Console.WriteLine("Аккаунт с подпиской:");
            premiumAccount.DownloadSong("Любимая песня");

            Console.WriteLine();
            Console.WriteLine("Adapter: данные ветклиники");

            OldClinicSystem oldSystem = new OldClinicSystem(22);

            IAnimalWeight animalWeight =
                new AnimalWeightAdapter(oldSystem);

            Console.WriteLine($"Вес в старой системе: {oldSystem.ReadPounds()} фунтов");

            Console.WriteLine($"Вес в нашей программе: {animalWeight.GetWeightKg():F2} кг");

            Console.WriteLine();

            Console.WriteLine("Bridge: доставка посылок");

            IDelivery courier = new CourierDelivery();
            IDelivery locker = new ParcelLockerDelivery();

            Parcel regularCourier = new RegularParcel(courier);
            Parcel regularLocker = new RegularParcel(locker);

            Parcel fragileCourier = new FragileParcel(courier);
            Parcel fragileLocker = new FragileParcel(locker);

            regularCourier.Send("ул. Лесная, дом 10");
            Console.WriteLine();

            regularLocker.Send("ТЦ «Весна», постамат №5");
            Console.WriteLine();

            fragileCourier.Send("ул. Садовая, дом 7");
            Console.WriteLine();

            fragileLocker.Send("ТЦ «Мир», постамат №2");
        }
    }
}
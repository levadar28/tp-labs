using System;
using System.Text;

namespace lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            DemonstrateStrategy();
            DemonstrateChain();
            DemonstrateIterator();
        }

        private static void DemonstrateStrategy()
        {
            Console.WriteLine(
                "Стратегия: Полив теплицы");

            Greenhouse greenhouse = new Greenhouse(
                12,
                new EconomyWateringStrategy());

            Console.WriteLine(
                $"Количество растений: {greenhouse.PlantCount}");

            Console.WriteLine(
                $"Экономный полив: {greenhouse.CalculateWater()} мл.");

            greenhouse.SetStrategy(
                new NormalWateringStrategy());

            Console.WriteLine(
                $"Обычный полив: {greenhouse.CalculateWater()} мл.");

            greenhouse.SetStrategy(
                new TransplantWateringStrategy());

            Console.WriteLine(
                $"После пересадки: {greenhouse.CalculateWater()} мл.");

            Console.WriteLine();
        }

        private static void DemonstrateChain()
        {
            Console.WriteLine(
                "Цепочка обязанностей: помощь животным");

            CatFosterHome cats = new CatFosterHome(1);
            DogFosterHome dogs = new DogFosterHome(1);
            UniversalShelter shelter = new UniversalShelter(2);

            // Формирую цепочку обработчиков
            cats.SetNext(dogs);
            dogs.SetNext(shelter);

            AnimalRequest[] requests =
            {
                new AnimalRequest("Мурка", AnimalType.Cat),
                new AnimalRequest("Барсик", AnimalType.Cat),
                new AnimalRequest("Бобик", AnimalType.Dog),
                new AnimalRequest("Ушастик", AnimalType.Rabbit),
                new AnimalRequest("Рекс", AnimalType.Dog)
            };

            foreach (AnimalRequest request in requests)
            {
                Console.WriteLine();
                Console.WriteLine(
                    $"Новая заявка: {request.Name}");

                // Все заявки направляю первому обработчику
                bool placed = cats.Handle(request);

                Console.WriteLine(
                    "Результат: " +
                    (placed
                        ? "место найдено."
                        : "нужно искать другие приюты."));
            }

            Console.WriteLine();
            Console.WriteLine("Свободные места:");

            Console.WriteLine(
                $"Передержка для кошек: {cats.FreePlaces}");

            Console.WriteLine(
                $"Передержка для собак: {dogs.FreePlaces}");

            Console.WriteLine(
                $"Универсальный приют: {shelter.FreePlaces}");

            Console.WriteLine();
        }

        private static void DemonstrateIterator()
        {
            Console.WriteLine(
                "Итератор: плейлист для тренировки");

            Playlist playlist = new Playlist();

            playlist.Add(new Track("Разминка", 125));
            playlist.Add(new Track("Ускорение", 180));
            playlist.Add(new Track("Финиш", 145));

            Console.WriteLine();
            Console.WriteLine("Прямой порядок:");

            IIterator<Track> forward = playlist.CreateForwardIterator();

            PrintTracks(forward);

            Console.WriteLine();
            Console.WriteLine("Обратный порядок:");

            IIterator<Track> reverse = playlist.CreateReverseIterator();

            PrintTracks(reverse);

            Console.WriteLine();
            Console.WriteLine("Независимость двух итераторов:");

            IIterator<Track> first = playlist.CreateForwardIterator();

            IIterator<Track> second = playlist.CreateForwardIterator();

            Console.WriteLine($"Первый итератор, первый шаг: {first.Next()}");

            Console.WriteLine($"Первый итератор, второй шаг: {first.Next()}");

            Console.WriteLine($"Второй итератор, первый шаг: {second.Next()}");

            Console.WriteLine();
            Console.WriteLine("Проверка завершённого обхода:");

            Console.WriteLine($"Есть следующий трек: {forward.HasNext()}");

            try
            {
                forward.Next();
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Проверка пустого плейлиста:");

            Playlist emptyPlaylist = new Playlist();

            Console.WriteLine("Прямой обход: " + emptyPlaylist.CreateForwardIterator().HasNext());

            Console.WriteLine("Обратный обход: " + emptyPlaylist.CreateReverseIterator().HasNext());
        }

        // Общий метод вывода для обоих направлений обхода
        private static void PrintTracks(IIterator<Track> iterator)
        {
            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Next());
            }
        }
    }
}
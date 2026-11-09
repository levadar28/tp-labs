using System;

namespace lab4
{
    public enum AnimalType
    {
        Cat,
        Dog,
        Rabbit
    }

    // Запрос на размещение одного животного
    public class AnimalRequest
    {
        public string Name { get; }

        public AnimalType Type { get; }

        public AnimalRequest(string name, AnimalType type)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Нужно указать имя животного.", nameof(name));
            }

            Name = name;
            Type = type;
        }
    }

    // Общий интерфейс обработчиков
    public interface IAnimalHandler
    {
        void SetNext(IAnimalHandler next);

        bool Handle(AnimalRequest request);
    }

    // Общая логика обработки и передачи запроса
    public abstract class AnimalHandler : IAnimalHandler
    {
        private IAnimalHandler? next;

        public string Name { get; }

        public int FreePlaces { get; private set; }

        protected AnimalHandler(string name, int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "Вместимость не может быть отрицательной.");
            }
            Name = name;
            FreePlaces = capacity;
        }

        public void SetNext(IAnimalHandler next)
        {
            this.next = next
                ?? throw new ArgumentNullException(nameof(next));
        }

        // Конкретный обработчик определяет,
        // какие виды животных он принимает
        protected abstract bool Accepts(AnimalType type);

        public bool Handle(AnimalRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            if (Accepts(request.Type) && FreePlaces > 0)
            {
                FreePlaces--;

                Console.WriteLine($"{Name}: животное «{request.Name}» принято.");

                Console.WriteLine($"Осталось свободных мест: {FreePlaces}.");
                return true;
            }

            if (!Accepts(request.Type))
            {
                Console.WriteLine($"{Name}: этот вид животных не принимаем.");
            }
            else
            {
                Console.WriteLine($"{Name}: свободных мест нет.");
            }

            if (next != null)
            {
                Console.WriteLine("Передаём заявку дальше.");

                return next.Handle(request);
            }

            Console.WriteLine($"Для животного «{request.Name}» " + "не удалось найти место.");

            return false;
        }
    }

    // Принимает только кошек
    public class CatFosterHome : AnimalHandler
    {
        public CatFosterHome(int capacity) : base("Передержка для кошек", capacity)
        {
        }

        protected override bool Accepts(AnimalType type)
        {
            return type == AnimalType.Cat;
        }
    }

    // Принимает только собак
    public class DogFosterHome : AnimalHandler
    {
        public DogFosterHome(int capacity) : base("Передержка для собак", capacity)
        {
        }

        protected override bool Accepts(AnimalType type)
        {
            return type == AnimalType.Dog;
        }
    }

    // Принимает все виды животных,
    // предусмотренные программой
    public class UniversalShelter : AnimalHandler
    {
        public UniversalShelter(int capacity) : base("Универсальный приют", capacity)
        {
        }

        protected override bool Accepts(AnimalType type)
        {
            return type == AnimalType.Cat
                || type == AnimalType.Dog
                || type == AnimalType.Rabbit;
        }
    }
}

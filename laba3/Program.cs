using System;

namespace lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Singleton first = Singleton.GetInstance();
            Singleton second = Singleton.GetInstance();

            first.SomeMethod();
            second.SomeMethod();

            Console.WriteLine("Это один и тот же объект: " + ReferenceEquals(first, second));

            Console.WriteLine();
            Console.WriteLine("FactoryMethod");

            LoggerFactory consoleFactory = new ConsoleLoggerFactory();
            consoleFactory.LogMessage("Программа запущена!");

            LoggerFactory fileFactory = new FileLoggerFactory();
            fileFactory.LogMessage("Проверка файлового логгера.");

            Console.WriteLine("Путь к файлу: " + System.IO.Path.GetFullPath("log.txt"));

            Console.WriteLine();
            Console.WriteLine("Abstract Factory");
            Console.WriteLine("Семейство Windows: ");
            Application windowsapp = new Application(new WindowsFactory());
            windowsapp.Paint();

            Console.WriteLine();

            Console.WriteLine("Семейство Mac: ");
            Application macapp = new Application(new MacFactory());
            macapp.Paint();

            Console.WriteLine();
            Console.WriteLine("Builder: ");
            IPizzaBuilder pizzaBuilder = new HawaiianPizzaBuilder();
            PizzaDirector director = new PizzaDirector(pizzaBuilder);

            director.ConstructPizza();
            Pizza pizza = pizzaBuilder.GetResult();
            Console.WriteLine(pizza);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    // Продукт - пицца
    public class Pizza
    {
        public string Dough { get; set; } = "";
        public string Sauce { get; set; } = "";
        public string Topping { get; set; } = "";
        public override string ToString()
        {
            return $"Пицца: тесто - {Dough}, " +
                $"соус - {Sauce}, начинка - {Topping}.";
        }
    }

    // Интерфейс строителя
    public interface IPizzaBuilder
    {
        void BuildDough();
        void BuildSauce();
        void BuildTopping();
        Pizza GetResult();
    }

    // Конкретный строитель
    public class HawaiianPizzaBuilder : IPizzaBuilder
    {
        private readonly Pizza pizza = new Pizza();

        public void BuildDough()
        {
            pizza.Dough = "тонкое";
        }
        public void BuildSauce()
        {
            pizza.Sauce = "томатный";
        }
        public void BuildTopping()
        {
            pizza.Topping = "ветчина и ананас";
        }
        public Pizza GetResult()
        {
            return pizza;
        }
    }
    // Директор, управляющий порядком сборки
    public class PizzaDirector
    {
        private readonly IPizzaBuilder builder;

        public PizzaDirector(IPizzaBuilder builder)
        {
            this.builder = builder;
        }
        public void ConstructPizza()
        {
            builder.BuildDough();
            builder.BuildSauce();
            builder.BuildTopping();
        }
    }
}


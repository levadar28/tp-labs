using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public sealed class Singleton
    {
        private static Singleton instance = new Singleton();

        private Singleton()
        {
            Console.WriteLine("Экземпляр Singleton создан.");
        }
        public static Singleton GetInstance()
        {
            return instance;
        }
        public void SomeMethod()
        {
            Console.WriteLine("Вызван метод единственного экзмепляра.");
        }
    }
}

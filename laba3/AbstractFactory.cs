using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public interface IButton
    {
        void Paint();
    }
    public interface ICheckbox
    {
        void Paint();
    }
    public class WindowsButton : IButton
    {
        public void Paint()
        {
            Console.WriteLine("Кнопка Windows.");
        }
    }
    public class WindowsCheckbox : ICheckbox
    {
        public void Paint()
        {
            Console.WriteLine("Флажок Windows.");
        }
    }
    public class MacButton : IButton
    {
        public void Paint()
        {
            Console.WriteLine("Кнопка Mac.");
        }
    }
    public class MacCheckbox : ICheckbox
    {
        public void Paint()
        {
            Console.WriteLine("Флажок Mac.");
        }
    }
    public interface IGuiFactory
    {
        IButton CreateButton();
        ICheckbox CreateCheckbox();
    }
    public class WindowsFactory : IGuiFactory
    {
        public IButton CreateButton()
        {
            return new WindowsButton();
        }
        public ICheckbox CreateCheckbox()
        { 
            return new WindowsCheckbox();
        }

    }

    public class MacFactory : IGuiFactory
    {
        public IButton CreateButton()
        {
            return new MacButton();
        }
        public ICheckbox CreateCheckbox()
        {
            return new MacCheckbox();
        }
    }

    public class Application
    {
        private readonly IButton button;
        private readonly ICheckbox checkbox;

        public Application(IGuiFactory factory)
        {
            button = factory.CreateButton();
            checkbox = factory.CreateCheckbox();
        }
        public void Paint()
        {
            button.Paint();
            checkbox.Paint();
        }
    }
}

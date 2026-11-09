using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace laba_2
{
    internal class GameObject
    {
        private int id;
        private string name;
        private int x;
        private int y;

        public GameObject(int id, string name, int x, int y)
        {
            this.id = id;
            this.name = name;
            this.x = x;
            this.y = y;
        }

        public int GetId() => id;
        public string GetName() => name;
        public int GetX() => x;
        public int GetY() => y;

        protected void SetPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

    }
}

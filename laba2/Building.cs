using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_2
{
    internal class Building : GameObject
    {
        private bool isBuilt;
        public Building(int id, string name, int x, int y, bool isBuilt) : base(id, name, x, y)
        {
            this.isBuilt = isBuilt;
        }
        public bool IsBuilt()
        {
            return isBuilt;
        }
    }
}

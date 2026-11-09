using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_2
{
    internal class MobileHome: Building, Moveable
    {
        public MobileHome(int  id, string name, int x, int y, bool IsBuilt) : base(id, name, x, y, IsBuilt)
        {
        }
        public void Move(int x, int y)
        {
            if (IsBuilt())
            {
                SetPosition(x, y);
            }
        }
    }
}

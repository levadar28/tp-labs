using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_2
{
    internal class Unit : GameObject
    {
        private float hp;

        public Unit(int id, string name, int x, int y, float hp) : base(id, name, x, y)
        {
            this.hp = hp;
        }
        public bool IsAlive() => hp > 0;
        public float GetHp() => hp;
        public void ReceiveDamage(float damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            hp = Math.Max(0, hp - damage);

        }
    }
}

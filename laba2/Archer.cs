namespace laba_2
{
    internal class Archer : Unit, Attacker, Moveable 
    {
        private float attackDamage;
        public Archer(int id, string name, int x, int y, float hp, float attackDamage) : base(id, name, x, y, hp)
        {
            this.attackDamage = attackDamage;
        }
        public void Attack(Unit unit)
        {
            unit.ReceiveDamage(attackDamage);
        }
        public void Move(int x, int y)
        {
            SetPosition(x, y);
        }
    }
}

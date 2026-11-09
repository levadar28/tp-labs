using laba_2;

Console.WriteLine("Лабораторная работа 2");
var obj = new laba_2.GameObject(1, "Объект", 3, 5);
Console.WriteLine($"{obj.GetName()}: id = {obj.GetId()}, x = {obj.GetX()}, y = {obj.GetY()}");

var unit = new laba_2.Unit(2, "Воин", 10, 20, 100);
Console.WriteLine($"Здоровье до урона: {unit.GetHp()}");
unit.ReceiveDamage(35);
Console.WriteLine($"Здоровье после урона: {unit.GetHp()}");
Console.WriteLine($"Юнит жив: {unit.IsAlive()}");

var archer = new laba_2.Archer(3, "Лучник", 0, 0, 80, 25);
var target = new laba_2.Unit(4, "Противник", 5, 5, 100);
Console.WriteLine($"Здоровье противника до атаки: {target.GetHp()}");
archer.Attack(target);
Console.WriteLine($"Здоровье противника после атаки: {target.GetHp()}");
archer.Move(7, 9);
Console.WriteLine($"Новая позиция лучника: x = {archer.GetX()}, y = {archer.GetY()}");

var fortTarget = new laba_2.Unit(6, "Цель крепости", 10, 10, 100);

laba_2.Attacker fort = new laba_2.Fort(7, "Крепость", 2, 2, true, 40);

fort.Attack(fortTarget);
Console.WriteLine($"Здоровье после атаки крепости: {fortTarget.GetHp()}");

var mobileHome = new laba_2.MobileHome(8, "Дом на колёсах", 1, 1, true);

laba_2.Moveable moveableObject = mobileHome;

moveableObject.Move(12, 15);
Console.WriteLine($"Новая позиция дома: x = {mobileHome.GetX()}, y = {mobileHome.GetY()}");
Console.WriteLine($"Дом построен: {mobileHome.IsBuilt()}");
Console.WriteLine();
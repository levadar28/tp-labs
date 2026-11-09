using System;

namespace lab4
{
    // Общий интерфейс алгоритмов расчёта полива.
    public interface IWateringStrategy
    {
        int CalculateWater(int plantCount);
    }

    // Экономный полив: 100 мл на растение
    public class EconomyWateringStrategy : IWateringStrategy
    {
        public int CalculateWater(int plantCount)
        {
            return plantCount * 100;
        }
    }

    // Обычный полив: 250 мл на растение
    public class NormalWateringStrategy : IWateringStrategy
    {
        public int CalculateWater(int plantCount)
        {
            return plantCount * 250;
        }
    }

    // Полив после пересадки: 400 мл на растение
    public class TransplantWateringStrategy : IWateringStrategy
    {
        public int CalculateWater(int plantCount)
        {
            return plantCount * 400;
        }
    }

    // Контекст: использует выбранную стратегию (способ  полива)
    public class Greenhouse
    {
        private IWateringStrategy strategy;

        public int PlantCount { get; }

        public Greenhouse(int plantCount, IWateringStrategy strategy)
        {
            if (plantCount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(plantCount), "Количество растений должно быть положительным.");
            }

            PlantCount = plantCount;

            this.strategy = strategy
                ?? throw new ArgumentNullException(nameof(strategy));
        }

        public void SetStrategy(IWateringStrategy strategy)
        {
            this.strategy = strategy
                ?? throw new ArgumentNullException(nameof(strategy));
        }

        public int CalculateWater()
        {
            return strategy.CalculateWater(PlantCount);
        }
    }
}

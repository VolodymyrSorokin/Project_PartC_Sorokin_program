using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_partB_Sorokin_program
{
    public class Necklace
    {
        //private List<IGemstone> stones = new List<IGemstone>();

        //public List<IGemstone> gemstones;

        private List<IGemstone> stones;

        // Визначення подій
        public event EventHandler<IGemstone> StoneAdded;
        public event EventHandler<IGemstone> StoneRemoved;

        public Necklace()
        {
            stones = new List<IGemstone>();
        }

        public void AddStone(IGemstone stone)
        {
            if (stone != null)
            {
                stones.Add(stone);
                OnStoneAdded(stone); // Виклик події додавання каменю
            }
        }

        public bool Contains(IGemstone stone)
        {
            return stones.Contains(stone);
        }

        public void RemoveStone(IGemstone stone)
        {
            if (stone != null && stones.Contains(stone))
            {
                stones.Remove(stone);
                OnStoneRemoved(stone); // Виклик події видалення каменю
            }
        }

        public decimal GetTotalValue()
        {
            return stones.Sum(stone => stone.GetValue());
        }

        public double GetTotalWeight()
        {
            return stones.Sum(stone => stone.GetWeight());
        }

        public void SortByValue()
        {
            stones.Sort((x, y) => x.GetValue().CompareTo(y.GetValue()));
        }

        //public static void DeleteStone(Necklace necklace, IGemstone stone)
        //{
        //    // Метод для видалення каменю з намиста
        //    throw new NotImplementedException();
        //}

        public List<IGemstone> FindStonesByColor(string color)
        {
            return stones.Where(stone => stone.GetColor().Equals(color, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<IGemstone> GetStones()
        {
            return new List<IGemstone>(stones);
        }


        // Методи для виклику подій
        protected virtual void OnStoneAdded(IGemstone stone)
        {
            StoneAdded?.Invoke(this, stone);
        }

        protected virtual void OnStoneRemoved(IGemstone stone)
        {
            StoneRemoved?.Invoke(this, stone);
        }



        // Додавання методу, який використовує Action делегат та дозволяє виконувати будь-яку дію (наприклад, виведення інформації) з кожним каменем.
        public void ProcessStones(Action<IGemstone> action)
        {
            foreach (var stone in stones)
            {
                action(stone);
            }
        }


        // Метод, який використовує Func делегат та дозволяє обчислити сумарну вартість або вагу каменів на основі переданої функції.
        public decimal AggregateValues(Func<IGemstone, decimal> selector)
        {
            return stones.Sum(selector);
        }


        // Власний делегат для фільтрації каменів
        public delegate bool StoneFilter(IGemstone stone);
        // Метод, який використовує власний делегат для фільтрації каменів
        public List<IGemstone> FilterStones(StoneFilter filter)
        {
            return stones.Where(stone => filter(stone)).ToList();
        }
        public override string ToString()
        {
            string necklaceDescription = "Necklace contains the following stones:\n";
            foreach (var stone in stones)
            {
                necklaceDescription += stone.ToString() + "\n";
            }
            return necklaceDescription;
        }
    }
}

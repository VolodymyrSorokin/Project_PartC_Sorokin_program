using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_partB_Sorokin_program
{
    public abstract class Stone : IGemstone, IComparable<Stone>
    {
        public string Name { get; protected set; }
        public double CaratWeight { get; protected set; }
        public decimal Price { get; protected set; }
        public string Color { get; protected set; }

        protected Stone(string name, double caratWeight, decimal price, string color)
        {
            Name = name;
            CaratWeight = caratWeight;
            Price = price;
            Color = color;
        }

        public abstract string GetName();

        public abstract double GetWeight();
        public abstract decimal GetValue();
        public abstract string GetColor();
        public abstract string GetDetails();

        // Реалізація IComparable
        public int CompareTo(Stone other)
        {
            if (other == null) return 1;

            return this.Price.CompareTo(other.Price);
        }

        // Загальний метод ToString, який можна перевизначити в похідних класах
        public override string ToString()
        {
            return $"Name: {Name}, Weight: {CaratWeight} carats, Price: ${Price}, Color: {Color}";
        }

    }
}
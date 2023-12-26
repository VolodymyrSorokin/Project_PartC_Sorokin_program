using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;

namespace Project_partB_Sorokin_program
{
    public class PreciousStone : Stone
    {
        public int Clarity { get; private set; } // Чистота каменю

        public PreciousStone(PreciousGemstoneName name, double caratWeight, decimal price, string color, int clarity)
        : base(name.ToString(), caratWeight, price, color) // Конвертація enum в рядок
        {
            Clarity = clarity;
        }

        // Реалізація абстрактних методів з базового класу
        public override string GetName()
        {
            return Name;
        }
        public override double GetWeight()
        {
            return CaratWeight;
        }

        public override decimal GetValue()
        {
            return Price;
        }

        public override string GetColor()
        {
            return Color;
        }

        // Додавання деталей про чистоту каменю
        public override string GetDetails()
        {
            return $"Name: {Name}, Clarity: {Clarity}";
        }

        // Перевизначення методу ToString для надання додаткової інформації
        public override string ToString()
        {
            return base.ToString() + $", Clarity: {Clarity}";
        }
    }
}

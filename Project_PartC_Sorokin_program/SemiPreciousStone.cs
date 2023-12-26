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
    public class SemiPreciousStone : Stone
    {
        public int Hardness { get; private set; } // Твердість за шкалою Мооса

        public SemiPreciousStone(SemiPreciousGemstoneName name, double caratWeight, decimal price, string color, int hardness)
       : base(name.ToString(), caratWeight, price, color)
        {
            Hardness = hardness;
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
        // Додавання деталей про твердість каменю
        public override string GetDetails()
        {
            return $"Name: {Name}, Hardness: {Hardness} on Mohs scale";
        }

        // Перевизначення методу ToString для надання додаткової інформації
        public override string ToString()
        {
            return base.ToString() + $", Hardness: {Hardness} on Mohs scale";
        }
    }
}


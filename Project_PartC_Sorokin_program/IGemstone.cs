using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_partB_Sorokin_program
{
    public interface IGemstone
    {
        string GetName();// Повертає назву каменю
        double GetWeight();// Повертає вагу каменю в каратах
        decimal GetValue();// Повертає цінність каменю
        string GetColor();// Повертає колір каменю
        string GetDetails();// Повертає детальну інформацію про камінь
    }
}
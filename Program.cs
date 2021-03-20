using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fractions
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction fraction1 = new Fraction(1,11);
            Fraction fraction2 = new Fraction(8);
            Fraction fraction3 = fraction1.Divide(fraction2);
            fraction3.Print();// 
        }
    }
}


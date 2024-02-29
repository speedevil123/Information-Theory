using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Задание_3
{
    internal class Class1
    {
        static void Main()
        {
            Dictionary<string, double> bukva = new Dictionary<string, double>();
            bukva["Пробел"] = 0.175;
            bukva["о"] = 0.09;
            bukva["е"] = 0.072;
            bukva["а"] = 0.062;
            bukva["и"] = 0.062;
            bukva["н"] = 0.053;
            bukva["т"] = 0.053;
            bukva["с"] = 0.045;
            bukva["р"] = 0.04;
            bukva["в"] = 0.038;
            bukva["л"] = 0.035;
            bukva["к"] = 0.028;
            bukva["м"] = 0.026;
            bukva["д"] = 0.025;
            bukva["п"] = 0.023;
            bukva["у"] = 0.021;
            bukva["я"] = 0.018;
            bukva["ы"] = 0.016;
            bukva["з"] = 0.016;
            bukva["ъ"] = 0.014;
            bukva["б"] = 0.014;
            bukva["г"] = 0.013;
            bukva["ч"] = 0.012;
            bukva["й"] = 0.01;
            bukva["х"] = 0.009;
            bukva["ж"] = 0.007;
            bukva["ю"] = 0.006;
            bukva["ш"] = 0.006;
            bukva["ц"] = 0.004;
            bukva["щ"] = 0.003;
            bukva["э"] = 0.003;
            bukva["ф"] = 0.001;
            int cnt = bukva.Count();
            double[] array = new double[cnt];
            int i = 0;
            foreach(var pair in bukva)
            {
                array[i] = -pair.Value * Log(pair.Value, 2);
                i++;
            }
            double Hx = array.Sum();
            Console.WriteLine("Энтропия H(x) = " +  Hx);
        }
    }
}

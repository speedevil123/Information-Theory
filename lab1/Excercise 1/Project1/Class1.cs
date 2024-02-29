using System;
using static System.Math;
namespace Project1

//Задание 1 (Лабораторная работа 1)

{
    internal class Class1
    {
        static void Main()
        {
            //Заполняем массив в диапазоне от 0.01 до 0.99
            double[] array = new double[99];
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = i+1;
                array[i] /= 100;
            }

            double[] n = new double[array.Length];
            for(int i = 0; i < n.Length; i++)
            {
                n[i] = -array[i] * Log(array[i], 2);
                Console.WriteLine(n[i]);
            }
        }
    }
}

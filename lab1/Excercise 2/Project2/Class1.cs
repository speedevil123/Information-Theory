using System;
using System.Linq;
using static System.Math;
namespace Project2

//Задание 2 (Лабораторная работа 1)

{
    internal class Class1
    {
        static void Main()
        {
            //Заполняем массив в диапазоне от 0.01 до 0.99
            double[] array = new double[99];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
                array[i] /= 100;
            }

            //Переворачиваем полученный массив для заполнения от 0.99 до 0.01
            double[] reversedArray = array.Reverse().ToArray();
            double[] Hx = new double[array.Length];

            //Получаем 100 значений энтропии
            for (int i = 0; i < Hx.Length; i++)
            {
                Hx[i] = -(array[i] * Log(array[i], 2) + reversedArray[i] * Log(reversedArray[i], 2));
            }
            Console.WriteLine("Максимальное значение энтропии: " + Hx.Max());
        }
    }
}
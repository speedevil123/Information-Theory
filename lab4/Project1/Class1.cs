using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Math;

namespace lab4
{
    internal class Class1
    {
        public static int[] HemmingCoding(int[] code, int n_u, int n_k, int n)
        {
            int[] ai = new int[n + 1];
            ai[0] = 999;
            ai[1] = 999;
            ai[2] = code[0];
            ai[3] = 999;
            ai[4] = code[1];
            ai[5] = code[2];
            ai[6] = code[3];

            ai[0] = (ai[2] + ai[4] + ai[6]) % 2;
            ai[1] = (ai[2] + ai[5] + ai[6]) % 2;
            ai[3] = (ai[4] + ai[5] + ai[6]) % 2;
            ai[7] = ai.Sum() % 2;
            return ai;

        }

        public static void FixMistake(int[] codes, bool flag)
        {
            int sum = 0;
            for(int i = 0; i < codes.Length; i++)
            {
                sum += codes[i];
            }
            if(flag == true)
            {
                int s1 = 1;
                int s2 = 0;
                int s3 = 0;
                int s4 = 0;

                string number = s1.ToString() + s2.ToString() + s3.ToString() + s4.ToString();
                string number1 = s1.ToString() + s2 + s3 + s4;
                int _int = Convert.ToInt32(number1, 2);
                Console.WriteLine("Синдром S: (" + number + ") = " + _int + " (10)");
                Console.WriteLine("Одиночная ошибка найдена --> находится в " + _int + " разряде");

                for (int i = 0; i < codes.Length; i++)
                {
                    Console.Write(codes[i]);
                }
                Console.Write(" --> ");
                if (codes[_int - 1] == 0)
                    codes[_int - 1] = 1;
                else
                    codes[_int - 1] = 0;

                for (int i = 0; i < codes.Length; i++)
                {
                    if (i == _int - 1)
                        Console.Write("(" + codes[i] + ")");
                    else
                        Console.Write(codes[i]);
                }
                Console.WriteLine();
            }
            else
            {

                if(sum % 2 == 0)
                {
                    Console.WriteLine("\nСумма единиц ЧЕТНАЯ --> в коде двойная ошибка/ошибки нет");
                    int s1 = (codes[0] + codes[2] + codes[4] + codes[6]) % 2;
                    int s2= (codes[1] + codes[2] + codes[5] + codes[6]) % 2;
                    int s3 = (codes[3] + codes[4] + codes[5] + codes[6]) % 2;

                    string number = s3.ToString() + "," + s2.ToString() + "," + s1.ToString();
                    Console.WriteLine("Синдром S: (" + number + ")");
                    if ((s1 + s2 + s3) > 0)
                        Console.WriteLine("Синдром НЕнулевой --> ошибка двойная");
                    else
                        Console.WriteLine("Синдром нулевой --> ошибки нет");
                }
                else
                {
                    Console.WriteLine("\nСумма единиц НЕЧЕТНАЯ --> в коде одиночная ошибка");
                    int s1 = (codes[0] + codes[2] + codes[4] + codes[6]) % 2;
                    int s2 = (codes[1] + codes[2] + codes[5] + codes[6]) % 2;
                    int s3 = (codes[3] + codes[4] + codes[5] + codes[6]) % 2;
                    string number = s3.ToString() + "," + s2.ToString() + "," + s1.ToString();
                    string number1 = s3.ToString() + s2.ToString() + s1.ToString();
                    int _int = Convert.ToInt32(number1, 2);
                    Console.WriteLine("Синдром S: (" + number + ") = " + _int + " (10)"); 
                    Console.WriteLine("Одиночная ошибка найдена --> находится в " + _int + " разряде");

                    for (int i = 0; i < codes.Length; i++)
                    {
                        Console.Write(codes[i]);
                    }
                    Console.Write(" --> ");
                    if (codes[_int - 1] == 0)
                        codes[_int - 1] = 1;
                    else
                        codes[_int - 1] = 0;

                    for (int i = 0; i < codes.Length; i++)
                    {
                        if (i == _int-1)
                            Console.Write("(" + codes[i] + ")");
                        else
                            Console.Write(codes[i]);
                    }
                    Console.WriteLine();

                }
            }

        }

        public static int[][]DeleteElem(int[][] array, int index)
        {
            int[][] temp = new int[array.Length-1][];
            int count = -1;
            for(int i = 0;i < array.Length; i++)
            {
                if(i == index)
                {
                    continue;
                }
                else
                {
                    count++;
                    temp[count] = array[i];
                }
            }
            return temp;
        }
        public static void RandomValues(int[][] codes)
        {
            Random rnd = new Random();
            int[][] array = new int[16][];
            array[0] = new int[] {0, 0, 0, 0 };
            array[1] = new int[] { 0, 0, 0, 1 };
            array[2] = new int[] { 0, 0, 1, 0 };
            array[3] = new int[] { 0, 0, 1, 1 };
            array[4] = new int[] { 0, 1, 0, 0 };
            array[5] = new int[] { 0, 1, 0, 1 };
            array[6] = new int[] { 0, 1, 1, 0 };
            array[7] = new int[] { 0, 1, 1, 1 };
            array[8] = new int[] { 1, 0, 0, 0 };
            array[9] = new int[] { 1, 0, 0, 1 };
            array[10] = new int[] { 1, 0, 1, 0 };
            array[11] = new int[] { 1, 0, 1, 1 };
            array[12] = new int[] { 1, 1, 0, 0 };
            array[13] = new int[] { 1, 1, 0, 1 };
            array[14] = new int[] { 1, 1, 1, 0 };
            array[15] = new int[] { 1, 1, 1, 1 };


            int index = 0;
            int count = 16;
            for(int i = 0; i < codes.Length; i++)
            {
                index = rnd.Next(0, count);
                codes[i] = array[index];
                count--;
                array = DeleteElem(array, index);
            }

        }

        static void Main()
        {
            //Инициализируем массивы с кодами
            int[][] codes_ = new int[0][];

            int ans = 0, ans2 = 0;
            Console.WriteLine("Выберите пункт меню: ");
            do
            {
                Console.WriteLine("1 - Кодирование");
                Console.WriteLine("2 - Декодирование");
                Console.WriteLine("3 - Выход из программы");

                ans = int.Parse(Console.ReadLine());

                switch (ans)
                {
                    case 1:
                        codes_ = new int[10][];
                        for (int i = 0; i < codes_.Length; i++)
                        {
                            codes_[i] = new int[4];
                        }
                        //Генерируем случайную информационную часть
                        RandomValues(codes_);

                        //Считаем разряды
                        int n_u = 4;
                        int n_k = (int)Round(Log((n_u + 1) + Log(n_u + 1, 2), 2));
                        int n = n_u + n_k;
                        Console.WriteLine("Разряды: " +
                            "\nИнформационные n(и) - " + n_u +
                            "\nКонтрольные n(к) - " + n_k +
                            "\nОбщая разрядность кода n - " + n);

                        for (int i = 0; i < codes_.Length; i++)
                        {
                            Console.Write((i + 1) + ")");
                            codes_[i] = HemmingCoding(codes_[i], n_u, n_k, n);
                            for (int j = 0; j < codes_[i].Length; j++)
                            {
                                Console.Write(codes_[i][j]);
                            }
                            Console.WriteLine();
                        }
                        break;
                    case 2:
                        if (codes_.Length <= 0)
                            Console.WriteLine("Сгенерируйте коды (Пункт 1)");
                        else
                        {
                            do
                            {
                                Console.WriteLine("1 - Ввести и исправить одиночную ошибку");
                                Console.WriteLine("2 - Ввести и определить двойную ошибку");
                                Console.WriteLine("3 - Вернуться в главное меню");

                                ans2 = int.Parse(Console.ReadLine());

                                switch (ans2)
                                {
                                    case 1:
                                        int[][] temp_codes = codes_;
                                        for (int i = 0; i < temp_codes.Length; i++)
                                        {
                                            Console.Write((i + 1) + ")");
                                            for (int j = 0; j < temp_codes[i].Length; j++)
                                            {
                                                Console.Write(temp_codes[i][j]);
                                            }
                                            Console.WriteLine();
                                        }
                                        Console.Write("Выберите код для одиночной ошибки: ");
                                        int index_code = int.Parse(Console.ReadLine()) - 1;
                                        Console.Write("Введите индекс, где совершить ошибку: ");
                                        int index_mistake = int.Parse(Console.ReadLine()) - 1;

                                        for (int i = 0; i < temp_codes[index_code].Length; i++)
                                        {
                                            Console.Write(temp_codes[index_code][i]);
                                        }
                                        if (temp_codes[index_code][index_mistake] == 0)
                                            temp_codes[index_code][index_mistake] = 1;
                                        else temp_codes[index_code][index_mistake] = 0;

                                        Console.Write(" --> ");
                                        for(int i = 0; i < temp_codes[index_code].Length; i++)
                                        {
                                            if (i == index_mistake)
                                                Console.Write("(" + temp_codes[index_code][i] + ")");
                                            else
                                                Console.Write(temp_codes[index_code][i]);
                                        }
                                        if(index_mistake == 7)
                                            FixMistake(temp_codes[index_code], true);
                                        else
                                            FixMistake(temp_codes[index_code], false);

                                        break;
                                    case 2:
                                        temp_codes = codes_;
                                        for (int i = 0; i < temp_codes.Length; i++)
                                        {
                                            Console.Write((i + 1) + ")");
                                            for (int j = 0; j < temp_codes[i].Length; j++)
                                            {
                                                Console.Write(temp_codes[i][j]);
                                            }
                                            Console.WriteLine();
                                        }
                                        Console.Write("Выберите код для двойной ошибки: ");
                                        index_code = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Введите два индекса для совершения ошибки. ");
                                        Console.Write("Первый: ");
                                        int index_mistake1 = int.Parse(Console.ReadLine()) - 1;
                                        Console.Write("Второй: ");
                                        int index_mistake2 = int.Parse(Console.ReadLine()) - 1;
                                        for (int i = 0; i < temp_codes[index_code].Length; i++)
                                        {
                                            Console.Write(temp_codes[index_code][i]);
                                        }
                                        if (temp_codes[index_code][index_mistake1] == 0)
                                            temp_codes[index_code][index_mistake1] = 1;
                                        else temp_codes[index_code][index_mistake1] = 0;

                                        if (temp_codes[index_code][index_mistake2] == 0)
                                            temp_codes[index_code][index_mistake2] = 1;
                                        else temp_codes[index_code][index_mistake2] = 0;

                                        Console.Write(" --> ");
                                        for (int i = 0; i < temp_codes[index_code].Length; i++)
                                        {
                                            if (i == index_mistake1 || i == index_mistake2)
                                                Console.Write("(" + temp_codes[index_code][i] + ")");
                                            else
                                                Console.Write(temp_codes[index_code][i]);
                                        }
                                        FixMistake(temp_codes[index_code], false);
                                        break;
                                }
                            } while (ans2 != 3);
                        }   break;
                }
            } while (ans != 3);
        }
    }
}

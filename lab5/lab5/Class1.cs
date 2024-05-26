using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    internal class Class1
    {
        public static void ShowMatrix(int[,] Matrix)
        {
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Console.Write(Matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
        public static int[] GetCurrComb(int[,] Matrix, int idx)
        {
            int[] curr_comb = new int[Matrix.GetLength(1)];
            for (int j = 0; j < Matrix.GetLength(1); j++)
            {
                curr_comb[j] = Matrix[idx, j];
            }
            return curr_comb;
        }

        public static int[,] DeleteOneComb(int[,] Matrix, int idx)
        {
            int count = -1;
            int[,] Result_Matrix = new int[Matrix.GetLength(0) - 1, Matrix.GetLength(1)];
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                if (i == idx)
                {
                    continue;
                }
                else
                {
                    count++;
                    for (int j = 0; j < Matrix.GetLength(1); j++)
                    {
                        Result_Matrix[count, j] = Matrix[i, j];
                    }
                }
            }
            return Result_Matrix;
        }
        public static int[] SummModule2(int[] x, int[] y)
        {
            int[] result = new int[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] == y[i])
                    result[i] = 0;
                else
                    result[i] = 1;
            }
            return result;
        }
        public static int[] LinearCodingOnce(int[,] Matrix, int[] comb)
        {
            List<int> indexes = new List<int>();
            for (int i = 0; i < comb.Length; i++)
            {
                if (comb[i] == 1)
                    indexes.Add(i);
            }
            int[][] Temp = new int[indexes.Count][];
            for (int i = 0; i < indexes.Count; i++)
            {
                Temp[i] = GetCurrComb(Matrix, indexes[i]);
            }
            int[] result = new int[comb.Length];
            for(int i = 0; i < Temp.Length - 1; i++)
            {
                if (i == 0)
                    result = SummModule2(Temp[i], Temp[i + 1]);
                else
                    result = SummModule2(result, Temp[i + 1]);
            }

            int[] FinishCode = new int[comb.Length + result.Length];
            for(int i = 0; i < comb.Length; i++)
            {
                FinishCode[i] = comb[i];
            }
            int count = 0;
            for(int i = comb.Length; i < comb.Length + result.Length; i++)
            {
                FinishCode[i] = result[count++];
            }

            return FinishCode;

        }
        public static int[][] LinearCoding(int[,] Matrix)
        {
            int n_u = 4;
            int n_k = 3;
            int n = n_u + n_k;
            int[,] Matrix_All = new int[,]
            {
                {0, 0, 1, 1 },
                {0, 1, 0, 1 },
                {0, 1, 1, 0 },
                {0, 1, 1, 1 },
                {1, 0, 0, 1 },
                {1, 0, 1, 0 },
                {1, 0, 1, 1 },
                {1, 1, 0, 0 },
                {1, 1, 0, 1 },
                {1, 1, 1, 0 },
                {1, 1, 1, 1 }
            };
            Random rnd = new Random();
            int random = rnd.Next(0, Matrix_All.GetLength(0));

            Matrix_All = DeleteOneComb(Matrix_All, random);

            int[][] Matrix_Codes = new int[Matrix_All.GetLength(0)][];
            for(int i = 0; i < Matrix_All.GetLength(0); i++)
            {
                Matrix_Codes[i] = LinearCodingOnce(Matrix, GetCurrComb(Matrix_All, i));
            }

            return Matrix_Codes;
        }
        
        public static int[] FixMistake(int[] comb, int[,] Matrix_p_tr_)
        {
            int s1 = (comb[4] + comb[0] + comb[1] + comb[2]) % 2;
            int s2 = (comb[5] + comb[0] + comb[1] + comb[3]) % 2;
            int s3 = (comb[6] + comb[0] + comb[2] + comb[3]) % 2;
            Console.WriteLine("\nS1 = " + s1);
            Console.WriteLine("S2 = " + s2);
            Console.WriteLine("S3 = " + s3);
            int[] ski = new int[3];
            ski[0] = s1;
            ski[1] = s2;
            ski[2] = s3;
            Console.WriteLine("\nМатрица H: ");
            ShowMatrix(Matrix_p_tr_);
            int res_idx = 0;
            for(int j = 0; j < Matrix_p_tr_.GetLength(1); j++)
            {
                bool isMatch = true;
                for(int i = 0; i < Matrix_p_tr_.GetLength(0); i++)
                {
                    if (Matrix_p_tr_[i,j] != ski[i])
                    {
                        isMatch = false;
                        break;
                    }
                }
                if(isMatch)
                {
                    res_idx = j;
                    Console.WriteLine("Ошибка находится в " + (j + 1) + " столбце ==> ошибка в " + (j + 1) + " разряде");
                }
            }

            for (int i = 0; i < comb.Length; i++)
                Console.Write(comb[i]);

            if (comb[res_idx] == 0)
                comb[res_idx] = 1;
            else
                comb[res_idx] = 0;
            Console.Write(" --> ");
            for (int i = 0; i < comb.Length; i++)
            {
                if (i == res_idx)
                    Console.Write("(" + comb[i] + ")");
                else
                    Console.Write(comb[i]);
            }
            Console.WriteLine();
            return comb;
        }

        public static void Main()
        {
            int ans = 0;
            do
            {
                Console.WriteLine("1 - Начать работу" +
                    "\n2 - Выйти из приложения");
                ans = Convert.ToInt32(Console.ReadLine());
                switch(ans)
                {
                    case 1:
                        int[,] Matrix_P = new int[,]
{
                    {1, 1, 1 },
                    {1, 1, 0 },
                    {1, 0, 1 },
                    {0, 1, 1 }
};

                        int[,] Matrix_P_Tr = new int[,]
                        {
                    {1, 1, 1, 0, 1, 0, 0 },
                    {1, 1, 0, 1, 0, 1, 0 },
                    {1, 0, 1, 1, 0, 0, 1 }
                        };
                        int[][] LinearCodes = LinearCoding(Matrix_P);

                        Console.WriteLine("Выберите код для совершения ошибки: ");
                        for (int i = 0; i < LinearCodes.GetLength(0); i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                if (j == 0)
                                    Console.Write(i + ") ");
                                Console.Write(LinearCodes[i][j]);
                            }
                            Console.WriteLine();
                        }

                        int idx = Convert.ToInt32(Console.ReadLine());
                        int[] chosen_code = LinearCodes[idx];
                        for (int i = 0; i < LinearCodes[idx].Length; i++)
                            Console.Write(LinearCodes[idx][i]);

                        Console.WriteLine("\nВыберите разряд для совершения ошибки: ");
                        idx = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < chosen_code.Length; i++)
                            Console.Write(chosen_code[i]);
                        if (chosen_code[idx - 1] == 0)
                            chosen_code[idx - 1] = 1;
                        else
                            chosen_code[idx - 1] = 0;


                        Console.Write(" --> ");
                        for (int i = 0; i < chosen_code.Length; i++)
                        {
                            if (i == idx - 1)
                                Console.Write("(" + chosen_code[i] + ")");
                            else
                                Console.Write(chosen_code[i]);
                        }

                        chosen_code = FixMistake(chosen_code, Matrix_P_Tr);
                        break;
                }


            } while (ans != 2);

        }
    }
}

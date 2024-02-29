using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Задание_1
{
    internal class Class1
    {
        class ShowMatr
        {
            public static void ShowMatrix(double[,] matr)
            {
                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    Console.Write("|");
                    if (i == 0)
                    {
                        Console.Write(" Y/X\t|");
                        for (int h = 0; h < matr.GetLength(1); h++)
                        {
                            Console.Write(" X" + (h + 1) + "\t|");
                        }
                        Console.WriteLine();
                        Console.WriteLine("-----------------------------------------------------------------------------------------");
                        Console.Write("|");
                    }
                    Console.Write(" Y" + (i + 1) + "\t|");



                    for (int j = 0; j < matr.GetLength(1); j++)
                    {
                        Console.Write(" " + Math.Round(matr[i, j], 2) + "\t|");
                    }
                    Console.WriteLine();
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                }
            }
            public static void ShowMatrixBottomSum(double[,] matr)
            {
                double[] array = new double[10];
                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    double temp = 0;
                    Console.Write("|");
                    if (i == 0)
                    {
                        Console.Write(" Y/X\t|");
                        for (int h = 0; h < matr.GetLength(1) + 1; h++)
                        {
                            if(h == 10)
                            {
                                Console.Write(" P(Y)" + "\t");
                            }
                            else
                                Console.Write(" X" + (h + 1) + "\t|");
                        }
                        Console.WriteLine();
                        Console.WriteLine("-------------------------------------------------------------------------------------------------");
                        Console.Write("|");
                    }
                    Console.Write(" Y" + (i + 1) + "\t|");



                    for (int j = 0; j < matr.GetLength(1); j++)
                    {
                        temp += matr[i, j];
                        array[i] += matr[j, i];
                        Console.Write(" " + Math.Round(matr[i, j], 2) + "\t|");
                        if(j == 9)
                        {
                            Console.Write(" " + Math.Round(temp, 2) + "\t");
                        }    
                    }

                    Console.WriteLine();
                    Console.WriteLine("-------------------------------------------------------------------------------------------------");
                }
                Console.Write("| P(X)" + "\t|");
                for(int i = 0;i < array.Length; i++)
                {
                    Console.Write("  " + Math.Round(array[i],2) + "\t|");
                }
                Console.WriteLine();
            }
        }
        static void Main()
        {
            double[,] matr_Pij = new double[10, 10];
            Random rnd = new Random();
            int cnt = 0;
            for (int i = 0; i < matr_Pij.GetLength(0); i++)
            {
                for (int j = 0; j < matr_Pij.GetLength(1); j++)
                {
                    if (cnt % 4 == 0)
                        matr_Pij[i, j] = 0;
                    else
                        matr_Pij[i, j] = rnd.NextDouble();
                    cnt++;
                }
            }            
            double sum = matr_Pij.Cast<double>().Sum();
            for (int i = 0; i < matr_Pij.GetLength(0); i++)
            {
                for (int j = 0; j < matr_Pij.GetLength(1); j++)
                {
                    matr_Pij[i, j] /= sum;
                }
            }

            ShowMatr.ShowMatrixBottomSum(matr_Pij);


            //P(Xi)
            double[] Pxi = new double[matr_Pij.GetLength(0)];
            double[] Pyj = new double[matr_Pij.GetLength(1)];
            for (int i = 0; i < matr_Pij.GetLength(0); i++)
            {
                double sum_row = 0;
                double sum_col = 0;
                for (int j = 0; j < matr_Pij.GetLength(1); j++)
                {
                    sum_row += matr_Pij[i, j];
                    sum_col += matr_Pij[j, i];
                }
                Pxi[i] = sum_col;
                Pyj[i] = sum_row;
            }

            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("P(Xi) = " + Math.Round(Pxi[i],2) + " P(Yj) = " + Math.Round(Pyj[i],2));
            }
            double[,] canal_matrPYjXi = new double[10, 10];
            double[,] canal_matrPXiYj = new double[10, 10];

            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    if (Pxi[i] == 0)
                        canal_matrPYjXi[j, i] = 0;
                    else
                        canal_matrPYjXi[j, i] = matr_Pij[j, i] / Pxi[i];

                    if (Pyj[i] == 0)
                        canal_matrPXiYj[i, j] = 0;
                    else
                        canal_matrPXiYj[i, j] = matr_Pij[i, j] / Pyj[i];
                }
            }

            Console.WriteLine("\nКанальная матрица P(Yj/Xi): ");
            ShowMatr.ShowMatrixBottomSum(canal_matrPYjXi);

            Console.WriteLine("\nКанальная матрица P(Xi/Yj): ");
            ShowMatr.ShowMatrixBottomSum(canal_matrPXiYj);

            double[] H_X_yj = new double[10], H_Y_xi = new double[10];

            for(int i = 0; i < matr_Pij.GetLength(0); i++)
            {
                for(int j = 0; j < matr_Pij.GetLength(1); j++)
                {
                    if (canal_matrPYjXi[i, j] == 0)
                        H_Y_xi[i] += 0;
                    else
                        H_Y_xi[i] += canal_matrPYjXi[i, j] * Log(canal_matrPYjXi[i, j], 2);
                    if (canal_matrPXiYj[i, j] == 0)
                        H_X_yj[i] += 0;
                    else
                        H_X_yj[i] += canal_matrPXiYj[i, j] * Log(canal_matrPXiYj[i, j], 2);
                }
                H_Y_xi[i] = -H_Y_xi[i];
                H_X_yj[i] = -H_X_yj[i];
            }

            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("H(Y/Xi) = " + Math.Round(H_Y_xi[i],2) + " H(X/Yj) = " + Math.Round(H_X_yj[i],2));
            }
            double H_Y_X = 0;
            double H_X_Y = 0;


            for (int i =0; i < matr_Pij.GetLength(0); i++)
            {
                H_X_Y += Pyj[i] * H_X_yj[i];
                H_Y_X += Pxi[i] * H_Y_xi[i];
            }
            

            Console.WriteLine("H(X/Y) = " + H_X_Y + " H(Y/X) = " + H_Y_X);
        }
    }

}

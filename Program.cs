using System;
using System.Data;
using System.Globalization;
using MyLib;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {

        
            void Task54()
            {
                /* Задача 54: Задайте двумерный массив. Напишите программу, которая
                упорядочит по убыванию элементы каждой строки двумерного массива. */
                int rows = 4;
                int columns = 6;

                int[,] matrix = new int[rows, columns];

                MyLibClass.FillArray(matrix);
                MyLibClass.PrintArray(matrix);

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        for (int k = 0; k < columns - j - 1; k++)
                        {
                            if (matrix[i, k] < matrix[i, k + 1])
                            {
                                (matrix[i, k], matrix[i, k + 1]) = (matrix[i, k + 1], matrix[i, k]);
                            }
                        }
                    }
                }

                Console.WriteLine("\nОтсортированный массив: ");
                MyLibClass.PrintArray(matrix);
            }

            void Task56()
            {
                /* Задача 56: Задайте прямоугольный двумерный массив. Напишите
                программу, которая будет находить строку с наименьшей суммой элементов.
                 */

                int rows = 4;
                int columns = 5;

                int[,] matrix = new int[rows, columns];

                MyLibClass.FillArray(matrix, 0, 9);
                MyLibClass.PrintArray(matrix);

                int min_sum = Int32.MaxValue;
                int min_index = 0;

                for (int i = 0; i < rows; i++)
                {
                    int sum = 0;
                    for (int j = 0; j < columns; j++)
                    {
                        sum += matrix[i, j];
                    }

                    if (min_sum > sum)
                    {
                        min_sum = sum;
                        min_index = i;
                    }
                    Console.WriteLine($"Сумма строки {i + 1} равна {sum}");

                }
                Console.WriteLine($"Минимальная сумма равна {min_sum}. Она в строке {min_index + 1}");
            }

            void Task58()
            {
               /*  Задача 58: Заполните спирально массив 4 на 4
                 1  2  3 4
                12 13 14 5
                11 16 15 6
                10  9  8 7   */

                int rows = 3;
                int columns = 6;

                int[,] matrix = new int[rows, columns];


                int i = 0;
                int j = 0;

                int delta_i = 0;
                int delta_j = 1;
                int steps = columns;
                int turns = 0;

                for (int k = 0; k < matrix.Length; k++)
                {      
                    matrix[i, j] = k + 1;
                    steps--;
                    //Console.Write($"{matrix[i, j]} ");

                    if (steps == 0)
                    {
                        steps = rows * ((turns + 1) % 2) + columns * (turns % 2) - 1 - turns/2;
                        /* if (turns % 2 == 0) steps = rows - 1 - turns/2;
                        else steps = columns - 1 - turns/2; */
                        turns++;
                        int temp = -delta_i;
                        delta_i = delta_j;
                        delta_j = temp;
                    }

                    i += delta_i;
                    j += delta_j;
                                        
                }
                MyLibClass.PrintArray(matrix);
            }

            Console.Clear();
            Task58();
        }
    }
}

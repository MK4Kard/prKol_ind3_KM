using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace prKol_ind3_1_KM
{
    class Program
    {
        static void Main(string[] args)
        {
            ComplexNum z = new ComplexNum();

            ArrayList nums = new ArrayList();

            Console.WriteLine("Введите название файла с числами");
            string name = Console.ReadLine();

            if (File.Exists(name))
            {
                string[] z_num = File.ReadAllLines(name);

                foreach (string num in z_num)
                {
                    nums.Add(num);
                }

                if (nums.Count % 2 == 0)
                {
                    int i = 0;

                    while (i < nums.Count)
                    {
                        string z1 = nums[i].ToString();
                        string z2 = nums[i + 1].ToString();

                        Console.WriteLine($"Комплексные числа:\n{z1}\n{z2}");

                        if (ValComplexNum(z1) && ValComplexNum(z2))
                        {
                            z1 = z1.Replace(" ", "");
                            z2 = z2.Replace(" ", "");

                            Console.WriteLine("Какое действие совершить\n1 - сложение\n2 - вычитание\n3 - умножение");
                            int n = Convert.ToInt32(Console.ReadLine());

                            switch (n)
                            {
                                case 1:
                                    Console.WriteLine(z.Add(z1, z2));
                                    break;
                                case 2:
                                    Console.WriteLine(z.Sub(z1, z2));
                                    break;
                                case 3:
                                    Console.WriteLine(z.Mult(z1, z2));
                                    break;
                                default:
                                    Console.WriteLine("Неверный вариант выбора");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Комплексное число записано неправильно");
                            break;
                        }

                        i += 2;
                    }
                }
                else
                {
                    Console.WriteLine("Чисел должно быть ровно");
                }
            }
            else
            {
                Console.WriteLine("Такого файла не существует");
            }

            Console.ReadLine();
        }
        static bool ValComplexNum(string z) // проверка комплексного числа на правильную запись
        {
            string pattern = @"^([-+]?d*.?d*)s*([-+]s*d*.?d*)i$";

            Regex regex = new Regex(pattern);

            return regex.IsMatch(z.Replace(" ", ""));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace prKol_ind3_1_KM
{
    class ComplexNum
    {       
        public string Add(string n, string m) //сложение комплексных чисел 
        {
            var firstN = ComplexParts(n); // первое комплексное число
            var firstM = ComplexParts(m); // второе комплексное число

            int a = Convert.ToInt32(firstN[0]) + Convert.ToInt32(firstM[0]); // сумма действительных чисел
            int b = Convert.ToInt32(firstN[1]) + Convert.ToInt32(firstM[1]); // сумма мнимых чисел

            string sum = Answer(a, b);

            return sum;
        }
        public string Sub(string n, string m) // вычитание комплексных чисел
        {
            var firstN = ComplexParts(n); // первое комплексное число
            var firstM = ComplexParts(m); // второе комплексное число

            int a = Convert.ToInt32(firstN[0]) - Convert.ToInt32(firstM[0]); // разность действительных чисел
            int b = Convert.ToInt32(firstN[1]) - Convert.ToInt32(firstM[1]); // разность мнимых чисел

            string sum = Answer(a, b);

            return sum;
        }
        public string Mult(string n, string m) // умножение комплексных чисел
        {
            var firstN = ComplexParts(n); // первое комплексное число
            var firstM = ComplexParts(m); // второе комплексное число

            int a1 = Convert.ToInt32(firstN[0]);
            int a2 = Convert.ToInt32(firstM[0]);
            int b1 = Convert.ToInt32(firstN[1]);
            int b2 = Convert.ToInt32(firstM[1]);

            int a = a1 * a2 - b1 * b2; // действительная часть произведения
            int b = a1 * b2 + b1 * a2; // мнимая часть произведения

            string sum = Answer(a, b);

            return sum;
        }

        private ArrayList ComplexParts(string complexNum) // разделение комплексных чисел на числа
        {
            var parts = new ArrayList();

            int firstPlus = complexNum.IndexOf("+");
            if (firstPlus == -1)
                firstPlus = complexNum.LastIndexOf("-");

            string a = complexNum.Substring(0, firstPlus).Trim();
            string b = complexNum.Substring(firstPlus).Trim().Replace("i", "");
            if (b == "+")
            {
                parts.Add(Convert.ToInt32(a));
                parts.Add(1);
            }
            else if (b == "-")
            {
                parts.Add(Convert.ToInt32(a));
                parts.Add(-1);
            }
            else
            {
                parts.Add(Convert.ToInt32(a));
                parts.Add(Convert.ToInt32(b));
            }

            return parts;
        }
        private string Answer(int a, int b) // Вывод ответа
        {
            var parts = new[] { a.ToString() }.Concat(b > 1 ? new[] { $"+{b}i" } : // проверка мнимой части
                b < -1 ? new[] { $"{b}i" } :
                b == 0 ? new[] { $"" } :
                b == 1 ? new[] { $"+i" } :
                b == -1 ? new[] { $"-i" } :
                new string[] { });

            return string.Join("", parts);
        }
    }
}

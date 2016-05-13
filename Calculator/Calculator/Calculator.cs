using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите выражение: ");
            var s = Console.ReadLine();
            double r = Parse(s);
            Console.WriteLine(r);
            Console.ReadLine();
        }
        //Метод - Сложение и Вычитание
        static int Parse(string s)
        {
            int index = 0;
            var v = Multiple(s, ref index);
            while (index < s.Length)
            {
                switch (s[index])
                {
                    case '+':
                        index++;
                        v += Multiple(s, ref index);
                        break;
                    case '-':
                        index++;
                        v -= Multiple(s, ref index);
                        break;
                    default:
                        Console.WriteLine("Error! - {0}", s[index]);
                        break;
                }
            }
            return v;
        }


        //Метод - Умножение и Деление
        static int Multiple(string s, ref int index)
        {
            var v = Exponentiation(s, ref index);
            while (index < s.Length)
            {
                switch (s[index])
                {
                    case '*':
                        index++;
                        v *= Exponentiation(s, ref index);
                        break;
                    case '/':
                        index++;
                        v /= Exponentiation(s, ref index);
                        break;
                    default:
                        return v;
                }
            }
            return v;
        }

        //Метод - Факториал и Двойной Факториал
        static int Factorial(string s, ref int index)
        {
            var v = GetNumber(s, ref index);
            while (index < s.Length)
            {
                switch (s[index])
                {
                    case '!':
                        if (((s[index]) + 1) == '!')
                        {
                            index++;
                            v = TwinFactCalc(v);
                            continue;
                        }
                        index++;
                        v = FactCalc(v);
                        break;
                    default:
                        return v;
                }
            }
            return v;
        }

        //Метод - Возведение в степень

        static int Exponentiation(string s, ref int index)
        {
            var v = Factorial(s, ref index);
            while (index < s.Length)
            {
                switch (s[index])
                {
                    case '^':
                        index++;
                        double exp = Math.Pow(v, Factorial(s, ref index));
                        v = (int)exp;
                        break;
                    default:
                        return v;
                }
            }
            return v;
        }

        //Вычисление факториала
        static int FactCalc(int v)
        {
            int f = 1;
            for (int i = 2; i <= v; ++i)
                f *= i;
            v = f;
            return v;
        }

        //Вычисление двойного факториала
        static int TwinFactCalc(int v)
        {
            int tf = 1;
            for (int i = v % 2 == 0 ? 2 : 1; i <= v; i += 2)
                tf *= i;
            v = tf;
            return v;
        }

        //Метод - Разбор Строки
        static int GetNumber(string s, ref int index)
        {
            var tmp = "";
            foreach (var c in s.Substring(index))
            {
                if (!char.IsDigit(c))
                {
                    break;
                }
                index++;
                tmp += c;
            }
            return int.Parse(tmp);
        }
    }
}

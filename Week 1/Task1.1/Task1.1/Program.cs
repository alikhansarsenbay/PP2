using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        public static bool Prime(int a)//создаем функцию для проверки простых чисел
        {
            bool ch = true;
            if (a == 1) ch = false;
            for (int i = 2; i < a; i++)//число простое,надо проверить не делится ли на числа до него
            {
                if (a % i == 0)
                {
                    ch = false;
                }
            }
            return ch;
        }
        static void Main(string[] args)
        {

            int n;//создаем переменную
            n = int.Parse(Console.ReadLine());//вводим массив 5 
            string s = Console.ReadLine();
            string[] arr = s.Split();//создаем массив и разибиваем строку s на элементы массива
            int cnt = 0;//создаем счетчик
            for (int i = 0; i < n; i++)
            {
                int c = int.Parse(arr[i]);//преобразовываем элемент массива в число 
                if (Prime(c) == true)//проверка числа 
                {
                    cnt++;
                }
            }
            Console.WriteLine(cnt);//выводим счетчик

            for (int i = 0; i < n; i++)
            {
                int c = int.Parse(arr[i]);
                if (Prime(c) == true)
                {
                    Console.Write(c + " ");//выводим на экран простые числа через пробел в строке
                }
            }
            Console.ReadKey();
        }
    }
}

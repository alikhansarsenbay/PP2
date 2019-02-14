using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Task22W2
{
    class Program
    {
        public static bool IsPrime(int x)//создаем функцию для проверки простых чисел
        {
            if (x == 1) return false;

            for (int i = 2; i < x; ++i)
            {
                if (x % i == 0)
                {
                    return false;
                }
            }
            return true;
        }


        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"C:\Users\alecb\Desktop\PP2\week2\input2.txt");//считывает информацию с выбранной папки 
            string line = sr.ReadLine();//сохраняет её в строку
            sr.Close();
            string[] nums = line.Split(' ');//сортирует в каждую ячейку массива 
            StreamWriter sw = new StreamWriter(@"C:C:\Users\alecb\Desktop\PP2\week2\output.txt");//выводит в другом файле

            foreach (string x in nums)
            {
                if (IsPrime(int.Parse(x)) == true)
                {
                    sw.Write(x + " ");
                }
            }
            sw.Close();
        }
    }
}


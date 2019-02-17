using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task333
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            string elements = Console.ReadLine();
            string[] array = elements.Split();//используем сплит чтоб поделить массив на ячейки

            int n = int.Parse(num);//переводим строку в число

            for (int i = 0; i < n; i++)
            {
                Console.Write(array[i] + " ");
                Console.Write(array[i]);//повторяем числа
                Console.Write(" ");
            }
            Console.ReadKey();
        }
    }
}
    


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4W2
{
    class Program
    {
        static void Main(string[] args)
        {
            string FilePath1 = @"C:\Users\alecb\Desktop\PP2\week2\path\file.txt";//указывает путь
            string FilePath2 = @"C:\Users\alecb\Desktop\PP2\week2\path1\file.txt";//указывает еще один путь
            StreamWriter sw = new StreamWriter(FilePath1);//создаём файл
            sw.WriteLine("random string");
            sw.Close();
            File.Copy(FilePath1, FilePath2);//копирует с первого во второй 
            File.Delete(FilePath1);//удаляет первый

        }
    }
}

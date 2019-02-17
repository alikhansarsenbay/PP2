using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t2w1
{
    class Student
    {
        public string name; // global name
        public string id; // global id 
        public int yearOfStudy; // global year

        public Student(string name, string id, int yearOfStudy)
        {
            this.name = name; // we need to read our name as global
            this.id = id; // we need to read our id as global
            this.yearOfStudy = yearOfStudy; // we need to read our year as global
        }

        public Student() //inputing the data about student
        {
            name = Console.ReadLine(); // read the input 
            id = Console.ReadLine(); // read the input
            yearOfStudy = Convert.ToInt32(Console.ReadLine()); // read the input and make integer
        }

        public void PrintInfo() // output the data about student with increment yearofstudy
        {
            Console.WriteLine(name); // print name
            Console.WriteLine(id); // print id
            Console.WriteLine(yearOfStudy + 1); // print year
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student(); // give student to s
            s.PrintInfo(); // call function
            Console.ReadKey(); // for not to close function
        }
    }
}
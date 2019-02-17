using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FarM
{
    class Program
    {
        class FarManager
        {
            public int cursor;
            public string path;
            public int sz;
            public FileSystemInfo currentfs = null;
            public DirectoryInfo dir = null;
            public FarManager()
            {
                cursor = 0;
            }
            public FarManager(string path)
            {
                this.path = path;
                cursor = 0;
                dir = new DirectoryInfo(path);
                sz = dir.GetFileSystemInfos().Length;//размер папки(количество файлов в нем)
            }
            public void Color(FileSystemInfo f, int index)
            {
                if (cursor == index)//чтоб подчеркнуть файл или папку на которую наведён курсор
                {
                    currentfs = f;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                if (f.GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;//Если это папка то он подкрашивается в синий
                }
                else
                    Console.ForegroundColor = ConsoleColor.Yellow;//в других случаях жёлтым
            }
            private static void PrintInfo(FileSystemInfo[] x, ConsoleColor c)
            {
                Console.ForegroundColor = c;
                foreach (var t in x)
                {
                    Console.WriteLine(t.Name);
                }
            }
            public void Show()
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                dir = new DirectoryInfo(path);
                int ind = 1;
                FileSystemInfo[] fs = dir.GetFileSystemInfos();//мы добавляем в массив все папки и файлы из выбранной папки
                for (int i = 0; i < fs.Length; i++)
                {
                    Color(fs[i], i);//мы пробуем подчеркнуть каждый элемент массива
                    Console.WriteLine(ind + "." + " " + fs[i]);
                    ind++;
                }
            }
            public void Up()//функция чтоб подниматься по листу вверх
            {
                cursor--;
                if (cursor < 0)//когда мы хотим пройти выше первого элемента он переводит на последний элемент листа 
                {
                    cursor = sz - 1;
                }
            }
            public void Down()//когда мы хотим пройти ниже последнего он переводит на первый элемент листа
            {
                cursor++;
                if (cursor == sz)
                {
                    cursor = 0;
                }
            }
            public void Start()
            {
                ConsoleKeyInfo keyinfo = Console.ReadKey();
                while (keyinfo.Key != ConsoleKey.Escape)//с нажатием "Escape" выходит из программы
                {
                    Show();
                    keyinfo = Console.ReadKey();
                    if (keyinfo.Key == ConsoleKey.UpArrow)
                    {
                        Up();
                    }
                    else if (keyinfo.Key == ConsoleKey.DownArrow)
                    {
                        Down();
                    }
                    if (keyinfo.Key == ConsoleKey.Enter)//выбираю элемент массива и нажимаю "Enter"
                    {
                        if (currentfs.GetType() == typeof(DirectoryInfo))
                        {//входим в папку
                         
                            cursor = 0;
                            path = currentfs.FullName;
                        }
                        if (currentfs.GetType() == typeof(FileInfo))//если это файл то открываем его в консоли(textfiles)
                        {
                            cursor = 0;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Black;
                            using (StreamReader sr = new StreamReader(currentfs.FullName))//считываем коньекст файла
                            {
                                Console.WriteLine(sr.ReadToEnd());//используем ReadtoEnd
                            }
                            Console.ReadKey();
                        }
                    }
                    if (keyinfo.Key == ConsoleKey.R)
                    {
                        string path1 = currentfs.FullName;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        Console.WriteLine("Please write new name, to rename {0}", currentfs.FullName);
                        string name = Console.ReadLine();
                    }
                        if (keyinfo.Key == ConsoleKey.Delete)//с помощью кнопки "Delete" удаляем элемент массива                 
                    {
                        cursor = 0;
                        if (currentfs.GetType() == typeof(DirectoryInfo))
                        {

                            if (new DirectoryInfo(currentfs.FullName).GetFileSystemInfos().Length == 0)//если папка пуста то можно без проблем удалить её
                            {
                                Directory.Delete(currentfs.FullName);
                            }
                            else//если в папке есть элементы то спрашивается точно ли хотят сделать данное действие 
                            {
                                Console.Clear();
                                Console.WriteLine("Are you sure?");
                                if (Console.ReadKey().Key == ConsoleKey.Y)//если да  то удаляет 
                                {
                                    Directory.Delete(currentfs.FullName, true);
                                }



                            }
                        }

                        else if (currentfs.GetType() == typeof(FileInfo))//удаляет файлы
                        {
                            File.Delete(currentfs.FullName);
                        }
                    }

                    if (keyinfo.Key == ConsoleKey.I)//с помощью кнопки "I" мы пытаемся переименовать наши file or directory
                    {
                        cursor = 0;
                        if (currentfs.GetType() == typeof(DirectoryInfo))
                        {
                            Console.Clear();
                            string s = Console.ReadLine();//пишем название которое хотим изменить
                            string Name = currentfs.Name;//простое название папки
                            string fName = currentfs.FullName;//нахождение папки
                            string newpath = "";
                            for (int i = 0; i < fName.Length - Name.Length; i++)
                            {
                                newpath += fName[i];//путь который указывает положение папки
                            }
                            newpath = newpath + s;
                            Directory.Move(fName, newpath);//изменяет имя
                        }
                        else
                        {
                            Console.Clear();
                            string s = Console.ReadLine();
                            string Name = currentfs.Name;
                            string fName = currentfs.FullName;
                            string newpath = "";
                            for (int i = 0; i < fName.Length - Name.Length; i++)
                            {
                                newpath += fName[i];
                            }
                            newpath = newpath + s;
                            File.Move(fName, newpath);
                        }

                    }
                    if (keyinfo.Key == ConsoleKey.Backspace)//при нажатии "Backspace" возвращаемся в last folder
                    {
                        cursor = 0;
                        path = dir.Parent.FullName;
                    }

                }
            }

            static void Main(string[] args)
            {
                string path = @"C:\Users\alecb\Desktop\PP2";
                FarManager fr = new FarManager(path);
                fr.Start();
            }
        }
    }
}

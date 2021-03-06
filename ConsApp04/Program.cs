﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsApp04
{
    #region Задание №1. Размерность и диапазон значений вводятся пользователем
    class MyArrayTask1
    {        
        public MyArrayTask1( int n, int min, int max)
        {
            a = new int[n];
            Random rnd = new Random();
            for(int i = 0; i < n; i++)
            {
                a[i] = rnd.Next(min, max);
            }
        }
        public override string ToString()
        {
            string s = "";
            foreach (int v in a)
                s = s + v + " ";
            return s;
        }
        public int Couple
        {
            get
            {
                int count = 0;
                for(int i = 0; i < a.Length-1; i++)
                {
                    if ((Math.Abs(a[i]) % 3 == 0 && Math.Abs(a[i])!=0) || (Math.Abs(a[i + 1]) % 3 == 0 && Math.Abs(a[i+1]) != 0))
                    {
                        count++;
                    }
                }
                return count;
            }
        }       
        public MyArrayTask1()
        {

        }
        int[] a;
    }
    #endregion

    #region Задание №2. Дописать клас для работы с одномерным массивом
    class MyArrayTask2a
    {
        public MyArrayTask2a(int n, int start, int step)
        {
            a = new int[n];
            a[0] = start;
            for(int i = 1; i < n; i++)
            {
                a[i] = a[i - 1] + step;
            }
        }
        public MyArrayTask2a()
        {

        }
        public int MaxCount
        {
            get 
            {
                int count=0;
                int max = 0;
                int indexer = 0;
                for(int i = 0; i < a.Length; i++)
                {
                    if (max < a[i])
                    {
                        max = a[i];
                        indexer = i;
                    }
                }
                for(int i = 0; i < a.Length; i++)
                {
                    if (max == a[i])
                        count++;
                }
                return count;
            }
        }
        public int Sum
        {
            get
            {
                int sum = 0;
                for(int i = 0; i < a.Length; i++)
                {
                    sum += a[i];
                }
                return sum;
            }
        }
        public void Multi(int m)
        {
            for (int i = 0; i < a.Length; i++)
                a[i] *= m;
        }
        public void Invers ()
        {
            for(int i = 0; i < a.Length; i++)                
                    a[i] *= -1;
                
        }
 
        public override string ToString()
        {
            string s = "";
            foreach (int v in a)
                s = s + v + " ";
            return s;
        }
        int[] a;
    }
    #endregion

    #region Задание №2б. Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
    class MyArrayTask2b
    {
        public void WriteToArrayList (string FileName)
        {
            if (File.Exists(FileName))
            {
                StreamWriter writerAll = new StreamWriter(FileName, false);
                writerAll.WriteLine(a.Length);
                writerAll.Close();
                StreamWriter writer = new StreamWriter(FileName, true);
                for (int i = 0; i < a.Length; i++)
                {
                    writer.WriteLine(a[i]);
                }
                writer.Close();
            }
            else
                throw new FileNotFoundException();
        }
        public int[] LoadFiletoArray(string FileName)
        {
            if (File.Exists(FileName))
            {
                StreamReader reader = new StreamReader(FileName);
                int n = Convert.ToInt32(reader.ReadLine());
                a = new int[n];
                for (int i = 0; i < n; i++)
                {
                    int.TryParse(reader.ReadLine(), out int num);
                    a[i] = num;
                }
                reader.Close();
                return a;
            }
            else
                throw new FileNotFoundException();
        }
        public void Multi(int m)
        {
            for (int i = 0; i < a.Length; i++)
                a[i] *= m;
        }
        public void Invers()
        {
            for (int i = 0; i < a.Length; i++)
                a[i] *= -1;

        }
        public int MaxCount
        {
            get
            {
                int count = 0;
                int max = 0;
                int indexer = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    if (max < a[i])
                    {
                        max = a[i];
                        indexer = i;
                    }
                }
                for (int i = 0; i < a.Length; i++)
                {
                    if (max == a[i])
                        count++;
                }
                return count;
            }
        }
        public int Sum
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < a.Length; i++)
                    sum += a[i];
                return sum;
            }
        }

        public void PrintArray ()
        {
            for (int i = 0; i < a.Length; i++)
                Console.Write($"{a[i]} ");
            Console.WriteLine();
        }
        public void PrintArray (string message)
        {
            Console.WriteLine(message);
            PrintArray();
        }
        public MyArrayTask2b()
        {

        }
        int[] a;
    }
    #endregion

    #region Задание №3.
    class MyArrayTask3
    {
        
        public string [] LoadFileToArryaTask3(string FileName)
        {
            StreamReader reader = new StreamReader(FileName);
            if (File.Exists(FileName))
            {
                try
                {
                    int n = Convert.ToInt32((reader.ReadLine()));
                    a = new string[n];
                    for (int i = 0; i < a.Length; i++)
                    {
                        a[i] = reader.ReadLine();
                    }
                    return a;
                }
                catch
                {
                    throw new ArgumentException();
                }
                
            }
            else
                throw new FileNotFoundException();
            
        }

        public bool PasswordConf(string login, string password)
        {
            if (a[0] == login && a[1] == password)
                return true;
            else
                return false;
        }
        public MyArrayTask3()
        {

        }
        string[] a;
    }
    #endregion

    #region Задание №4а. Реализовать класс для работы с двумерным массивом
    class MyClassToTask4a
    {
        public MyClassToTask4a(int stroka, int stolbec)
        {
            a = new int[stroka, stolbec];
            Random rnd = new Random();
            for(int i=0; i < stroka; i++)
            {
                for(int j = 0; j < stolbec; j++)
                {
                    a[i, j] = rnd.Next(-50, 50);
                }
            }
        }
        #region Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
        public void WriteToArrayList(string FileName)
        {
            if (File.Exists(FileName))
            {
                StreamWriter writerAll = new StreamWriter(FileName, false);
                writerAll.WriteLine(a.GetLength(0));
                writerAll.Close();
                StreamWriter writer = new StreamWriter(FileName, true);
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for(int j=0; j < a.GetLength(1); j++)
                        writer.WriteLine(a[i,j]);
                }
                writer.Close();
            }
            else
                throw new FileNotFoundException();
        }
        public int[,] LoadFiletoArray(string FileName)
        {
            if (File.Exists(FileName))
            {
                try 
                {
                    StreamReader reader = new StreamReader(FileName);
                    int n = Convert.ToInt32(reader.ReadLine());
                    a = new int[n, n];
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            int.TryParse(reader.ReadLine(), out int num);
                            a[i, j] = num;
                        }
                    }
                    reader.Close();
                    return a;
                }

                catch
                {
                    throw new ArgumentException();
                }
                
            }
            else
                throw new FileNotFoundException();
        }
        public void Invers()
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for(int j = 0; j < a.GetLength(1); j++)
                {
                    a[i,j] *= -1;
                }
            }
                
        }
            #endregion
            public void Sum (out int Sum)
        {
            Sum = 0;
            for(int i=0;i< a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    Sum += a[i, j];
            }
        } 
        public void DefSum(ref int value, out int Sum)
        {
            Sum = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    if(a[i,j]>value)
                        Sum += a[i, j];
            }
        }
        public void Min(out int min)
        {
            min =a[0, 0];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    if (a[i, j] < min)
                        min = a[i, j];
            }
        }
        public void MaxAndIndex(out int max, out int indexI, out int indexJ)
        {
            max = 0;
            indexI = 0;
            indexJ = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    if (a[i, j] > max)
                    {
                        max = a[i, j];
                        indexI = i;
                        indexJ = j;
                    } 
            }
        }
        public MyClassToTask4a()
        {

        }
        public void Print()
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    Console.Write($"{a[i, j]} ");
                Console.WriteLine();
            }
        }
        public void Print(string messsage)
        {
            Console.WriteLine(messsage);
            Print();
        }
        int[,] a;
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            #region Задание №1.
            Console.WriteLine("Задание №1. Найти пары чисел, которые делятся на 3.\n");
            try
            {
                Console.Write("Введите размерность массива: ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите начальное значение диапазона: ");
                int min = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите максимальное значение диапазона: ");
                int max = Convert.ToInt32(Console.ReadLine());
                MyArrayTask1 Task1 = new MyArrayTask1(a, min, max);
                Console.WriteLine(Task1.ToString());
                Console.WriteLine(Task1.Couple);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            #endregion

            #region Задание №2а. Дописать клас для работы с одномерным массивом
            try
            {
                Console.WriteLine("Задание №2а. Дописать клас для работы с одномерным массивом");
                Console.WriteLine("Необходимо ввести размерность массива, начальное значение и шаг");

                Console.Write("Введите размерность массива: ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите начальное значение: ");
                int start = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите шаг: ");
                int step = Convert.ToInt32(Console.ReadLine());

                MyArrayTask2a Task2a = new MyArrayTask2a(a,start,step);
                Console.WriteLine($"Заполненный массив: {Task2a}");
                Console.WriteLine($"Сколько раз встречается максимальное число: {Task2a.MaxCount}");
                Task2a.Invers();
                Console.WriteLine($"Массив со сменой знака: {Task2a}");
                Console.WriteLine($"Сумма всех элементов: {Task2a.Sum}");

                Console.Write("На какое число Вы хотите умножить элементы массива?: ");
                int mult = Convert.ToInt32(Console.ReadLine());
                Task2a.Multi(mult);
                Console.WriteLine($"Умноженный массив: {Task2a}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            #endregion

            #region Задание №2б. Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
            try
            {
                MyArrayTask2b Task2b = new MyArrayTask2b();
                string FilePuth = AppDomain.CurrentDomain.BaseDirectory + "FileArrayList.txt";
                var b = Task2b.LoadFiletoArray(FilePuth);
                Task2b.PrintArray("Массив из файла:");
                Console.Write("Введите число, на которое необходимо будет умножить каждые элемент: ");
                int chislo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Сумма элементов равна: {Task2b.Sum}");
                Task2b.Invers();
                Task2b.PrintArray("Массив после инверсии");
                Task2b.Multi(chislo);
                Task2b.PrintArray($"Mассив после умноженния на введённое число {chislo}");
                Task2b.WriteToArrayList(FilePuth);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            #endregion

            #region Задание №3.
            string FilePuthPassw = AppDomain.CurrentDomain.BaseDirectory + "Password.txt";
            MyArrayTask3 Task3 = new MyArrayTask3();
            var check = Task3.LoadFileToArryaTask3(FilePuthPassw);
            int count = 0;
            do
            {
                Console.Write("Введите логин: ");
                string login = Console.ReadLine();
                Console.Write("Введите пароль: ");
                string password = Console.ReadLine();
                if (Task3.PasswordConf(login, password) == true)
                {
                    Console.WriteLine("поздравляем! Вы успешно авторизовались!");
                    break;
                }
                else
                {
                    Console.WriteLine("Вы неверно ввели логин или пароль!");
                    count++;
                }

            }
            while (count < 3);
            if (count == 3)
                Console.WriteLine($"Вы ввели {count} раза неправильный логин или пароль!\nВ авторизации Отказано!");
            #endregion
            
            #region Задание №4. Реализовать класс для работы с двумерным массивом

            try
            {
                Console.Write("Введите количество строк: ");
                int stroka = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите количество столбцов: ");
                int stolbec = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите число, для рассчёта суммы элементов, которые больше: ");
                int x = Convert.ToInt32(Console.ReadLine());
                MyClassToTask4a Task4a = new MyClassToTask4a(stroka, stolbec);
                Task4a.Print();
                Task4a.Sum(out int summa);
                Task4a.DefSum(ref x, out int summaMax);
                Task4a.Min(out int min);
                Task4a.MaxAndIndex(out int max, out int indexi, out int indexj);
                Console.WriteLine($"Сумма элементов массива: {summa}");
                Console.WriteLine($"Сумма элементов массива: {summaMax}, которые больше заданного числа {x}");
                Console.WriteLine($"Минимальный элемент массива: {min}");
                Console.WriteLine($"Максимальный элемент массива находится по адресу a[{indexi},{indexj}], его значение: {max}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            #endregion 
            
            #region Задание №4б. Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
            
            try
            {
                string FilePuth = AppDomain.CurrentDomain.BaseDirectory + "ArrayTwoDim.txt";
                MyClassToTask4a Task4b = new MyClassToTask4a();
                var b = Task4b.LoadFiletoArray(FilePuth);
                Console.Write("Введите число, для рассчёта суммы элементов, которые больше: ");
                int x = Convert.ToInt32(Console.ReadLine());
                Task4b.Print("Новый массив, считанный из файла");
                Task4b.Sum(out int summa);
                Task4b.DefSum(ref x, out int summaMax);
                Task4b.Min(out int min);
                Task4b.MaxAndIndex(out int max, out int indexi, out int indexj);
                Console.WriteLine($"Сумма элементов массива: {summa}");
                Console.WriteLine($"Сумма элементов массива: {summaMax}, которые больше заданного числа {x}");
                Console.WriteLine($"Минимальный элемент массива: {min}");
                Console.WriteLine($"Максимальный элемент массива находится по адресу a[{indexi},{indexj}], его значение: {max}");
                Task4b.Invers();
                Task4b.WriteToArrayList(FilePuth);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            #endregion
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_In_Task
{
    class Program
    {
        public static int[] arr = new int[] { 2, 2, -1, 10, 15 };
        static void DateAndTime()
        {
            Console.WriteLine(DateTime.Now);
        }
        static void Counter(int start, int finish)
        {
            for (int i = start; i < finish; i++)
            {
                Console.WriteLine(i);
            }
        }
        static void RemoveDublicate(Task t)
        {
            arr = arr.Distinct().ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
        static void SortArrays(Task t)
        {
            arr = arr.OrderBy(l=>l).ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
        static void BinarySearch(Task t)
        {
            int arrays = Array.BinarySearch(arr, 5);
            for (int i = 0; i < arrays; i++)
            {
                Console.WriteLine(i);
            }
        }
        //Array.binar
        static void Sum()
        {
            int min = arr.Min();
            Console.WriteLine(min);
            int max = arr.Max();
            Console.WriteLine(max);
            double avg = arr.Average();
            Console.WriteLine(avg);
            int sum = arr.Sum();
            Console.WriteLine(sum);
        }

        static void Main(string[] args)
        {
            // task 1.1
            //Task task1 = new Task(DateAndTime);
            //task1.Start();
            // task 1.2
            //Task task2 = Task.Factory.StartNew(DateAndTime);
            // task 1.3
            //Task task3 = Task.Run(DateAndTime);
            // task 2.1
            // task 3.1
            //Task task4 = Task.Factory.StartNew(() => Counter(5, 15));
            // task 4.1
            //Task task5 = Task.Factory.StartNew(Sum);
            // tasks
            //Task[] tasks = new Task[5] { task1, task2, task3, task4, task5};
            //Task.WaitAll(tasks);
            // task 5
            Task task6 = new Task(() =>
            {
                Console.WriteLine($"Last Task {Task.CurrentId}");
                Thread.Sleep(2000);
            });
            Task task7 = task6.ContinueWith(RemoveDublicate).ContinueWith(SortArrays).ContinueWith(BinarySearch);
            
            Console.ReadKey();
        }
    }
}

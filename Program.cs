using System;
using System.Threading.Tasks;

public class Program
{
//סעיף א
    static async Task<int> printC(ConsoleColor color, int start, int end)
    {
        int numOfIterations = end - start;

        for (int i = start; i < end; i++)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(i);

            await Task.Delay(100);
        }

        Console.ResetColor();

        return numOfIterations;
    }


    static async Task MainThread(string[] args)
    {
        Task<int> task1 = printC(ConsoleColor.Red, 1, 10);
        Task<int> task2 = printC(ConsoleColor.Blue, 20, 30);

        int result1 = await task1;
        int result2 = await task2;

        Console.WriteLine("Task 1 iterations: " + result1);
        Console.WriteLine("Task 2 iterations: " + result2);
    }

//סעיף ב

    static int printCThread(ConsoleColor color, int start, int end)
    {
        int numOfIterations = end - start;

        for (int i = start; i < end; i++)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(i);

            Thread.Sleep(100);
        }

        Console.ResetColor();

        return numOfIterations;
    }

    static void Main(string[] args)
    {
        Thread thread1 = new Thread(() =>
        { 
            Task<int> result = printC(ConsoleColor.Red, 1, 10);
            Console.WriteLine("Thread 1 iterations: " + result);
        });

        Thread thread2 = new Thread(() =>
        {
            Task<int> result = printC(ConsoleColor.Blue, 20, 30);
            Console.WriteLine("Thread 2 iterations: " + result);
        });

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();
    }
}


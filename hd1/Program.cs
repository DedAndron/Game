using System.Collections.Concurrent;
using System.Net.Sockets;

namespace SystemPrograming
{
    internal class Program
    {
        private static int N = 10;
        //static int count = 0;
        //static readonly object locker = new object();
        //static Mutex _mutex = new Mutex();
        //static Mutex mutex = new Mutex(false, "Global\\MyLogMutex");

        //task1
        static void Main(string[] args)
        {
            ConcurrentQueue<Client> clients = new ConcurrentQueue<Client>();
            for (int i = 0; i < N; i++)
            {
                int local = i;
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    clients.Enqueue(new Client($"Client {local + 1}", $"Description for Client {local + 1}"));
                });
                Console.WriteLine($"Client {local + 1} added to the queue");
            }
            Thread mainthread = new Thread(() =>
            {
                foreach (var client in clients)
                {
                    Console.WriteLine($"Processing {client.Name}");
                    Thread.Sleep(1000);
                }
                Console.WriteLine("All clients processed");
            });
            mainthread.Start();
            mainthread.Join();
            //var account = new BankAccount(1000);

            //Thread t1 = new Thread(() =>
            //{
            //    for (int i = 0; i < 5; i++)
            //    {
            //        account.Deposit(100);
            //        Thread.Sleep(100);
            //    }
            //});

            //Thread t2 = new Thread(() =>
            //{
            //    for (int i = 0; i < 5; i++)
            //    {
            //        account.Withdraw(50);
            //        Thread.Sleep(100);
            //    }
            //});

            //Thread t3 = new Thread(() =>
            //{
            //    Thread.Sleep(300);
            //    account.Block();
            //});

            //t1.Start();
            //t2.Start();
            //t3.Start();

            //t1.Join();
            //t2.Join();
            //t3.Join();

            //Console.WriteLine($"Final balance: {account.GetBalance()}");

            ////task2

            //int ordersCount = 10;
            //CountdownEvent countdown = new CountdownEvent(ordersCount);

            //for (int i = 1; i <= ordersCount; i++)
            //{
            //    ThreadPool.QueueUserWorkItem(ProcessOrder, new Tuple<int, CountdownEvent>(i, countdown));
            //}
            //countdown.Wait();

            //Console.WriteLine("All orders processed");

            //Thread t1 = new Thread(Increment);
            //Thread t2 = new Thread(Increment);

            //t1.Start();
            //t2.Start();

            //t1.Join();
            //t2.Join();

            //Console.WriteLine($"Final counter: {count}");
            //for (int i = 0; i < 10; i++)
            //{
            //    WriteToFile($"Process {Environment.ProcessId} - message {i}");
            //    Thread.Sleep(500);
            //}

            //Console.WriteLine("Done");
        }
        static void ProcessOrder(object state)
        {
            var data = (Tuple<int, CountdownEvent>)state;
            int orderId = data.Item1;
            CountdownEvent countdown = data.Item2;

            Thread.Sleep(new Random().Next(500, 1500));

            Console.WriteLine($"Order {orderId} processed on stream {Thread.CurrentThread.ManagedThreadId}");

            countdown.Signal(); // уменьшаем счётчик
        }
        //static void WriteToFile(string text)
        //{
        //    mutex.WaitOne();

        //    try
        //    {
        //        File.AppendAllText("log.txt", text + Environment.NewLine);
        //    }
        //    finally
        //    {
        //        mutex.ReleaseMutex();
        //    }
        //}
        //static void Increment()
        //{
        //    for (int i = 0; i < 100000; i++)
        //    {
        //        //lock (locker)
        //        //{
        //        //    count++;
        //        //}
        //        _mutex.WaitOne();
        //        count++;
        //        _mutex.ReleaseMutex();
        //    }
        //}
    }
}

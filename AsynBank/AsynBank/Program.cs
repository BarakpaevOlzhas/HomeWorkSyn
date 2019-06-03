using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopTime = DateTime.Now.AddMinutes(1);
            var threads = new Thread[20];
            var bank = new Bank(2000);

            for (int i = 0; i < threads.Length; i++)
            {
                var thread = new Thread(bank.ChangeSum);
                thread.Name = $"Поток номер { thread.ManagedThreadId}";
                threads[i] = thread;
            }

            foreach (var i in threads)
            {
                i.Start();
            }

            Console.Read();
        }
    }
}

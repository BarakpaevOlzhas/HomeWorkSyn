using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynBank
{
    public class Bank
    {
        private int moneу;

        private object lockObgect = new object();

        private int minute = 0;

        private Timer timer;

        private DateTime stopTime;

        public Bank(int moneyTwo)
        {
            moneу = moneyTwo;
            TimerCallback timerCallback = new TimerCallback(ChangeSum);
            timer = new Timer(timerCallback, 0, 0, 5);
            stopTime = DateTime.Now.AddSeconds(60);
            
        }

        public void ChangeSum(object objectL)
        {
            if (stopTime > DateTime.Now)
            {
                //lock (lockObgect)
                //{
                    var currentThread = Thread.CurrentThread;                   

                    var random = new Random();
                    int number = random.Next(0,100);

                Console.WriteLine($"{currentThread.ManagedThreadId} было {moneу}");

                if (number <= 50)
                    {
                        moneу += 500;
                    }
                    else
                    {
                        moneу -= 500;
                    }

                Console.WriteLine($"{currentThread.ManagedThreadId} изменил {moneу}");

                Thread.Sleep(1000);

                    minute += 5;

                    Console.WriteLine($"\n");
                //}
            }
            else
            {
                timer.Dispose();
            }          

        }
    }
}

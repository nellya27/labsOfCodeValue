using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queues
{
    public class TaskBuilder
    {
        public const int maxQueueSize= 4;
        private LimitedQueue<string> newLimitedQueue = new LimitedQueue<string>(maxQueueSize);

        public void TestTask()
        {
            int limitCount = 0;
            int numberOfTask = 0;
            Random random = new Random();

           
                while ((limitCount < maxQueueSize)&&(numberOfTask<20))
                {
                    if (maxQueueSize == random.Next(2, 5))
                    {
                        limitCount++;
                        Thread.Sleep(2000);
                        Task newTask1 = Task.Factory.StartNew(() => AddToQueue(Task.CurrentId.ToString()));
                    }
                    else if(limitCount>0)
                    {
                        limitCount--;
                        Thread.Sleep(2000);
                        Task newTask2 = Task.Factory.StartNew(() => GetQueueData());
                    }
                numberOfTask++;
                }

            newLimitedQueue.Dispose();
        }
        
        public void AddToQueue(string id)
        {
           
          newLimitedQueue.Enque(id);
            Console.WriteLine("{0} item entered the queue", id);         
        }

        public void GetQueueData()
        {
            string data = newLimitedQueue.Deque();
            Thread.Sleep(2000);
            Console.WriteLine("item {0} got out of the queue",data);
           
        }
             
    }
}

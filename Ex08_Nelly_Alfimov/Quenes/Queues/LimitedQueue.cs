using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queues
{

    public class LimitedQueue<T>:IDisposable
    {
        private Queue<T> limitedQueue = new Queue<T>();
        private Semaphore semaphore;

       public LimitedQueue(int maxQueueSize)
        {
          semaphore = new Semaphore(0, maxQueueSize);
         
        }
        
        public void Enque(T item)
        {

            lock(limitedQueue)
            {
                limitedQueue.Enqueue(item);
               
            }
            try
            {
                semaphore.Release();
            }
            catch(SemaphoreFullException e)
            {
                Thread.Sleep(2000);
                Console.WriteLine(e.Message);
            }
        }

        public T Deque()
        {
            semaphore.WaitOne();
            lock(limitedQueue)
            {              
              return limitedQueue.Dequeue();
            }           
        }

        public void Dispose()
        {
            if (semaphore != null)
            {
                semaphore.Close();
                semaphore = null;
            }
        }
    }
}

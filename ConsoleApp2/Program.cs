using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    // lock (object 객체명을 사용하여 처리하는 예 1
    class Test
    {
        static object obj = new object();
        static int Count; //공유자원

        public void ThreadProc()
        {
            lock (obj)
            {

            
                for (int i = 0; i < 10; i++)
                {
                    Count++;
                    Console.WriteLine("Thread ID: {0}  result: {1}",
                                        Thread.CurrentThread.GetHashCode(), Count);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            Thread th1 = new Thread(new ThreadStart(test.ThreadProc));
            Thread th2 = new Thread(new ThreadStart(test.ThreadProc));
            th1.Start();
            th2.Start();
        }
    }
}

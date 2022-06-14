using System;
using System.Threading;

public class MutexTest
{
    public static void Exec()
    {
        MutexTest p = new MutexTest();
        p.Example();
        Console.ReadKey();
    }

    private static readonly Mutex mutex = new Mutex();

    public void Example()
    {
        //Create mumber of thread to explain muiltiple thread example  
        for (int i = 0; i < 4; i++)
        {
            var t = new Thread(MutexDemo);
            t.Name = string.Format("Thread {0} :", i + 1);
            t.Start();
        }
    }
    //Method to implement syncronization using Mutex  
    static void MutexDemo()
    {
        try
        {
            //Blocks the current thread until the current WaitHandle receives a signal.   
            mutex.WaitOne();   // Wait until it is safe to enter.  
            Console.WriteLine("{0} has entered in the Domain", Thread.CurrentThread.Name);
            Thread.Sleep(1000);    // Wait until it is safe to enter.  
            Console.WriteLine("{0} is leaving the Domain\r\n", Thread.CurrentThread.Name);
        }
        finally
        {
            //ReleaseMutex unblock other threads that are trying to gain ownership of the mutex.  
            mutex.ReleaseMutex();
        }
    }
}
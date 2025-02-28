using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Toic.AsyncUtilities;

namespace Toic.Demos
{
    public class ExecuteOnDifferentThreadExtensionDemo
    {
        public ExecuteOnDifferentThreadExtensionDemo()
        { 
        
        
        }

        // Synchronous instance method
        public static void SynchronousMethod()
        {
            Console.WriteLine($"SynchronousMethod is running on thread {Thread.CurrentThread.ManagedThreadId}");
            // Simulate work
            Thread.Sleep(1000);
            Console.WriteLine("SynchronousMethod has completed.");
        }

        // Asynchronous instance method
        public static async Task AsynchronousMethod()
        {
            Console.WriteLine($"AsynchronousMethod is running on thread {Thread.CurrentThread.ManagedThreadId}");
            // Simulate asynchronous work
            await Task.Delay(1000);
            Console.WriteLine("AsynchronousMethod has completed.");
        }

        public static async Task RunTaskDemo()
        {
            await ExecuteOnDifferentThreadExtension.ExecuteOnDifferentThread(() => Console.WriteLine("Hello, World!"));

            Func<Task> func = async () =>
            {
                await Task.Delay(100);
                Console.WriteLine("Hello, World!");
            };

            await func.ExecuteOnDifferentThread();

            await AsynchronousMethod().ExecuteOnDifferentThread();
        }

    }
}

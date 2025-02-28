using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toic.AsyncUtilities
{
    public static class ExecuteOnDifferentThreadExtension
    {
        public static async Task ExecuteOnDifferentThread(this Action action)
        {
            await Task.Run(action);
        }

        public static async Task<T> ExecuteOnDifferentThread<T>(this Func<T> func)
        {
            return await Task.Run(func);
        }

        public static async Task ExecuteOnDifferentThread(this Func<Task> func)
        {
            await Task.Run(func);
        }

        public static async Task<T> ExecuteOnDifferentThread<T>(this Func<Task<T>> func)
        {
            return await Task.Run(func);
        }

        public static async Task ExecuteOnDifferentThread(this Task task)
        {
            await Task.Run(async () => await task);
        }

        public static async Task<T> ExecuteOnDifferentThread<T>(this Task<T> task)
        {
            return await Task.Run<T>(async () => await task);
        }
    }
}

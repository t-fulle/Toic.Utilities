using System;
using System.Threading;
using System.Threading.Tasks;
using Toic.AsyncUtilities;
using Xunit;
namespace Toic.AsyncUtilities
{
    public class ExecuteOnDifferentThreadExtensionTests
    {
        [Fact]
        public async Task ExecuteOnDifferentThread_Action_ExecutesOnDifferentThread()
        {
            // Arrange
            int initialThreadId = Thread.CurrentThread.ManagedThreadId;
            int actionThreadId = initialThreadId;

            Action action = () => { actionThreadId = Thread.CurrentThread.ManagedThreadId; };

            // Act
            await action.ExecuteOnDifferentThread();

            // Assert
            Assert.NotEqual(initialThreadId, actionThreadId);
        }

        [Fact]
        public async Task ExecuteOnDifferentThread_FuncWithResult_ExecutesOnDifferentThread()
        {
            // Arrange
            int initialThreadId = Thread.CurrentThread.ManagedThreadId;
            int funcThreadId = initialThreadId;

            Func<int> func = () =>
            {
                funcThreadId = Thread.CurrentThread.ManagedThreadId;
                return 42;
            };

            // Act
            int result = await func.ExecuteOnDifferentThread();

            // Assert
            Assert.NotEqual(initialThreadId, funcThreadId);
            Assert.Equal(42, result);
        }

        [Fact]
        public async Task ExecuteOnDifferentThread_FuncTask_ExecutesOnDifferentThread()
        {
            // Arrange
            int initialThreadId = Thread.CurrentThread.ManagedThreadId;
            int funcThreadId = initialThreadId;

            Func<Task> func = async () =>
            {
                await Task.Delay(100);
                funcThreadId = Thread.CurrentThread.ManagedThreadId;
            };

            // Act
            await func.ExecuteOnDifferentThread();

            // Assert
            Assert.NotEqual(initialThreadId, funcThreadId);
        }

        [Fact]
        public async Task ExecuteOnDifferentThread_Task_ExecutesOnDifferentThread()
        {
            // Arrange
            int initialThreadId = Thread.CurrentThread.ManagedThreadId;
            int funcThreadId = initialThreadId;

            Func<Task> func = async () =>
            {
                await Task.Delay(100);
                funcThreadId = Thread.CurrentThread.ManagedThreadId;
            };

            // Act
            await func.ExecuteOnDifferentThread();

            // Assert
            Assert.NotEqual(initialThreadId, funcThreadId);
        }

        [Fact]
        public async Task ExecuteOnDifferentThread_FuncTaskWithResult_ExecutesOnDifferentThread()
        {
            // Arrange
            int initialThreadId = Thread.CurrentThread.ManagedThreadId;
            int funcThreadId = initialThreadId;

            Func<Task<int>> func = async () =>
            {
                await Task.Delay(100);
                funcThreadId = Thread.CurrentThread.ManagedThreadId;
                return 42;
            };

            // Act
            int result = await func.ExecuteOnDifferentThread();

            // Assert
            Assert.NotEqual(initialThreadId, funcThreadId);
            Assert.Equal(42, result);
        }

        [Fact]
        public async Task ExecuteOnDifferentThread_Action_ThrowsException()
        {
            // Arrange
            Action action = () => throw new InvalidOperationException("Test exception");

            // Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => action.ExecuteOnDifferentThread());
            Assert.Equal("Test exception", exception.Message);
        }

        [Fact]
        public async Task ExecuteOnDifferentThread_FuncWithResult_ThrowsException()
        {
            // Arrange
            Func<int> func = () => throw new InvalidOperationException("Test exception");

            // Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => func.ExecuteOnDifferentThread());
            Assert.Equal("Test exception", exception.Message);
        }

        [Fact]
        public async Task ExecuteOnDifferentThread_FuncTask_ThrowsException()
        {
            // Arrange
            Func<Task> func = async () =>
            {
                await Task.Delay(100);
                throw new InvalidOperationException("Test exception");
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => func.ExecuteOnDifferentThread());
            Assert.Equal("Test exception", exception.Message);
        }

        [Fact]
        public async Task ExecuteOnDifferentThread_FuncTaskWithResult_ThrowsException()
        {
            // Arrange
            Func<Task<int>> func = async () =>
            {
                await Task.Delay(100);
                throw new InvalidOperationException("Test exception");
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => func.ExecuteOnDifferentThread());
            Assert.Equal("Test exception", exception.Message);
        }

        [Fact]
        public async Task ExecuteOnDifferentThread_Task_ShouldRunOnDifferentThread()
        {
            int originalThreadId = Thread.CurrentThread.ManagedThreadId;
            int executionThreadId = originalThreadId; // Initialize with the same thread ID

            async Task TestMethod()
            {
                executionThreadId = Thread.CurrentThread.ManagedThreadId;
            }

            await TestMethod().ExecuteOnDifferentThread();

            Assert.NotEqual(originalThreadId, executionThreadId);
        }

        [Fact]
        public async Task ExecuteOnDifferentThread_TaskWithResult_ShouldRunOnDifferentThreadAndReturnCorrectValue()
        {
            int originalThreadId = Thread.CurrentThread.ManagedThreadId;
            int executionThreadId = originalThreadId; // Initialize with the same thread ID

            async Task<int> TestMethod()
            {
                executionThreadId = Thread.CurrentThread.ManagedThreadId;
                return 42; // Some return value
            }

            int result = await TestMethod().ExecuteOnDifferentThread();

            Assert.NotEqual(originalThreadId, executionThreadId);
            Assert.Equal(42, result); // Ensure the returned value is correct
        }
    }
}
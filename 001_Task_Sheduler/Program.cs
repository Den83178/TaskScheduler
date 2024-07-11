namespace _001_Task_Sheduler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 45);
            Console.WriteLine($"Id thread method Main - {Thread.CurrentThread.ManagedThreadId}");

            Task[] tasks = new Task[10];
            ReviewTaskScheduler reviewTaskScheduler = new ReviewTaskScheduler();
            
            QueueTaskTesting(tasks, reviewTaskScheduler);
            // TryExecuteTaskInLineTesting(task, reviewTaskScheduler);
            // TryDequeueTesting(task, reviewTaskScheduler);

            try 
            {
                Task.WaitAll(tasks);
            }
            catch
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Several tasks was canceled");
                Console.ResetColor();
            }
            finally
            {
                Console.WriteLine($"Method Main finished his execute");
            }
            Console.ReadKey();
        }

        private static void QueueTaskTesting(Task[] tasks, TaskScheduler scheduler)
        {
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = new Task(() =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"Task {Task.CurrentId} executed in thread {Thread.CurrentThread.ManagedThreadId}\n");
                });

                tasks[i].Start(scheduler);
            }
        }
    }
}

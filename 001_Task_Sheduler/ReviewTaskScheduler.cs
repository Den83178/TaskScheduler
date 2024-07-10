using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_Task_Sheduler
{
    internal class ReviewTaskScheduler : TaskScheduler
    {
        private LinkedList<Task> tasksList = new LinkedList<Task>();
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return tasksList;
        }
        protected override void QueueTask(Task task)
        {
            Console.WriteLine($"             [QueueTask] Task #{task.Id} entered in the queue");
            tasksList.AddLast(task);
            ThreadPool.QueueUserWorkItem(ExecuteTasks, null);
            // ExecuteTasks(null);
        }

        protected override bool TryDequeue(Task task)
        {
            Console.WriteLine($"      [TryDequeue] attempt delete Task {task.Id}");
            bool result = false;

            lock (tasksList)
            {
                result = tasksList.Remove(task);
            }

            if (result == true)
            {
                Console.WriteLine($"   [TryDequeue] Task {task.Id} was deleted from the queue");
            }
            return result;
        }


        private void ExecuteTasks(object _)
        {
            while (true)
            {
                //Thread.Sleep(2000);     // Delete comments = TryExecuteInLine
                Task task = null;

                lock (tasksList)
                {
                    if (tasksList.Count == null)
                    {
                        break;
                    }
                    task = tasksList.First.Value;
                    tasksList.RemoveFirst();
                }
                if(task == null)
                {
                    break;
                }
                base.TryExecuteTask(task);
            }
        }
    }




}

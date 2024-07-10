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
            Console.WriteLine($"             [QueueTask] Task #{task.Id} entered in queue");
            tasksList.AddLast(task);
            ThreadPool.QueueUserWorkItem(ExecuteTasks, null);
            // ExecuteTasks(null);
        }


        private void ExecuteTask(object _)
        {
            while (true)
            {
                Task task = null;

                lock (tasksList)
                {
                    if (tasksList.Count == null)
                    {

                    }
                }
            }
        }
    }




}

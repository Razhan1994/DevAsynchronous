namespace DevAsynchronous
{
    public static class TaskWhenAllWithSequence
    {
        public static async Task ProcessAllTasks()
        {
            Task<int> task1 = DelayAndReturnAsync(2);
            Task<int> task2 = DelayAndReturnAsync(3);
            Task<int> task3 = DelayAndReturnAsync(1);

            Task<int>[] tasks = new[] { task1, task2, task3 };

            IEnumerable<Task> taskQuery = from t in tasks select AwaitAndProcessTaskAsync(t);

            Task[] processingTasks = taskQuery.ToArray();

            await Task.WhenAll(processingTasks);
        }

        static async Task<int> DelayAndReturnAsync(int value)
        {
            await Task.Delay(TimeSpan.FromSeconds(value));

            return value;
        }

        static async Task AwaitAndProcessTaskAsync(Task<int> task)
        {
            int result = await task;
            
            Console.WriteLine(result);
        }
    }
}

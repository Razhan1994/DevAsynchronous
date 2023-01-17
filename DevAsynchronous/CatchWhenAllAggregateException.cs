namespace DevAsynchronous
{
    public static class CatchWhenAllAggregateException
    {
        public static async Task CatchAggregateException()
        {
            var task1 = NotSupportedException();
            var task2 = NotImplementedException();
            var task3 = InvalidOperationException();

            var allTask = Task.WhenAll(task1, task2, task3);
            try
            {
                await allTask;
            }
            catch
            {
                var aggregateException = allTask.Exception;
                throw aggregateException;
            }
        }

        static async Task NotSupportedException()
        {
            throw new NotSupportedException();
        }

        static async Task NotImplementedException()
        {
            throw new NotImplementedException();
        }

        static async Task InvalidOperationException()
        {
            throw new InvalidOperationException();
        }
    }
}

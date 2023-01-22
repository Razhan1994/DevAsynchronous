namespace DevAsynchronous
{
    public static class HandleExceptions
    {
        public static async Task HandleThrownExceptions()
        {
            Task task = ThrowExceptionAsync();

            try
            {
                await task;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        static async Task ThrowExceptionAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));

            throw new InvalidOperationException("test");
        }
    }
}

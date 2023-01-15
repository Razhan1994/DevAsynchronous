namespace DevAsynchronous
{
    public static class MethodTaskRun
    { 
        public static Task RunActions()
        {
            Task.Run(async () =>
            {
                int i = 0;
                while (i++ < 10)
                {
                    Action2(i);
                    Action3(i);
                }
            });

            return Task.CompletedTask;
        }

        static Task Action2(int i)
        {
            Task.Delay(3000);
            Console.WriteLine($"{DateTime.Now} action2 {i}");

            return Task.CompletedTask;
        }

        static async Task Action3(int i)
        {
            await Task.Delay(3000);
            Console.WriteLine($"{DateTime.Now} action3 {i}");
        }
    }
}

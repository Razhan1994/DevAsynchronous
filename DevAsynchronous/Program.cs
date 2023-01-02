

// See https://aka.ms/new-console-template for more information

Console.WriteLine(DateTime.Now);
RunActions();
//Action1();
//Console.WriteLine(DateTime.Now);
//await Action2();
//Console.WriteLine(DateTime.Now);

Console.ReadKey();

Task RunActions()
{
    Task.Run(() =>
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

void Action1()
{
    Thread.Sleep(3000);
    Console.WriteLine(DateTime.Now + " action 1");
}

Task Action2(int i)
{
    Task.Delay(3000);
    Console.WriteLine($"{DateTime.Now} action2 {i}");
    
    return Task.CompletedTask;
}

async Task Action3(int i)
{
    await Task.Delay(3000);
    Console.WriteLine($"{DateTime.Now} action3 {i}");
}
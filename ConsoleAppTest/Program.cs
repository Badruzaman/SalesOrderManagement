
test();
async Task test()
{
     LongProcess();
     ShortProcess();
    Console.ReadKey();
}
 async Task LongProcess()
{
    Console.WriteLine("LongProcess Started");
    Thread.Sleep(3000); 
    Console.WriteLine("LongProcess Completed");
}

 async Task ShortProcess()
{
    Console.WriteLine("ShortProcess Started");

    Thread.Sleep(1000);

    Console.WriteLine("ShortProcess Completed");
}
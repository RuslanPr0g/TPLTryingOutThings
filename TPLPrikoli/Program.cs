Task.Factory.StartNew(() => DoVeryImportantWork(1, 3000)).ContinueWith((prev) => DoSomeOtherVeryImportantWork(1, 4000));
Task.Factory.StartNew(() => DoVeryImportantWork(2, 4000)).ContinueWith((prev) => DoSomeOtherVeryImportantWork(2, 3500));
Task.Factory.StartNew(() => DoVeryImportantWork(3, 7000));



Console.ReadKey();

static void DoVeryImportantWork(int id, int mills)
{
    Console.WriteLine($"{id} started!");
    Thread.Sleep(mills);
    Console.WriteLine($"{id} executed!");
}

static void DoSomeOtherVeryImportantWork(int id, int mills)
{
    Console.WriteLine($"{id} more work started!");
    Thread.Sleep(mills);
    Console.WriteLine($"{id} more work executed!");
}
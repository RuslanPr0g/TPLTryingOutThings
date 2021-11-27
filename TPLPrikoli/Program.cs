Task.Factory.StartNew(() => DoVeryImportantWork(1, 3000));
Task.Factory.StartNew(() => DoVeryImportantWork(2, 4000));



Console.ReadKey();

static void DoVeryImportantWork(int id, int mills)
{
    Console.WriteLine($"{id} started!");
    Thread.Sleep(mills);
    Console.WriteLine($"{id} executed!");
}
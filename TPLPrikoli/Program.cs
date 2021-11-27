var t1 = new Task(() => DoVeryImportantWork(1, 3000));
var t2 = new Task(() => DoVeryImportantWork(2, 4000));

t1.Start();
t2.Start();



Console.ReadKey();

static void DoVeryImportantWork(int id, int mills)
{
    Console.WriteLine($"{id} started!");
    Thread.Sleep(mills);
    Console.WriteLine($"{id} executed!");
}
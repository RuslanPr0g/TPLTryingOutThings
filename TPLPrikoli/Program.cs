// canc token
// new can use new Cancc..() but with new we loose the power to cancel things, so that with the source we can cancel and tokens can monitor when operation was canceled
var source = new CancellationTokenSource();

// factory
try
{
    var t1 = Task.Factory.StartNew(() => DoVeryImportantWork(1, 3000, source.Token)).ContinueWith((prev) => DoSomeOtherVeryImportantWork(1, 4000, source.Token));
    //source.Cancel();
    var t2 = Task.Factory.StartNew(() => DoVeryImportantWork(2, 4000, source.Token)).ContinueWith((prev) => DoSomeOtherVeryImportantWork(2, 3500, source.Token));
}
catch (TaskCanceledException canc)
{
    Console.WriteLine("WARNING: THE OPERATION CANCELED!");
}

var t3 = Task.Factory.StartNew(() => DoVeryImportantWork(3, 7000));

// waiting
var tlist = new List<Task> { t3 };
Task.WaitAll(tlist.ToArray());

// ForEachParallel
var intList = new List<int> { 12, 1235, 1, 12312312, 3, 123, 1, 23, 12, 3, 12, 4, 3, 43, 25, 5, 426, 2, 5, 54, 42, 6, 2 };

// Parallel type has built-in WaitAll kinda thing, so that code won't continue untill this method (loop) finishes
Parallel.ForEach(intList, t =>
{
    global::System.Console.WriteLine("Doing parallel: " + t);
});

// wait for closing in the background
Console.WriteLine("Press smth pls");
Console.ReadKey();

static void DoVeryImportantWork(int id, int mills, CancellationToken token = default)
{
    if (token.IsCancellationRequested)
    {
        Console.WriteLine($"{id} cancelled!");
        token.ThrowIfCancellationRequested();
    }
    Console.WriteLine($"{id} started!");
    Thread.Sleep(mills);
    Console.WriteLine($"{id} executed!");
}

static void DoSomeOtherVeryImportantWork(int id, int mills, CancellationToken token = default)
{
    if (token.IsCancellationRequested)
    {
        Console.WriteLine($"{id} more work cancelled!");
        token.ThrowIfCancellationRequested();
    }
    Console.WriteLine($"{id} more work started!");
    Thread.Sleep(mills);
    Console.WriteLine($"{id} more work executed!");
}
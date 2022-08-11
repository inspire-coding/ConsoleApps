public delegate Task<int> LongProcessDelegate(int value);

public class ObjectWithLongProcesses
{
    public static int SomeProperty { get; private set; }

    public static async Task<int> LongProcess1(int value)
    {
        Console.WriteLine("LongProcess1 started");

        await Task.Delay(7000); //hold execution for 7 seconds

        SomeProperty = SomeProperty*2;
        Console.WriteLine($"LongProcess1 - SomeProperty: {SomeProperty}");
        Console.WriteLine("LongProcess1 Completed");

        return 3 * value;
    }

    public static async Task<int> LongProcess2(int value)
    {
        Console.WriteLine("LongProcess2 started");

        await Task.Delay(4000); //hold execution for 4 seconds

        Console.WriteLine($"Has the value of the static property been changed: {SomeProperty == value}");

        SomeProperty = value;
        Console.WriteLine($"LongProcess2 - SomeProperty: {SomeProperty}");
        Console.WriteLine("LongProcess2 Completed");

        return 2 * value;
    }

    static async Task Main(string[] args)
    {

        LongProcessDelegate longProcDelegate1 = new LongProcessDelegate(LongProcess1);

        LongProcessDelegate longProcDelegate2 = new LongProcessDelegate(LongProcess2);

        LongProcessDelegate longProcDelegate = longProcDelegate1 + longProcDelegate2;

        Task<int> result = longProcDelegate(10);

        int valueReturnedByMulticastDelegate = await result;

        Console.WriteLine($"Value returned by multicast delegate: {valueReturnedByMulticastDelegate}");
        Console.WriteLine($"Main - SomeProperty: {SomeProperty}");

        Console.ReadKey();
    }
}
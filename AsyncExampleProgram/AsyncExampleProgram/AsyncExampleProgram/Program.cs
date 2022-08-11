public class AsyncExampleProgram
{
    static async Task Main(string[] args)
    {
        Task<int> result = LongProcess();
        
        ShortProcess();
        
        int val = await result; // Wait until we get the int return value

        Console.WriteLine($"Result: {val}");

        Console.ReadKey();
    }

    static async Task<int> LongProcess()
    {
        Console.WriteLine("LongProcess started");

        await Task.Delay(3000); //hold execution for 3 seconds

        Console.WriteLine("LongProcess Completed");

        return 10;
    }

    static void ShortProcess()
    {
        Console.WriteLine("ShortProcess started");

        // Something that doesn't take very long here

        Console.WriteLine("ShortProcess completed");
    }
}
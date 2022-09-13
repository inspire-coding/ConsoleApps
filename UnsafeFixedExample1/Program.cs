using System;

class Program
{
    static void Main()
    {
        Console.WriteLine(Transform());
        Console.WriteLine(Transform());
        Console.WriteLine(Transform());
    }

    unsafe static string Transform()
    {
        // Get random string.
        string value = "pazpeti";

        // Use fixed statement on a char pointer.
        // ... The pointer now points to memory that won't be moved.
        fixed (char* pointer = value)
        {
            // Add one to each of the characters.
            for (int i = 0; pointer[i] != '\0'; ++i)
            {
                ref var point = ref pointer[i];
                pointer[i]++;
            }
            // Return the mutated string.
            return new string(pointer);
        }
    }
}
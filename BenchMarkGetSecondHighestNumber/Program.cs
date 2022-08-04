class SecondHighestNumber
{
    public static void Main(string[] args)
    {
        var list = new List<int>
        {
            // 83, 53, 63, 69, 89, 69, 43, 18, 26, 33, 60, 53, 77, 70, 100, 10, 22, 10, 22, 29, 4, 20, 77, 4, 90, 47, 28, 27, 40, 90, 13, 71, 33, 85, 58, 53, 73, 12, 34, 47, 43, 4, 20, 74, 11, 43, 69, 38, 78, 2, 62, 97, 67, 18, 91, 97, 46, 33, 64, 14, 33, 30, 39, 95, 16, 9, 57, 17, 15, 61, 80, 20, 3, 96, 69, 94, 33, 38, 16, 20, 84, 92, 24, 74, 36, 71, 67, 78, 9, 55, 22, 75, 94, 35, 17, 14, 58, 11, 53, 91
            2, 3, 6, 5, 9, 12, 4, 7
        };
        var result = GetSecondHighestNumber(list);
        System.Console.WriteLine($"The second highest is: {result}");
        list.Sort();
        System.Console.WriteLine($"The second highest is: {list.ElementAt(list.Count()-2)}");
    }
    public static int GetSecondHighestNumber(IEnumerable<int> listOfNumbers)
    {
        int highestNumber = Int32.MinValue;
        int secondHighestNumber = Int32.MinValue;

        for (int i = 0; i < listOfNumbers.Count(); i++)
        {
            if (listOfNumbers.ElementAt(i) < highestNumber &&  listOfNumbers.ElementAt(i) > secondHighestNumber)
            {
                secondHighestNumber = listOfNumbers.ElementAt(i);
            }

            if (listOfNumbers.ElementAt(i) > highestNumber)
            {
                secondHighestNumber = highestNumber;
                highestNumber = listOfNumbers.ElementAt(i);
            }
        }

        return secondHighestNumber;
    }
}

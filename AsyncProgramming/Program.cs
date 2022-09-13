using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncBreakfast
{
    // These classes are intentionally empty for the purpose of this example. They are simply marker classes for the purpose of demonstration, contain no properties, and serve no other purpose.
    internal class Bacon { }
    internal class Coffee { }
    internal class Egg { }
    internal class Juice { }
    internal class Toast { }

    class Program
    {
        static async Task Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine($"{DateTime.Now} => coffee is ready");

            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            Console.WriteLine($"{DateTime.Now} => continue cooking....");

            var breakfastTasks = new List<Task> { baconTask, toastTask };
            while (breakfastTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask)
                {
                    Console.WriteLine($"{DateTime.Now} => eggs are ready");
                }
                else if (finishedTask == baconTask)
                {
                    Console.WriteLine($"{DateTime.Now} => bacon is ready");
                }
                else if (finishedTask == toastTask)
                {
                    Console.WriteLine($"{DateTime.Now} => toast is ready");
                }
                breakfastTasks.Remove(finishedTask);
            }

            await eggsTask;

            Juice oj = PourOJ();
            Console.WriteLine($"{DateTime.Now} => oj is ready");
            Console.WriteLine($"{DateTime.Now} => Breakfast is ready!");
        }

        static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }

        private static Juice PourOJ()
        {
            Console.WriteLine($"{DateTime.Now} => Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine($"{DateTime.Now} => Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine($"{DateTime.Now} => Putting butter on the toast");

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine($"{DateTime.Now} => Putting a slice of bread in the toaster");
            }
            Console.WriteLine($"{DateTime.Now} => Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine($"{DateTime.Now} => Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"{DateTime.Now} => putting {slices} slices of bacon in the pan");
            Console.WriteLine($"{DateTime.Now} => cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine($"{DateTime.Now} => flipping a slice of bacon");
            }
            Console.WriteLine($"{DateTime.Now} => cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine($"{DateTime.Now} => Put bacon on plate");

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine($"{DateTime.Now} => Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"{DateTime.Now} => cracking {howMany} eggs");
            Console.WriteLine($"{DateTime.Now} => cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine($"{DateTime.Now} => Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine($"{DateTime.Now} => Pouring coffee");
            return new Coffee();
        }
    }
}
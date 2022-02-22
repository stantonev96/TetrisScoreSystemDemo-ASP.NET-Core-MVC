using System;
using System.Collections.Generic;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var ingredients = "Чаши - 2 - 3 тест".Split(" - ", 2);

            var mainIngredient = ingredients[0];
            var quantity = ingredients[1];

            Console.WriteLine(mainIngredient);
            Console.WriteLine(quantity);

            var test = new SortedSet<int>();

            test.Add(1);
            test.Add(1);
            test.Add(1);
            test.Add(2);
            test.Add(2);
            test.Add(2);
            test.Add(2);
            test.Add(3);
            test.Add(3);
            test.Add(3);
            test.Add(3);

            foreach (var item in test)
            {
                Console.WriteLine(item);
            }
        }
    }
}

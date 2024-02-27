using System;
using System.Collections.Generic;
using ServiceLibrary.ReplacementAlgorithmStrategy;
using ServiceLibrary;

class Program
{
    private static void ServiceDemo(Service service, List<int> numbers)
    {
        Console.WriteLine("Algorithm: " + service.Algorithm.GetType().Name);
        Console.WriteLine("In: " + string.Join(", ", numbers));
        string result = service.GetNewSequence(numbers);
        Console.WriteLine("Out: " + result + "\n");
    }

    private static void Main()
    {
        ServiceDemo(
            new Service(
                new UnambiguousReplacement(
                    new Dictionary<int, string>
                    {
                        {3, "dog"},
                        {5, "cat"},
                    })),
            new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });

        ServiceDemo(
            new Service(
                new UnambiguousReplacement(
                    new Dictionary<int, string>
                    {
                        {3, "fizz"},
                        {5, "buzz"},
                        {4, "muzz"},
                        {7, "guzz"},
                    })),
            new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 60, 105, 420 });

        ServiceDemo(
            new Service(
                new ReplacementWithCompositeDivider(
                    new Dictionary<int, string>
                    {
                        {3, "dog"},
                        {5, "cat"},
                        {15, "good-boy"},
                        {4, "muzz"},
                        {7, "guzz"},
                    })),
            new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 60, 105, 420 });

        ServiceDemo(
            new Service(
                new UnambiguousReplacement(
                    new Dictionary<int, string>
                    {
                        {3, "dog"},
                        {5, "cat"},
                        {15, "good-boy"},
                        {4, "ant"},
                        {7, "spider"},
                        {28, "insect"},
                    })),
            new List<int> { 1, 2, 3, 4, 5, 6, 7, 60, 84, 105, 140, 420 });

        ServiceDemo(
            new Service(
                new ReplacementWithCompositeDivider(
                    new Dictionary<int, string>
                    {
                        {3, "dog"},
                        {5, "cat"},
                        {15, "good-boy"},
                        {4, "ant"},
                        {7, "spider"},
                        {28, "insect"},
                    })),
            new List<int> { 1, 2, 3, 4, 5, 6, 7, 60, 84, 105, 140, 420 });
    }
}
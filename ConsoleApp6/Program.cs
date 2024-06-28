using System;
using System.Collections.Generic;

class Program
{
    public static event Action<int> SortEvent;

    static void Main()
    {
        List<string> names = new List<string> { "Smith", "Brown", "Johnson", "Williams", "Jones" };

        SortEvent += SortNames;

        try
        {
            Console.WriteLine("Enter 1 for sorting A-Z or 2 for sorting Z-A:");
            int sortOrder = int.Parse(Console.ReadLine());

            if (sortOrder == 1 || sortOrder == 2)
            {
                SortEvent?.Invoke(sortOrder);
            }
            else
            {
                throw new InvalidInputException("Invalid input, please enter 1 or 2");
            }
        }
        catch (FormatException ex)
        {
            Console.WriteLine("FormatException caught: " + ex.Message);
        }
        catch (InvalidInputException ex)
        {
            Console.WriteLine("InvalidInputException caught: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Finally block executed");
        }
    }

    static void SortNames(int order)
    {
        List<string> names = new List<string> { "Smith", "Brown", "Johnson", "Williams", "Jones" };

        if (order == 1)
        {
            names.Sort();
        }
        else if (order == 2)
        {
            names.Sort((a, b) => b.CompareTo(a));
        }

        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }
}

class InvalidInputException : Exception
{
    public InvalidInputException(string message) : base(message) { }
}
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
class Program
{
    static void Main()
    {
        bool continueMenu = true;

        while (continueMenu)
        {
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Task 1");
            Console.WriteLine("2. Task 2");
            Console.WriteLine("3. Task 3");
            Console.WriteLine("4. Exit");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Task1();
                        break;
                    case 2:
                        Task2();
                        break;
                    case 3:
                        MenuTask3();
                        break;
                    case 4:
                        continueMenu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }

    }

    static void Task1()
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            Console.Write("Enter the number of people (N): ");
            int N = int.Parse(Console.ReadLine());
            List<int> people = new List<int>();

            for (int i = 1; i <= N; i++)
            {
                people.Add(i);
            }

            int currentIndex = 0;

            while (people.Count > 1)
            {
                currentIndex = (currentIndex + 1) % people.Count;
                people.RemoveAt(currentIndex);
            }

            Console.WriteLine("The last person left: " + people[0]);

            Console.Write("Do you want to continue? (yes/no): ");
            string userInput = Console.ReadLine().ToLower();

            if (userInput == "no")
            {
                keepRunning = false;
            }
        }
    }

    static void Task2()
    {
        List<string> list = new List<string> { "one", "two", "three" };
        Dictionary<string, int> dict = new Dictionary<string, int>
        {
            { "first", 1 },
            { "second", 2 },
            { "third", 3 }
        };

        Dictionary<string, string> newDict = new Dictionary<string, string>();

        for (int i = 0; i < list.Count; i++)
        {
            string key = list[i];
            if (dict.ContainsKey(key))
            {
                newDict[key] = dict[key].ToString();
            }
            else
            {
                newDict[key] = "Not found";
            }
        }

        string json = JsonSerializer.Serialize(newDict, new JsonSerializerOptions { WriteIndented = true });
        string projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\ospc\Desktop\Lab 1"));
        string resultFilePath = Path.Combine(projectDirectory, "result.json");
        File.WriteAllText(resultFilePath, json);

        Console.WriteLine($"The new dictionary is saved in the file: {resultFilePath}");
    }


    static void MenuTask3()
    {
        bool continueMenu = true;

        while (continueMenu)
        {
            Console.WriteLine("Please choose an input case:");
            Console.WriteLine("1. Error case");
            Console.WriteLine("2. Empty case");
            Console.WriteLine("3. Matching elements case");
            Console.WriteLine("4. Exit");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Task3(new List<string> { "banana", "apple", "car", "table", "sofa" }, 'a');
                        break;
                    case 2:
                        Task3(new List<string> { "banana", "apple", "car", "table", "tea" }, 'x');
                        break;
                    case 3:
                        Task3(new List<string> { "banana", "apple", "car", "table", "teacup" }, 'a');
                        break;
                    case 4:
                        continueMenu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
    }

    static void Task3(List<string> A, char C)
    {
        try
        {
            var matchingElements = A.Where(s => s.EndsWith(C.ToString())).ToList();
            string result;

            if (matchingElements.Count == 0)
            {
                result = "";
            }
            else if (matchingElements.Count == 1)
            {
                result = matchingElements.First();
            }
            else
            {
                result = "Error";
            }

            Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

}

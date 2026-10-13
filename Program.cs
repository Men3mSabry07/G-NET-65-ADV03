using System;
using System.Collections;

namespace G_NET_65_ADV03
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Exercise 1: Student Grade Manager

            // Q1 >> Create a collection of grades.
            List<int> list = new() { 85, 92, 78, 95, 88, 70, 100, 65 };

            // Q2 >> Print the collection, count, first, and last grade.
            foreach (int i in list)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine($"\nCount: {list.Count}");
            Console.WriteLine($"First item: {list[0]}");
            Console.WriteLine($"Last item: {list[list.Count - 1]}");

            // Q3 >> Sort grades in ascending order then print.
            list.Sort();

            foreach (int i in list)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            // Q4 >> Get the first grade above 90.
            Console.WriteLine(list.Find(x => x > 90));

            // Q5 >> Get all failing grades below 75.
            Console.WriteLine(string.Join(", ", list.FindAll(x => x < 75)));

            // Q6 >> Remove all failing grades below 75.
            list.RemoveAll(x => x < 75);

            // Q7 >> Check if any grade equals 100.
            if (list.Exists(x => x == 100))
            {
                Console.WriteLine("There is a grade of 100.");
            }
            else
            {
                Console.WriteLine("There is no grade of 100.");
            }

            // Q8 >> Convert each grade to a string.
            List<string> gradeStrings = list.ConvertAll(x => $"Grade: {x}");
            Console.WriteLine(string.Join(", ", gradeStrings));




            // Exercise 2: Leaderboard

            // Q1 >> Add players with their scores.
            SortedList<int, string> sortedlist = new()
            {
                { 500, "Ahmed" },
                { 200, "Sara" },
                { 800, "Ali" },
                { 350, "Mona" }
            };

            // Q2 >> Print all entries sorted by score.
            foreach (var item in sortedlist)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }

            // Q3 >> Access the first key and first value.
            Console.WriteLine(sortedlist.Keys[0]);
            Console.WriteLine(sortedlist.Values[0]);

            // Q4 >> Check if score 500 exists.
            if (sortedlist.ContainsKey(500))
            {
                Console.WriteLine("Key 500 exists in the SortedList.");
            }
            else
            {
                Console.WriteLine("Key 500 does not exist in the SortedList.");
            }

            // Q5 >> Safely get the player with score 999.
            if (sortedlist.TryGetValue(999, out string playerName))
            {
                Console.WriteLine($"Player with score 999: {playerName}");
            }
            else
            {
                Console.WriteLine("No player found with score 999.");
            }

            // Q6 >> Remove score 200 and print the updated list.
            sortedlist.Remove(200);

            foreach (var item in sortedlist)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }





            // Exercise 3: Phone Book

            // Q1 >> Create a collection of four contacts.
            Dictionary<string, string> dictionary = new()
            {
                ["Men3m"] = "01141562494",
                ["Mariam"] = "01141562495",
                ["Mohamed"] = "01141562496",
                ["Ali"] = "01141562497"
            };

            // Q2 >> Add a new contact using [] syntax.
            dictionary["Maddona"] = "01141562498";


            // Q3 >> Add a duplicate using Add() and display a custom error message.
            try
            {
                if (dictionary.ContainsKey("Maddona"))
                    throw new Exception("Maddona already exists Cannot add duplicate contact.");

                dictionary.Add("Maddona", "01141562498");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


            // Q4 >> Try adding a duplicate using TryAdd().
            string name = Console.ReadLine();

            if (dictionary.TryAdd(name, "01141562496"))
            {
                Console.WriteLine($"{name} added successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to add {name}.");
            }

            // Q5 >> Search for a contact that does not exist.
            if (dictionary.TryGetValue("Ahmed", out name))
            {
                Console.WriteLine(name);
            }
            else
            {
                Console.WriteLine("Contact does not exist.");
            }

            // Q6 >> Get a contact with a fallback of "Not Found".
            string contact = dictionary.GetValueOrDefault("Ahmed", "Not Found");
            Console.WriteLine(contact);

            // Q7 >> Print all keys and values on separate lines.
            Console.WriteLine(string.Join(", ", dictionary.Keys));
            Console.WriteLine(string.Join(", ", dictionary.Values));










            // Exercise 4: Unique Email Validator

            // Q1 >> Create a case-insensitive HashSet.
            HashSet<string> emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase) {
                "Men3m@gmail.com",
                "Mariam@gmail.com",
                "Maddona@gmail.com",
                "Ali@gmail.com", 
                "Mohamed@gmail.com"
            };

            // Q2 >> Add email addresses.
            emails.UnionWith(["AHMED@test.com", "sara@test.com", "Sara@Test.Com"]);

            //  Add 3 emails by Add().
            emails.Add("AHMED@test.com");
            emails.Add("sara@test.com");
            emails.Add("Sara@Test.Com");

            // Q3 >> Print the count and explain why.
            Console.WriteLine($"Count of emails: {emails.Count}"); // Count is 8 because duplicate emails are ignored regardless of letter casing.

            // Q4 >> Create Set A and Set B.
            HashSet<int> A = new() { 1, 2, 3, 4, 5 };
            HashSet<int> B = new() { 4, 5, 6, 7, 8 };

            // Q5 >> Print the result of: UnionWith, IntersectWith, ExceptWith.

            // Union and UnionWith
            Console.WriteLine("Union: " + string.Join(", ", A.Union(B)));

            HashSet<int> union = new(A);
            union.UnionWith(B);
            Console.WriteLine("UnionWith: " + string.Join(", ", union));


            // Intersect and IntersectWith
            Console.WriteLine("Intersect: " + string.Join(", ", A.Intersect(B)));

            HashSet<int> intersection = new(A);
            intersection.IntersectWith(B);
            Console.WriteLine("IntersectWith: " + string.Join(", ", intersection));

            // Except and Except
            Console.WriteLine("Except: " + string.Join(", ", A.Except(B)));

            HashSet<int> difference = new(A);
            difference.ExceptWith(B);
            Console.WriteLine("ExceptWith: " + string.Join(", ", difference));


            // Q6 >> Check if {1, 2} is a subset of Set A.
            if (new HashSet<int> { 1, 2 }.IsSubsetOf(A))
            {
                Console.WriteLine("{1, 2} is a subset of A.");
            }
            else
            {
                Console.WriteLine("{1, 2} is not a subset of A.");
            }





            // Exercise 5: Print Queue Simulator

            Queue<string> documents = new Queue<string>();

            // Q1 >> Enqueue five documents then print the queue and count.
            documents.Enqueue("Report.pdf");
            documents.Enqueue("Invoice.pdf");
            documents.Enqueue("Letter.docx");
            documents.Enqueue("Resume.pdf");
            documents.Enqueue("Photo.jpg");

            foreach (string docs in documents)
            {
                Console.Write(docs + " ");
            }

            Console.WriteLine("\nCount: " + documents.Count);

            // Q2 >> Peek at the next document without removing it.
            Console.WriteLine(documents.Peek());

            // Q3 >> Process the queue and print each document.
            while (documents.Count != 0)
            {
                Console.WriteLine($"Printing: [{documents.Dequeue()}]");
            }

            // Q4 >> Try dequeuing from the empty queue.
            if (documents.TryDequeue(out string doc))
            {
                Console.WriteLine($"Printing: [{doc}]");
            }
            else
            {
                Console.WriteLine("Queue is empty");
            }

            // Exercise 6: Browser History (Undo)

            Stack<string> urls = new Stack<string>();

            // Q1 >> Push five URLs onto the stack.
            urls.Push("google.com");
            urls.Push("github.com");
            urls.Push("stackoverflow.com");
            urls.Push("youtube.com");
            urls.Push("claude.ai");

            // Q2 >> Peek at the current page.
            Console.WriteLine("Top of Stack: " + urls.Peek());

            // Q3 >> Go back three times using Pop.
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Leaving: [{urls.Pop()}]");
            }

            // Q4 >> Print the current page after going back.
            Console.WriteLine("Current page: " + urls.Peek());

            // Q5 >> Empty the stack then try TryPop.
            while (urls.Count > 0)
            {
                urls.Pop();
            }

            if (urls.TryPop(out string url))
            {
                Console.WriteLine(url);
            }
            else
            {
                Console.WriteLine("Stack is Empty");
            }
        }
    }
}

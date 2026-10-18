using System;
using System.Collections.Generic;

namespace StudentManagement
{
    internal class Program
    {
        // 1. მონაცემთა სტრუქტურები მოთხოვნის მიხედვით
        static List<string> studentNames = new List<string>();
        static Dictionary<string, int> studentGrades = new Dictionary<string, int>();

        static void Main(string[] args)
        {

            // ქართული ტექსტის სწორად გამოსაჩენად
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n--- სტუდენტების ქულების მართვის სისტემა ---");
                Console.WriteLine("1. სტუდენტის დამატება");
                Console.WriteLine("2. სტუდენტის ძებნა");
                Console.WriteLine("3. ქულის განახლება");
                Console.WriteLine("4. ყველა სტუდენტის ჩვენება");
                Console.WriteLine("5. გამოსვლა");
                Console.Write("აირჩიეთ მოქმედება (1-5): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        SearchStudent();
                        break;
                    case "3":
                        UpdateGrade();
                        break;
                    case "4":
                        ShowAllStudents();
                        break;
                    case "5":
                        isRunning = false;
                        Console.WriteLine("პროგრამა დასრულდა.");
                        break;
                    default:
                        Console.WriteLine("არასწორი არჩევანი, სცადეთ თავიდან.");
                        break;
                }
            }
        }

        // 1. სტუდენტის დამატება
        static void AddStudent()
        {
            Console.Write("შეიყვანეთ სტუდენტის სახელი: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("სახელი არ შეიძლება იყოს ცარიელი!");
                return;
            }

            if (studentGrades.ContainsKey(name))
            {
                Console.WriteLine("ამ სახელის სტუდენტი უკვე არსებობს!");
                return;
            }

            Console.Write("შეიყვანეთ ქულა: ");
            if (int.TryParse(Console.ReadLine(), out int grade))
            {
                studentNames.Add(name);            // დამატება List-ში
                studentGrades.Add(name, grade);    // დამატება Dictionary-ში
                Console.WriteLine("სტუდენტი წარმატებით დაემატა!");
            }
            else
            {
                Console.WriteLine("არასწორი ქულის ფორმატი!");
            }
        }

        // 2. სტუდენტის ძებნა
        static void SearchStudent()
        {
            Console.Write("შეიყვანეთ საძიებო სტუდენტის სახელი: ");
            string name = Console.ReadLine();

            if (studentGrades.TryGetValue(name, out int grade))
            {
                Console.WriteLine($"სტუდენტი: {name} | ქულა: {grade}");
            }
            else
            {
                Console.WriteLine("სტუდენტი ვერ მოიძებნა");
            }
        }

        // 3. ქულის განახლება
        static void UpdateGrade()
        {
            Console.Write("შეიყვანეთ სტუდენტის სახელი: ");
            string name = Console.ReadLine();

            if (studentGrades.ContainsKey(name))
            {
                Console.Write("შეიყვანეთ ახალი ქულა: ");
                if (int.TryParse(Console.ReadLine(), out int newGrade))
                {
                    studentGrades[name] = newGrade; // ქულის განახლება Dictionary-ში
                    Console.WriteLine("ქულა წარმატებით განახლდა!");
                }
                else
                {
                    Console.WriteLine("არასწორი ქულის ფორმატი!");
                }
            }
            else
            {
                Console.WriteLine("სტუდენტი ვერ მოიძებნა!");
            }
        }

        // 4. ყველა სტუდენტის ჩვენება (List-ის მიხედვით)
        static void ShowAllStudents()
        {
            if (studentNames.Count == 0)
            {
                Console.WriteLine("სია ცარიელია.");
                return;
            }

            Console.WriteLine("--- სტუდენტების სია ---");
            foreach (string name in studentNames)
            {
                int grade = studentGrades[name];
                Console.WriteLine($"სახელი: {name} | ქულა: {grade}");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = InputStudents();

            // Câu a
            Console.WriteLine("\nDanh sach toan bo hoc sinh:");
            PrintStudents(students);

            // Câu b
            Console.WriteLine("\nHoc sinh co tuoi tu 15 den 18:");
            var age15to18 = students.Where(s => s.Age >= 15 && s.Age <= 18);
            PrintStudents(age15to18);

            // Câu c
            Console.WriteLine("\nHoc sinh co ten bat dau bang chu 'A':");
            var nameStartsWithA = students.Where(s => s.Name.StartsWith("A", StringComparison.OrdinalIgnoreCase));
            PrintStudents(nameStartsWithA);

            // Câu d
            int totalAge = students.Sum(s => s.Age);
            Console.WriteLine($"\nTong tuoi cua tat ca hoc sinh: {totalAge}");

            // Câu e
            Console.WriteLine("\nHoc sinh co tuoi lon nhat:");
            var oldestStudent = students.OrderByDescending(s => s.Age).FirstOrDefault();
            if (oldestStudent != null)
            {
                PrintStudents(new List<Student> { oldestStudent });
            }

            // Câu f
            Console.WriteLine("\nDanh sach hoc sinh sap xep theo tuoi tang dan:");
            var sortedStudents = students.OrderBy(s => s.Age);
            PrintStudents(sortedStudents);
        }
        static List<Student> InputStudents()
        {
            List<Student> students = new List<Student>();
            Console.WriteLine("Nhap so luong hoc sinh:");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nNhap thong tin hoc sinh thu {i + 1}:");
                Console.Write("Id: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Age: ");
                int age = int.Parse(Console.ReadLine());

                students.Add(new Student { Id = id, Name = name, Age = age });
            }

            return students;
        }
        static void PrintStudents(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}");
            }
        }
    }
}
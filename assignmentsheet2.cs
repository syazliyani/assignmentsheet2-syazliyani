using System;

namespace StudentManagementSystem
{
    class Program
    {
        static Student[] students = new Student[50];
        static int studentCount = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Student Management System");
            Console.WriteLine("----------------------------------------");

            while (true)
            {
                DisplayMenu();
                int choice = GetUserChoice();

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        ViewAllStudents();
                        break;
                    case 3:
                        SearchStudent();
                        break;
                    case 4:
                        RemoveStudent();
                        break;
                    case 5:
                        UpdateStudentGrade();
                        break;
                    case 6:
                        SortStudents();
                        break;
                    case 7:
                        DisplayAverageGrade();
                        break;
                    case 8:
                        DisplayPassingStudents();
                        break;
                    case 9:
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("1. Add a New Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Search for a Student by ID");
            Console.WriteLine("4. Remove a Student by ID");
            Console.WriteLine("5. Update a Student's Grade");
            Console.WriteLine("6. Sort Students by Grade");
            Console.WriteLine("7. Display Average Grade");
            Console.WriteLine("8. Count Passing Students");
            Console.WriteLine("9. Exit");
            Console.Write("Enter your choice: ");
        }

        static int GetUserChoice()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 9)
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid choice between 1 and 9.");
                }
            }
        }

        static void AddStudent()
        {
            if (studentCount >= students.Length)
            {
                Console.WriteLine("Cannot add more students. The system is full.");
                return;
            }

            int id;
            while (true)
            {
                Console.Write("Enter Student ID: ");
                if (int.TryParse(Console.ReadLine(), out id) && id > 0)
                {
                    if (FindStudentById(id) != null)
                    {
                        Console.WriteLine($"A student with ID {id} already exists. Please use a different ID.");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid positive integer ID.");
                }
            }

            string name;
            while (true)
            {
                Console.Write("Enter Student Name: ");
                name = CapitalizeWords(Console.ReadLine());
                if (!string.IsNullOrWhiteSpace(name))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid name.");
                }
            }

            int age;
            while (true)
            {
                Console.Write("Enter Student Age: ");
                if (int.TryParse(Console.ReadLine(), out age) && age > 0 && age < 100)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid age between 1 and 99.");
                }
            }

            double grade;
            while (true)
            {
                Console.Write("Enter Student Grade: ");
                if (double.TryParse(Console.ReadLine(), out grade) && grade >= 0 && grade <= 100)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid grade between 0 and 100.");
                }
            }

            students[studentCount] = new Student(id, name, age, grade);
            studentCount++;
            Console.WriteLine("Student added successfully!");
        }

        static void ViewAllStudents()
        {
            if (studentCount == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            Console.WriteLine("Student Details:");
            for (int i = 0; i < studentCount; i++)
            {
                students[i].DisplayDetails();
            }
        }

        static void SearchStudent()
        {
            int id;
            while (true)
            {
                Console.Write("Enter Student ID: ");
                if (int.TryParse(Console.ReadLine(), out id) && id > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid positive integer ID.");
                }
            }

            Student student = FindStudentById(id);
            if (student != null)
            {
                student.DisplayDetails();
            }
            else
            {
                Console.WriteLine($"Student with ID {id} not found.");
            }
        }

        static void RemoveStudent()
        {
            int id;
            while (true)
            {
                Console.Write("Enter Student ID: ");
                if (int.TryParse(Console.ReadLine(), out id) && id > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid positive integer ID.");
                }
            }

            Student student = FindStudentById(id);
            if (student != null)
            {
                RemoveStudentFromArray(student);
                Console.WriteLine($"Student with ID {id} has been removed.");
            }
            else
            {
                Console.WriteLine($"Student with ID {id} not found.");
            }
        }

        static void UpdateStudentGrade()
        {
            int id;
            while (true)
            {
                Console.Write("Enter Student ID: ");
                if (int.TryParse(Console.ReadLine(), out id) && id > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid positive integer ID.");
                }
            }

            Student student = FindStudentById(id);
            if (student != null)
            {
                double newGrade;
                while (true)
                {
                    Console.Write("Enter New Grade: ");
                    if (double.TryParse(Console.ReadLine(), out newGrade) && newGrade >= 0 && newGrade <= 100)
                    {
                        student.Grade = newGrade;
                        Console.WriteLine($"Student {student.Name}'s grade has been updated to {newGrade}.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid grade between 0 and 100.");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Student with ID {id} not found.");
            }
        }

        static void SortStudents()
        {
            Array.Sort(students, 0, studentCount, new StudentGradeComparer());
            Console.WriteLine("Students sorted by grade (descending):");
            ViewAllStudents();
        }

        static void DisplayAverageGrade()
        {
            if (studentCount == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            double totalGrade = 0;
            for (int i = 0; i < studentCount; i++)
            {
                totalGrade += students[i].Grade;
            }
            double averageGrade = totalGrade / studentCount;
            Console.WriteLine($"Average grade: {averageGrade:F2}");
        }

        static void DisplayPassingStudents()
        {
            if (studentCount == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            int passingStudents = 0;
            for (int i = 0; i < studentCount; i++)
            {
                if (students[i].IsPassing())
                {
                    passingStudents++;
                }
            }
            Console.WriteLine($"Number of passing students: {passingStudents}");
        }

        static Student FindStudentById(int id)
        {
            for (int i = 0; i < studentCount; i++)
            {
                if (students[i].ID == id)
                {
                    return students[i];
                }
            }
            return null;
        }

        static void RemoveStudentFromArray(Student student)
        {
            int index = Array.IndexOf(students, student);
            if (index != -1)
            {
                for (int i = index; i < studentCount - 1; i++)
                {
                    students[i] = students[i + 1];
                }
                studentCount--;
            }
        }

        static string CapitalizeWords(string input)
        {
            string[] words = input.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
            }
            return string.Join(" ", words);
        }
    }

    class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Grade { get; set; }

        public Student(int id, string name, int age, double grade)
        {
            ID = id;
            Name = name;
            Age = age;
            Grade = grade;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"ID: {ID}, Name: {Name}, Age: {Age}, Grade: {Grade} - {(IsPassing() ? "Passing" : "Failing")}");
        }

        public bool IsPassing()
        {
            return Grade >= 60;
        }
    }

    class StudentGradeComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return y.Grade.CompareTo(x.Grade);
        }
    }
}
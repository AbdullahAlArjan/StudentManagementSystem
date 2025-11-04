using StudentManagementSystem.Business;
using StudentManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Models;
using StudentManagementSystem.Business;
using System.Security.Cryptography.Pkcs;

namespace StudentManagementSystem.Presentation
{
    public class MenuManager
    {
        private readonly IStudentService _studentservice;

        public MenuManager()
        {
            IStudentRepository rep = new StudentRepository();
            _studentservice = new StudentService(rep);
        }

        public void run()
        {

            while (true)
            {
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudentMenu();
                        break;
                    case "2":
                        ViewAllStudentsMenu();
                        break;
                    case "3":
                        UpdateStudentMenu();
                        break;
                    case "4":
                        DeleteStudentMenu();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private void AddStudentMenu()
        {
            var s = new Student();
            Console.Write("Name: "); s.Name = Console.ReadLine();
            Console.Write("Email: "); s.Email = Console.ReadLine();
            Console.Write("Gender: "); s.Gender = Console.ReadLine();
            Console.Write("DOB (yyyy-mm-dd): "); s.DateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.Write("Department: "); s.Department = Console.ReadLine();

            _studentservice.AddStudent(s);
            Console.WriteLine("✅ Student added successfully.");

        }

        private void ViewAllStudentsMenu()
        {
            var students = _studentservice.GetAll();
            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            Console.WriteLine("\n{0,-5} {1,-20} {2,-25} {3,-10} {4,-12} {5,-15}",
    "ID", "Name", "Email", "Gender", "Birth Date", "Department");
            Console.WriteLine(new string('-', 90));

            foreach (var st in students)
            {
                Console.WriteLine("{0,-5} {1,-20} {2,-25} {3,-10} {4,-12:yyyy-MM-dd} {5,-15}",
                    st.StudentID, st.Name, st.Email, st.Gender, st.DateOfBirth, st.Department);
            }
        }
        private void UpdateStudentMenu()
        {
            var students = _studentservice.GetAll();
            Console.WriteLine("\n{0,-5} {1,-20} {2,-25} {3,-10} {4,-12} {5,-15}",
            "ID", "Name", "Email", "Gender", "Birth Date", "Department");
            Console.WriteLine(new string('-', 90));

            foreach (var st in students)
            {
                Console.WriteLine("{0,-5} {1,-20} {2,-25} {3,-10} {4,-12:yyyy-MM-dd} {5,-15}",
                    st.StudentID, st.Name, st.Email, st.Gender, st.DateOfBirth, st.Department);
            }

            Console.Write("Enter Student ID to update: ");
            int id = int.Parse(Console.ReadLine());
            var student = _studentservice.GetById(id);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }
            Console.Write("Name ({0}): ", student.Name);
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name)) student.Name = name;
            Console.Write("Email ({0}): ", student.Email);
            string email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email)) student.Email = email;
        }

        private void DeleteStudentMenu()
        {
            var students = _studentservice.GetAll();
            Console.WriteLine("\n{0,-5} {1,-20} {2,-25} {3,-10} {4,-12} {5,-15}",
            "ID", "Name", "Email", "Gender", "Birth Date", "Department");
            Console.WriteLine(new string('-', 90));

            foreach (var st in students)
            {
                Console.WriteLine("{0,-5} {1,-20} {2,-25} {3,-10} {4,-12:yyyy-MM-dd} {5,-15}",
                    st.StudentID, st.Name, st.Email, st.Gender, st.DateOfBirth, st.Department);
            }

                Console.Write("Enter Student ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }
            var student = _studentservice.GetById(id);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }
            _studentservice.Delete(id);
            Console.WriteLine("Student deleted successfully.");
        }
    }
}


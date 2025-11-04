using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Business
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        // for dependency injection
        public StudentService(IStudentRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public void AddStudent(Student student)
        {
            if (student == null) throw new ArgumentNullException(nameof(student));
            if (string.IsNullOrWhiteSpace(student.Name))
                throw new ArgumentException("Name is required.");
            if (student.DateOfBirth > DateTime.Now)
                throw new ArgumentException("Invalid date of birth.");

            _repository.AddStudent(student);
        }
        public void Update(Student student)
        {
            if (student == null || student.StudentID <= 0)
                throw new ArgumentException("Invalid student.");
            _repository.Update(student);
        }
        public void Delete(int id)
        {
            if (id <= 0) throw new ArgumentException("Invalid ID.");
            _repository.Delete(id);
        }
        public Student GetById(int id)
        {
            if (id <= 0) throw new ArgumentException("Invalid ID.");
            return _repository.GetById(id);
        }
        public List<Student> GetAll()
        {
            return _repository.GetAll();
        }



    }
}

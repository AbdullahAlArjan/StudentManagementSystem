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

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }
        public void AddStudent(Student student)
        {
            _repository.AddStudent(student);
        }
        public void Update(Student student)
        {
            _repository.Update(student);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
        public Student GetById(int id)
        {
            return _repository.GetById(id);
        }
        public List<Student> GetAll()
        {
            return _repository.GetAll();
        }



    }
}

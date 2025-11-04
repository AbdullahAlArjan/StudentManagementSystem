using StudentManagementSystem.Models;

namespace StudentManagementSystem.Data
{
    
        public interface IStudentRepository
    {
        void AddStudent(Student student);
        void Update(Student student);
        void Delete(int id);
        Student GetById(int id);
        List<Student> GetAll();
    }
    }


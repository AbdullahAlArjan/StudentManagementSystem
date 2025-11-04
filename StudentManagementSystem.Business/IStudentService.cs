using StudentManagementSystem.Models;

namespace StudentManagementSystem.Business
{
    public interface IStudentService
    {
        void AddStudent(Student student);
        void Update(Student student);
        void Delete(int id);
        Student GetById(int id);
        List<Student> GetAll();
    }
}

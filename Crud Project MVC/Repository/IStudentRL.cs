using Crud_Project_MVC.Models;
using Crud_Project_MVC.Models.Entities;

namespace Crud_Project_MVC.Repository
{
    public interface IStudentRL
    {
        Task AddStudent(AddStudentRequest request);
        Task<List<Student>> GetStudentList();
        Task<Student> GetStudentById(Guid Id);
        Task UpdateStudent(Student request);
        Task DeleteStudent(Guid Id);
    }
}

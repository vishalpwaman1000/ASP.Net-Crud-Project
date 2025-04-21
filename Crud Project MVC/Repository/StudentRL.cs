using Azure.Core;
using Crud_Project_MVC.Data;
using Crud_Project_MVC.Models;
using Crud_Project_MVC.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crud_Project_MVC.Repository
{
    public class StudentRL : IStudentRL
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentRL(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddStudent(AddStudentRequest request)
        {
            Student student = new Student();
            student.Name = request.Name;
            student.Email = request.Email;
            student.PhoneNumber = request.PhoneNumber;
            student.SubScribed = request.SubScribed;
            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteStudent(Guid Id)
        {
            var student = await _dbContext.Students.FindAsync(Id);
            if (student != null)
            {
                _dbContext.Remove(student);
                await _dbContext.SaveChangesAsync();
            }

        }

        public async Task<Student> GetStudentById(Guid Id)
        {
            var student = await _dbContext.Students.FindAsync(Id);
            if (student is null)
                return new Student();
            return student;
        }

        public async Task<List<Student>> GetStudentList()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task UpdateStudent(Student request)
        {
            var student = await _dbContext.Students.FindAsync(request.Id);
            if (student == null)
                return;
            student.Name = request.Name;
            student.Email = request.Email;
            student.PhoneNumber = request.PhoneNumber;
            student.SubScribed = request.SubScribed;
            await _dbContext.SaveChangesAsync();
        }
    }
}

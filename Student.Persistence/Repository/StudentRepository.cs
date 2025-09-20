using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Student.Application.Contracts;
using Student.Domain.Entities;
using Student.Persistence.DatabaseContext;

namespace Student.Persistence.Repository
{
    public class StudentRepository : IStudent
    {
        private ServiceDatabaseContext _dbContext;

        public StudentRepository(ServiceDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<StudentEntity> AddStudent(StudentEntity student)
        {
            _dbContext.Students.Add(student);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

            return student;
        }

        public async Task<StudentEntity?> GetStudentById(int Id)
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == Id);

            return student;
        }
    }
}

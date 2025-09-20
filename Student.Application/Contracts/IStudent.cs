using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Domain.Entities;

namespace Student.Application.Contracts
{
    public interface IStudent
    {
        Task<StudentEntity> AddStudent(StudentEntity student);
        Task<StudentEntity> GetStudentById(int Id);
    }
}

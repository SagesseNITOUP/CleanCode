using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Student.Application.Contracts;
using Student.Domain.Entities;

namespace Student.Application.Commands.AddStudent
{
    public class StudentQueryHandler : IRequestHandler<StudentRequest, StudentEntity>
    {
        private readonly IStudent _student;
        public StudentQueryHandler(IStudent student) 
        {
            _student = student;
        }

        public async Task<StudentEntity> Handle(StudentRequest request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                throw new OperationCanceledException("The operation was canceled");
            }

            var student = new StudentEntity
            {
                Name = request.StudentName,
                FirstName = request.StudentFirstName,
                Gender = request.StudentGender,
                Nationality = request.StudentNationality,
                Email = request.StudentEmail,
                PhoneNumber = request.StudentPhone,
                DateOfBirth = request.StudentBirthDate ?? DateTime.MinValue,
                Country = request.StudentCountry,
                Adress = request.StudentAdress,
                Department = request.StudentDepartment,
                Program = request.StudentProgram,
                GraduationDate = request.StudentGraduationDate
            };

            return await _student.AddStudent(student);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Student.Domain.Entities;

namespace Student.Application.Commands.AddStudent
{
    public class StudentRequest : IRequest<StudentEntity>
    {
        public string StudentName { get; set; }
        public string StudentFirstName {  get; set; }
        public string StudentGender { get; set; }
        public string StudentNationality { get; set; }
        public string StudentEmail { get; set; }
        public string StudentPhone { get; set; }
        public string StudentAdress { get; set; }
        public DateTime? StudentBirthDate { get; set; }
        public string StudentCountry { get; set; }
        public string StudentDepartment { get; set; }
        public string StudentProgram {  get; set; }
        public DateTime StudentGraduationDate { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Domain.Entities
{
    public class StudentEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FirstName { get; set; }
        public string? Gender { get; set; }
        public string? Nationality { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Country { get; set; }
        public string? Adress { get; set; }
        public string? StudentNumber { get; set; }
        public bool IsActive { get; set; } = true;
        public string? Department { get; set; }
        public string? Program { get; set; } 
        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;
        public DateTime GraduationDate {  get; set; }

    }
}

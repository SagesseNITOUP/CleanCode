using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Student.Domain.Entities;

namespace Student.Application.Commands.GetStudent
{
    public record GetStudentQuery(int Id) : IRequest<StudentEntity>;
}

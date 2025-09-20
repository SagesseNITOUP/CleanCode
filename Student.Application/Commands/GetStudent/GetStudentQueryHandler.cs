using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Student.Application.Contracts;
using Student.Domain.Entities;

namespace Student.Application.Commands.GetStudent
{
    public class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, StudentEntity>
    {
        private readonly IMapper _mapper;
        private readonly IStudent _student;
        public GetStudentQueryHandler(IMapper mapper, IStudent student) 
        {
            _mapper = mapper;
            _student = student;
        }

        public async Task<StudentEntity> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            var student = await _student.GetStudentById(request.Id);

            return _mapper.Map<StudentEntity>(student);
        }
    }
}

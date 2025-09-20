using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Student.Domain.Entities;

namespace Student.Persistence.DatabaseContext
{
    public class ServiceDatabaseContext : DbContext
    {

        public ServiceDatabaseContext(DbContextOptions<ServiceDatabaseContext> options) : base(options)
        { }
        public DbSet<StudentEntity> Students { get; set; }
    }
}

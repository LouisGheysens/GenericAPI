using Businness.Interfaces;
using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Services
{
    public class StudentService: GenericService<Student>, IStudentService
    {
        public StudentService(SchoolDbContext context) : base(context)
        {
        }

    }
}

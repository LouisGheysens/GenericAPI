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
    public class TeacherService: GenericService<Teacher>, ITeacherService
    {
        public TeacherService(SchoolDbContext context) : base(context)
        {
        }
    }
}

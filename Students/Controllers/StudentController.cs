using AutoMapper;
using Businness.Interfaces;
using Data;
using Data.Models;
using Gridify;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Students.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;
        private readonly SchoolDbContext _context;

        public StudentController(IMapper mapper, IStudentService studentService, SchoolDbContext context)
        {
            this._mapper = mapper;
            this._studentService = studentService;
            this._context = context;
        }

        [Route("/api/student/GetStudents")]
        [HttpGet]
        public async Task<IEnumerable<Student>> GetAllStudentsAsync([FromQuery] GridifyQuery query)
        {
            return await _studentService.GetAllAsync(query);
        }

        [Route("/api/student/{id}")]
        [HttpGet]
        public async Task <int> GetStudentsAsync([FromRoute] int id)
        {
            var response =  await _studentService.GetByIdAsync(id);
        }

        [Route("/api/student/UpdateStudent")]
        [HttpPost]
        public async Task<Student> AddStudentAsync([FromBody] Student student)
        {
            await _studentService.AddAsync(student);
            await _studentService.SaveAsync();
            return student;
        }
                
        [Route("/api/student/UpdateStudent")]
        [HttpPut]
        public async Task<Student> UpdateStudentAsync([FromBody] Student student)
        {
            var updated = await _studentService.UpdateAsync(student, student.Id);
            return updated;
        }


        [Route("/api/student/DeleteStudent/{id}")]
        [HttpDelete]
        public async Task<int> DeleteStudentAsync([FromRoute] int id)
        {
            var response = await _studentService.DeleteAsync(id);
            return response;
        }
    }
}

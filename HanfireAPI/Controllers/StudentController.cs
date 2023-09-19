using HanfireAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace HanfireAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ProjectContext projectContext;
        public StudentController(ProjectContext _context)
        {
            projectContext = _context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var test = await projectContext.students.ToListAsync();
            return Ok(test);

        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var result = await projectContext.students.FindAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody]Student student)
        {
            await projectContext.students.AddAsync(student);
            projectContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);

        }
    }
}

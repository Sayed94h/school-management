using Microsoft.AspNetCore.Mvc;
using WebApiMongoDB.Models;
using WebApiMongoDB.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiMongoDB.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentServices _studentServices;

        public StudentController(StudentServices studentServices) {
            _studentServices = studentServices;
        }


        // GET: api/student
        [HttpGet]
        public async Task<List<Student>> Get() => await _studentServices.GetAsync();

        // GET api/student/64a51019c925955cfda51194
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Student>> Get(string id)
        {
            Student student = await _studentServices.GetAsync(id);
            if(student == null)
            {
                return NotFound();
            }

            return student;
        }

        // POST api/student
        [HttpPost]
        public async Task<ActionResult<Student>> Post(Student newStudent)
        {
            await _studentServices.CreateAsync(newStudent);
            return CreatedAtAction(nameof(Get), new {id = newStudent.Id}, newStudent);
        }

        // PUT api/student/64a51019c925955cfda51194
        [HttpPut("{id:length(24)}")]
        public async Task<ActionResult> Put(string id, Student updateStudent)
        {
            Student student = await _studentServices.GetAsync(id);
            if(student == null)
            {
                return NotFound("There is no student with this id: "+ id);
            }

            updateStudent.Id = student.Id;

            await _studentServices.UpdateAsync(id, updateStudent);

            return Ok("Updated Successfully");
        }

        // DELETE api/student/64a51019c925955cfda51194
        [HttpDelete("{id:length(24)}")]
        public async Task<ActionResult> Delete(string id)
        {
            Student student = await _studentServices.GetAsync(id);
            if (student == null)
            {
                return NotFound("There is no student with this id: " + id);
            }

            await _studentServices.RemoveAsync(id);

            return Ok("Deleted Successfully");
        }
    }
}

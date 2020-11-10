using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.Application.Interfaces;
using TaskManagementApp.Core.Entities;

namespace TaskManagementApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<Student>> Get()
        {
            return await unitOfWork.Students.GetAll();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<Student> Get(int id)
        {
            return await unitOfWork.Students.Get(id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task<int> Post([FromBody] Student student)
        {
            return await unitOfWork.Students.Add(student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public async Task<int> Put([FromBody] Student student)
        {
            return await unitOfWork.Students.Update(student);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
            return await unitOfWork.Students.Delete(id);
        }
    }
}

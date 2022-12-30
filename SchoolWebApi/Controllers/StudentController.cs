using Dtos;
using Microsoft.AspNetCore.Mvc;
using SchoolWebApi.Dtos;
using Services.Abstract;

namespace SchoolWebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly ISchoolService _schoolService;

        public StudentController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() =>  Ok(await _schoolService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id) => Ok(await _schoolService.FindById(id));

        [HttpPost]
        public async Task<StudentDto> InsertAsync(CreateStudentDto model) => await _schoolService.InsertAsync(model);

        //[HttpDelete]
        //public async Task<bool> Delete(int id) => await _schoolService.Delete(id);

        [HttpPut("{id:int}")]
        public async Task<StudentDto> Update(int id, UpdateStudentDto model) =>  await _schoolService.Update(id, model);

    }
}

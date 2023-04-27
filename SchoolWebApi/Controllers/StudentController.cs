using Microsoft.AspNetCore.Mvc;
using SchoolWebApi.Dtos.StudentsDto;
using SchoolWebApi.Response;
using Services.Abstract;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]
namespace SchoolWebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IStudentService _schoolService;

        public StudentController(IStudentService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpGet]
        public async Task<ApiResponse<StudentDto>>  GetAllAsync() =>  await _schoolService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id) => Ok(await _schoolService.FindByIdAsync(id));

        [HttpPost]
        public async Task<StudentDto> InsertAsync(CreateStudentDto model) => await _schoolService.InsertAsync(model);

        [HttpDelete]
        public void Delete(int id) =>  _schoolService.Delete(id);

        [HttpPut("{id:int}")]
        public async Task<StudentDto> Update(UpdateStudentDto model, int id) => await  _schoolService.Update( model, id);

    }
}

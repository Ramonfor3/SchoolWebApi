using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School;
using SchoolWebApi.Dtos.TeachersDto;
using SchoolWebApi.Models;
using SchoolWebApi.Services.Abstract;

namespace SchoolWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync() => Ok(await _teacherService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOne(int id) => Ok(await _teacherService.FindByIdAsync(id));

        [HttpPost]
        public async Task<TeacherDto> InsertAsync(CreateTeacherDto teacher) => await _teacherService.InsertAsync(teacher);

        [HttpPut("{id:int}")]
        public async Task<TeacherDto> Update(UpdateTeacherDto teacher, int id) => await _teacherService.Update(teacher, id);

        [HttpDelete]
        public void Delete(int id) => _teacherService.Delete(id);
    }
}

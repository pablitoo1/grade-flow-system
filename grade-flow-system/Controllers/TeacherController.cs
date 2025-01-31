using grade_flow_system.Models.DTO.Subject;
using grade_flow_system.Models.DTO.Teacher;
using grade_flow_system.Services;
using Microsoft.AspNetCore.Mvc;

namespace grade_flow_system.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeacherController(TeacherService teacherService) : ControllerBase
{
    [HttpGet("all")]
    public List<TeacherResponse> GetAll()
    {
        return teacherService.getAll();
    }

    [HttpPost]
    public void add([FromBody] TeacherRequest teacherRequest)
    {
        teacherService.add(teacherRequest);
    }

    [HttpPatch("{teacherId:int}")]
    public void edit([FromBody] TeacherRequest teacherRequest, int teacherId)
    {
        teacherService.edit(teacherRequest, teacherId);
    }

    [HttpDelete("{teacherId:int}")]
    public void delete(int teacherId)
    {
        teacherService.delete(teacherId);
    }
}

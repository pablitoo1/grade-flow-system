using grade_flow_system.Models.DTO.Subject;
using grade_flow_system.Models.DTO.Teacher;
using grade_flow_system.Services;
using Microsoft.AspNetCore.Mvc;

namespace grade_flow_system.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeacherController(TeacherService teacherService) : ControllerBase
{
    /// <summary>Get all teachers</summary>
    [HttpGet("all")]
    public List<TeacherResponse> GetAll()
    {
        return teacherService.getAll();
    }

    /// <summary>Add new teacher</summary>
    /// <response code="400">Teacher already exists or invalid teacher data</response>
    [HttpPost]
    public void add([FromBody] TeacherRequest teacherRequest)
    {
        teacherService.add(teacherRequest);
    }

    /// <summary>Edit existing teacher</summary>
    /// <response code="400">Teacher already exists or invalid teacher data</response>
    /// <response code="404">Teacher not found</response>
    [HttpPatch("{teacherId:int}")]
    public void edit([FromBody] TeacherRequest teacherRequest, int teacherId)
    {
        teacherService.edit(teacherRequest, teacherId);
    }

    /// <summary>Delete existing teacher</summary>
    /// <response code="404">Teacher not found</response>
    /// <response code="409">Teacher is referenced by other data</response>
    [HttpDelete("{teacherId:int}")]
    public void delete(int teacherId)
    {
        teacherService.delete(teacherId);
    }
}

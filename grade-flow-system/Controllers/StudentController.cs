using System.ComponentModel.DataAnnotations;
using grade_flow_system.Models.DTO.Student;
using grade_flow_system.Services;
using Microsoft.AspNetCore.Mvc;

namespace grade_flow_system.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController(StudentService studentService) : ControllerBase
{
    /// <summary>Get all students</summary>
    [HttpGet("all")]
    public List<StudentResponse> GetAll()
    {
        return studentService.getAll();
    }

    /// <summary>Add new student</summary>
    /// <response code ="400">Invalid student data</response>
    [HttpPost]
    public void add([FromBody] StudentRequest studentRequest)
    {
        studentService.add(studentRequest);
    }

    /// <summary>Edit existing student</summary>
    /// <response code="400">Invalid student data</response>
    /// <response code="404">Student not found</response>
    [HttpPatch("{studentId:int}")]
    public void edit([FromBody] StudentRequest studentRequest, int studentId)
    {
        studentService.edit(studentRequest, studentId);
    }

    /// <summary>Delete existing student</summary>
    /// <response code="404">Student not found</response>
    /// <response code="409">Student is referenced by other data</response>
    [HttpDelete("{studentId:int}")]
    public void delete(int studentId)
    {
        studentService.delete(studentId);
    }
}

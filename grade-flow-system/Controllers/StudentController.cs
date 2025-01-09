using System.ComponentModel.DataAnnotations;
using grade_flow_system.Models.DTO.Student;
using grade_flow_system.Services;
using Microsoft.AspNetCore.Mvc;

namespace grade_flow_system.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController(StudentService studentService) : ControllerBase
{
    [HttpGet("all")]
    public List<StudentResponse> GetAll()
    {
        return studentService.getAll();
    }

    [HttpPost]
    public void add([FromBody] StudentRequest studentRequest)
    {
        studentService.add(studentRequest);
    }

    [HttpPatch("{studentId:int}")]
    public void edit([FromBody] StudentRequest studentRequest, int studentId)
    {
        studentService.edit(studentRequest, studentId);
    }

    [HttpDelete("{studentId:int}")]
    public void delete(int studentId)
    {
        studentService.delete(studentId);
    }
}

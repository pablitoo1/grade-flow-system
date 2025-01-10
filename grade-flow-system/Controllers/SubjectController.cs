using grade_flow_system.Models.DTO.Student;
using grade_flow_system.Models.DTO.Subject;
using grade_flow_system.Services;
using Microsoft.AspNetCore.Mvc;

namespace grade_flow_system.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubjectController(SubjectService subjectService): ControllerBase
{
    [HttpGet("all")]
    public List<SubjectResponse> GetAll()
    {
        return subjectService.getAll();
    }

    [HttpPost]
    public void add([FromBody] SubjectRequest subjectRequest)
    {
        subjectService.add(subjectRequest);
    }

    [HttpPatch("{subjectId:int}")]
    public void edit([FromBody] SubjectRequest subjectRequest, int subjectId)
    {
        subjectService.edit(subjectRequest, subjectId);
    }

    [HttpDelete("{subjectId:int}")]
    public void delete(int subjectId)
    {
        subjectService.delete(subjectId);
    }
}

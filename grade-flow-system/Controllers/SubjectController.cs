using grade_flow_system.Models.DTO.Student;
using grade_flow_system.Models.DTO.Subject;
using grade_flow_system.Services;
using Microsoft.AspNetCore.Mvc;

namespace grade_flow_system.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubjectController(SubjectService subjectService): ControllerBase
{
    /// <summary>Get all subjects</summary>
    [HttpGet("all")]
    public List<SubjectResponse> GetAll()
    {
        return subjectService.getAll();
    }

    /// <summary>Add new subject</summary>
    /// <response code="400">Subject already exists or invalid subject data</response>
    [HttpPost]
    public void add([FromBody] SubjectRequest subjectRequest)
    {
        subjectService.add(subjectRequest);
    }

    /// <summary>Edit existing subject</summary>
    /// <response code="400">Subject already exists or invalid subject data</response>
    /// <response code="404">Subject not found</response>
    [HttpPatch("{subjectId:int}")]
    public void edit([FromBody] SubjectRequest subjectRequest, int subjectId)
    {
        subjectService.edit(subjectRequest, subjectId);
    }

    /// <summary>Delete existing subject</summary>
    /// <response code="404">Subject not found</response>
    /// <response code="409">Subject is referenced by other data</response>
    [HttpDelete("{subjectId:int}")]
    public void delete(int subjectId)
    {
        subjectService.delete(subjectId);
    }
}

using grade_flow_system.Models.DTO.StudentsGroup;
using grade_flow_system.Models.DTO.Teacher;
using grade_flow_system.Services;
using Microsoft.AspNetCore.Mvc;

namespace grade_flow_system.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsGroupController(StudentsGroupService studentsGroupService) : ControllerBase
{
    /// <summary>Get all students groups</summary>
    [HttpGet("all")]
    public List<StudentsGroupResponse> GetAll()
    {
        return studentsGroupService.getAll();
    }

    /// <summary>Add new students group</summary>
    /// <response code="400">Students group already exists or invalid students group data</response>
    [HttpPost]
    public void add([FromBody] StudentsGroupRequest studentsGroupRequest)
    {
        studentsGroupService.add(studentsGroupRequest);
    }

    /// <summary>Edit existing students group</summary>
    /// <response code="400">Students group already exists or invalid students group data</response>
    /// <response code="404">Students group not found</response>
    [HttpPatch("{studentsGroupId:int}")]
    public void edit([FromBody] StudentsGroupRequest studentsGroupRequest, int studentsGroupId)
    {
        studentsGroupService.edit(studentsGroupRequest, studentsGroupId);
    }

    /// <summary>Delete existing students group</summary>
    /// <response code="404">Students group not found</response>
    /// <response code="409">Students group is referenced by other data</response>
    [HttpDelete("{studentsGroupId:int}")]
    public void delete(int studentsGroupId)
    {
        studentsGroupService.delete(studentsGroupId);
    }
}

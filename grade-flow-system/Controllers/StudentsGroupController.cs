using grade_flow_system.Models.DTO.StudentsGroup;
using grade_flow_system.Models.DTO.Teacher;
using grade_flow_system.Services;
using Microsoft.AspNetCore.Mvc;

namespace grade_flow_system.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsGroupController(StudentsGroupService studentsGroupService) : ControllerBase
{
    [HttpGet("all")]
    public List<StudentsGroupResponse> GetAll()
    {
        return studentsGroupService.getAll();
    }

    [HttpPost]
    public void add([FromBody] StudentsGroupRequest studentsGroupRequest)
    {
        studentsGroupService.add(studentsGroupRequest);
    }

    [HttpPatch("{studentsGroupId:int}")]
    public void edit([FromBody] StudentsGroupRequest studentsGroupRequest, int studentsGroupId)
    {
        studentsGroupService.edit(studentsGroupRequest, studentsGroupId);
    }

    [HttpDelete("{studentsGroupId:int}")]
    public void delete(int studentsGroupId)
    {
        studentsGroupService.delete(studentsGroupId);
    }
}

using grade_flow_system.Models.DTO.Grade;
using grade_flow_system.Models.DTO.GradeType;
using grade_flow_system.Services;
using Microsoft.AspNetCore.Mvc;

namespace grade_flow_system.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GradeController(GradeService gradeService) : ControllerBase
{
    /// <summary>Get all grades</summary>
    [HttpGet("all")]
    public List<GradeResponse> GetAll()
    {
        return gradeService.getAll();
    }

    [HttpPost]
    public void add([FromBody] GradeRequest gradeRequest)
    {
        gradeService.add(gradeRequest);
    }

    [HttpPatch("{gradeId:int}")]
    public void edit([FromBody] GradeRequest gradeRequest, int gradeId)
    {
        gradeService.edit(gradeRequest, gradeId);
    }

    [HttpDelete("{gradeId:int}")]
    public void delete(int gradeId)
    {
        gradeService.delete(gradeId);
    }
}


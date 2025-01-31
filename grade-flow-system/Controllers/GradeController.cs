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

    /// <summary>Add new grade</summary>
    /// <response code ="400">Invalid grade data</response>
    [HttpPost]
    public void add([FromBody] GradeRequest gradeRequest)
    {
        gradeService.add(gradeRequest);
    }

    /// <summary>Edit existing grade</summary>
    /// <response code="400">Invalid grade data</response>
    /// <response code="404">Grade not found</response>
    [HttpPatch("{gradeId:int}")]
    public void edit([FromBody] GradeRequest gradeRequest, int gradeId)
    {
        gradeService.edit(gradeRequest, gradeId);
    }

    /// <summary>Delete existing grade</summary>
    /// <response code="404">Grade not found</response>
    /// <response code="409">Grade is referenced by other data</response>
    [HttpDelete("{gradeId:int}")]
    public void delete(int gradeId)
    {
        gradeService.delete(gradeId);
    }
}


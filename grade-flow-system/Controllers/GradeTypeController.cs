using System.ComponentModel.DataAnnotations;
using grade_flow_system.Models.DTO.GradeType;
using grade_flow_system.Services;
using Microsoft.AspNetCore.Mvc;

namespace grade_flow_system.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GradeTypeController(GradeTypeService gradeTypeService) : ControllerBase
{
    /// <summary>Get all grade types</summary>
    [HttpGet("all")]
    public List<GradeTypeResponse> GetAll()
    {
        return gradeTypeService.getAll();
    }

    /// <summary>Add new grade type</summary>
    /// <response code="400">Grade type value already exists or invalid grade type data</response>
    [HttpPost]
    public void add([FromBody] GradeTypeRequest gradeTypeRequest)    //FromQuery bierze z parametrów
    {
        gradeTypeService.add(gradeTypeRequest);
    }

    /// <summary>Edit existing grade type</summary>
    /// <response code="400">Grade type value already exists or invalid grade type data</response>
    /// <response code="404">Grade type not found</response>
    [HttpPatch("{gradeTypeId:int}")]
    public void edit([FromBody] GradeTypeRequest gradeTypeRequest, int gradeTypeId)
    {
        gradeTypeService.edit(gradeTypeRequest, gradeTypeId);
    }

    /// <summary>Delete existing grade type</summary>
    /// <response code="404">Grade type not found</response>
    /// <response code="409">Grade type is referenced by other data</response>
    [HttpDelete("{gradeTypeId:int}")]
    public void delete(int gradeTypeId)
    {
        gradeTypeService.delete(gradeTypeId);
    }
}


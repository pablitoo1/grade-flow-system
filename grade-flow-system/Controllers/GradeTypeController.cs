using grade_flow_system.Models.DTO.GradeType;
using grade_flow_system.Services;
using Microsoft.AspNetCore.Mvc;

namespace grade_flow_system.Controllers;

[ApiController]
[Route("[controller]")]
public class GradeTypeController(GradeTypeService gradeTypeService) : ControllerBase
{
    /// <summary>Get all grade types</summary>
    [HttpGet]
    public List<GradeTypeResponse> GetAll()
    {
        return gradeTypeService.getAll();
    }

    /// <summary>Add new grade type</summary>
    /// <response code ="400">Grade type already exists</response>
    [HttpPost]
    public void add([FromBody] GradeTypeRequest gradeTypeRequest)    //FromQuery bierze z parametrów
    {
        gradeTypeService.add(gradeTypeRequest);
    }
}


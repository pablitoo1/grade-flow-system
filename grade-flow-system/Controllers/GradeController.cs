using grade_flow_system.Models.DTO.Grade;
using grade_flow_system.Services;
using Microsoft.AspNetCore.Mvc;

namespace grade_flow_system.Controllers;

[ApiController]
[Route("[controller]")]
public class GradeController(GradeService gradeService) : ControllerBase
{
    /// <summary>Get all grades</summary>
    [HttpGet]
    public List<GradeResponse> GetAll()
    {
        return gradeService.getAll();
    }

    /// <summary>Add new grade</summary>
    /// <response code ="400">Grade already exists</response>
    [HttpPost]
    public void add([FromBody]GradeRequest gradeRequest)    //FromQuery bierze z parametrów
    {
        gradeService.add(gradeRequest);
    } 
}


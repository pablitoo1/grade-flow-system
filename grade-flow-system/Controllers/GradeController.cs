using grade_flow_system.Models.DTO;
using grade_flow_system.Services;
using Microsoft.AspNetCore.Mvc;

namespace grade_flow_system.Controllers;

[ApiController]
[Route("[controller]")]
public class GradeController(GradeService gradeService) : ControllerBase
{
    [HttpGet]
    public List<GradeResponse> GetAll()
    {
        return gradeService.getAll();
    }
    [HttpPost]
    public void add([FromBody]GradeRequest gradeRequest)    //FromQuery bierze z parametrów
    {
        gradeService.add(gradeRequest);
    } 
}


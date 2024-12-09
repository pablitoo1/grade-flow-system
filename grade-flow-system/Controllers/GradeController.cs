using Microsoft.AspNetCore.Mvc;

namespace grade_flow_system.Controllers;

[ApiController]
[Route("[controller]")]
public class GradeController : ControllerBase
{
    [HttpGet]
    public string GetSth()
    {
        return "dupa";
    }
}


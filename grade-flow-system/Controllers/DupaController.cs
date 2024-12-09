using Microsoft.AspNetCore.Mvc;

namespace grade_flow_system.Controllers;

[ApiController]
[Route("[controller]")]
public class DupaController : ControllerBase
{
    [HttpGet]
    public string GetSth()
    {
        return "dupa";
    }
}


using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{


    
    
    [HttpPost]
    [Route("Rebuild database")]
    public void BuildDatabase()
    {
        
    }
}
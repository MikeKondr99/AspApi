using Microsoft.AspNetCore.Mvc;

namespace AspApi.Controllers;

/// <summary>
/// Тестовый
/// </summary>
[ApiController]
[Route("api")]
public class ApiController : ControllerBase 
{

    /// <summary>
    ///  Метод просто выдаёт код 200
    /// </summary>
    /// <returns>200</returns>
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(5);
    }

}

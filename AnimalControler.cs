using Microsoft.AspNetCore.Mvc;

namespace API;
[ApiController]
[Route("/animals")]
public class AnimalControler : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok("All animals");
    }
}
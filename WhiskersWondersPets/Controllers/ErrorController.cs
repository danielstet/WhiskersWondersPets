using Microsoft.AspNetCore.Mvc;

namespace WhiskersWondersPets.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index(Exception e)
        {
            // TODO wtite down the exception in a text file
            return BadRequest();
        }
    }
}

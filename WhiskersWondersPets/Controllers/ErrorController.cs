using Microsoft.AspNetCore.Mvc;

namespace WhiskersWondersPets.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger _logger;
        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
            _logger.LogDebug("Nlog is intergrated to Error Controller");
        }

        public IActionResult Test()
        {
            try
            {
                bool test = false;
                if (test)
                {
                    return Content("Test bool was set to true");
                }
                else {
                    throw new Exception("Test is working");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", ex);
            }
        }
        public IActionResult Index(Exception ex)
        {
            // TODO write down the exception in a text file
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
}

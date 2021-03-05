using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeckBuilderService.Controllers
{
    [Route("echo")]
    public class EchoController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return Ok("Test - Echo Controller is alive.");
        }
    }
}

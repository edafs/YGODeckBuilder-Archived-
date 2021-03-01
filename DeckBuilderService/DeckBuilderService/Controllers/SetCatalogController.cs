using System.Collections.Generic;
using System.Threading.Tasks;
using DeckBuilderService.Models.Data;
using DeckBuilderService.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeckBuilderService.Controllers
{
    [Route("SetCatalog")]
    public class SetCatalogController : Controller
    {
        private readonly SetCatalogService _setCatalogService;

        public SetCatalogController(SetCatalogService setCatalogService)
        {
            _setCatalogService = setCatalogService;
        }

        [HttpGet, Route("FullSetCatalog")]
        public async Task<IEnumerable<SetReleases>> GetSetCatalog()
        {
            var setCatalog = await this._setCatalogService.GetSetCatalog();
            return setCatalog;
        }

        [HttpGet, Route("IsAlive")]
        public IActionResult Echo()
        {
            return Ok("SetCatalogController is alive.");
        }
    }
}

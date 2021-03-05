﻿using System;
using System.Threading.Tasks;
using DeckBuilderService.Services;
using Microsoft.AspNetCore.Mvc;
using HttpStatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace DeckBuilderService.Controllers
{
    /// <summary>
    ///     The set catalog controller.
    /// </summary>
    [Route("SetCatalog")]
    public class SetCatalogController : Controller
    {
        /// <summary>
        ///     Singleton instance of <see cref="SetCatalogService"/>.
        /// </summary>
        private readonly SetCatalogService _setCatalogService;

        /// <summary>
        ///     Constructor for <see cref="SetCatalogController"/>. 
        /// </summary>
        public SetCatalogController(SetCatalogService setCatalogService)
        {
            if (setCatalogService == null)
            {
                throw new ArgumentNullException("Catalog Service is null");
            }

            _setCatalogService = setCatalogService;
        }

        /// <summary>
        ///     This returns the full set catalog. 
        /// </summary>
        /// <remarks>
        ///     HTTP GET method.
        /// </remarks>
        [HttpGet, Route("FullSetCatalog")]
        public async Task<IActionResult> GetSetCatalog()
        {
            var setCatalog = await this._setCatalogService.GetSetCatalog();

            if (setCatalog == null)
            {
                return StatusCode(HttpStatusCodes.Status503ServiceUnavailable);
            }

            return Ok(setCatalog);
        }

        /// <summary>
        ///     Echo.
        /// </summary>
        [HttpGet, Route("IsAlive")]
        public IActionResult Echo()
            => Ok("SetCatalogController is alive.");

    }
}

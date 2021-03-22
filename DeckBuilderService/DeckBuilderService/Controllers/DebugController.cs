using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeckBuilderService.Models.Response;
using DeckBuilderService.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeckBuilderService.Controllers
{
	[Route("Debug")]
	public class DebugController : Controller
	{
		public readonly SetCatalogService _setCatalogService;

		public DebugController(SetCatalogService setCatalogService)
		{
			_setCatalogService = setCatalogService
				?? throw new ArgumentNullException("Catalog Service is null");
		}

		[HttpGet, Route("Dupes")]
		public async Task<IActionResult> Dupes()
		{
			IEnumerable<CardSets> setLists = await this._setCatalogService.GetCardSets();

			IEnumerable<string> setCodes = setLists.Select(set => set.SetCode);

			List<string> duplicateCodes = setCodes.GroupBy(set => set)
			  .Where(set => set.Count() > 1)
			  .Select(set => set.Key)
			  .ToList();

			List<CardSets> duplicateSets = new List<CardSets>();

			foreach (var dupe in duplicateCodes)
			{
				List<CardSets> sets = setLists
					.Where(setLists => setLists.SetCode == dupe)
					.ToList();

				duplicateSets.AddRange(sets);
			}

			return Ok(duplicateSets);
		}
	}
}

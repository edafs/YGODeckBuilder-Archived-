using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DeckBuilderService.Models.Response;
using DeckBuilderService.Services;
using NUnit.Framework;

namespace DeckBuilder.Tests.YgoProDeckServices
{
	public class DebugUtilities
	{
		public DebugUtilities()
		{
		}

		[Test]
		public void ShowExistingDuplicatesFromCardSets()
		{
			SetCatalogService service = new SetCatalogService();

			List<CardSets> cardSets = service.GetCardSets().Result.ToList();

			var setCodes = cardSets.Select(set => set.SetCode);

			var duplicates = setCodes.GroupBy(set => set)
			  .Where(set => set.Count() > 1)
			  .Select(set => set.Key)
			  .ToList();

			foreach (var dupe in duplicates)
			{
				Debug.WriteLine(dupe);
				Console.WriteLine(dupe);
			}

			if(duplicates.Count > 0)
			{
				Assert.Fail("Review the duplicates.");
			}
		}
	}
}

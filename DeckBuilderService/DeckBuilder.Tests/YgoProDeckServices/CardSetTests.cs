using DeckBuilderService.Models.Response;
using DeckBuilderService.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DeckBuilder.Tests.YgoProDeckServices
{
    public class CardSetTests
    {
        private CardSetService Service
        {
            get { return new CardSetService(); }
        }

        [SetUp]
        public void Init()
        {

        }

        [Test]
        public void CanReturnCardSets()
        {
            IEnumerable<CardSets> results = this.Service.GetCardSets().Result;
            Assert.IsTrue(results.Count() == 858);
        }

        [Test]
        public void IsCardSetDeserializedProperly()
        {
            IEnumerable<CardSets> results = this.Service.GetCardSets().Result;

            CardSets cyberImpact = results
                .Where(cardSets => cardSets.set_code == "CDIP")
                .FirstOrDefault();

            if(cyberImpact == null)
            {
                Assert.Fail("Failed to find CyberDark Impact");
            }

            CardSets expectedResult = new CardSets()
            {
                set_name = "Cyberdark Impact",
                set_code = "CDIP",
                num_of_cards = 60,
                tcg_date = "2006-11-15"
            };

            Assert.IsTrue(
                string.Equals(cyberImpact.set_name
                    , expectedResult.set_name
                    , StringComparison.InvariantCultureIgnoreCase)
                , "Set names is not expected.");

            Assert.IsTrue(
                string.Equals(
                    cyberImpact.set_code
                    , expectedResult.set_code
                    , StringComparison.InvariantCultureIgnoreCase)
                , "Set codes is not expected.");

            Assert.IsTrue(
                cyberImpact.num_of_cards == expectedResult.num_of_cards
                , "Card count is not expected.");

            Assert.IsTrue(
                string.Equals(
                    cyberImpact.tcg_date
                    , expectedResult.tcg_date
                    , StringComparison.InvariantCultureIgnoreCase)
                , "TcgDate is not expected.");
        }
    }
}

using DeckBuilderService.Models.Data;
using DeckBuilderService.Models.Response;
using DeckBuilderService.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckBuilder.Tests.YgoProDeckServices
{
    public class CardSetTests
    {
        /// <summary>
        ///     Gets an instance of the <see cref="CardSetService"/>
        /// </summary>
        private SetCatalogService Service
        {
            get { return new SetCatalogService(); }
        }

        /// <summary>
        ///     Checks to see if the service returns the full Card Sets.
        /// </summary>
        /// <remarks>
        ///     If this test fails, a refresh is needed.
        /// </remarks>
        [Test]
        public void CanReturnCardSets()
        {
            IEnumerable<CardSets> results = this.Service.GetCardSets().Result;
            Assert.IsTrue(results.Count() == 858);
        }

        /// <summary>
        ///     Checks to see if the Card Sets are deserialized properly.
        /// </summary>
        [Test]
        public void IsCardSetDeserializedProperly()
        {
            #region Arange 
            CardSets expectedResult = new CardSets()
            {
                SetName = "Cyberdark Impact",
                SetCode = "CDIP",
                CardCount = 60,
                ReleaseDate = "2006-11-15"
            };
            #endregion

            #region Act
            IEnumerable<CardSets> results = this.Service.GetCardSets().Result;

            CardSets cyberImpact = results
                .Where(cardSets => cardSets.SetCode == "CDIP")
                .FirstOrDefault();
            #endregion

            #region Assert 
            if (cyberImpact == default(CardSets))
            {
                Assert.Fail("Failed to find CyberDark Impact");
            }
            
            Assert.IsTrue(
                string.Equals(cyberImpact.SetName
                    , expectedResult.SetName
                    , StringComparison.InvariantCultureIgnoreCase)
                , "Set names is not expected.");

            Assert.IsTrue(
                string.Equals(
                    cyberImpact.SetCode
                    , expectedResult.SetCode
                    , StringComparison.InvariantCultureIgnoreCase)
                , "Set codes is not expected.");

            Assert.IsTrue(
                cyberImpact.CardCount == expectedResult.CardCount
                , "Card count is not expected.");

            Assert.IsTrue(
                string.Equals(
                    cyberImpact.ReleaseDate
                    , expectedResult.ReleaseDate
                    , StringComparison.InvariantCultureIgnoreCase)
                , "TcgDate is not expected.");
            #endregion
        }

        /// <summary>
        ///     Tests the transforms between the data types.
        /// </summary>
        [Test]
        public void IsTransformDataCorrect()
        {
            #region Arrange
            List<CardSets> testSets = new List<CardSets>();

            CardSets fireFist = new CardSets()
            {
                SetName = "Fire Fists: Special Edition",
                SetCode = "FFSE",
                CardCount = 1,
                ReleaseDate = "2014-04-04"
            };

            CardSets phantomDarkness = new CardSets()
            {
                SetName = "Phantom Darkness",
                SetCode = "PTDN",
                CardCount = 100,
                ReleaseDate = "2008-02-13"
            };

            testSets.AddRange(
                new List<CardSets>() { fireFist, phantomDarkness }
            );

            #endregion

            #region Act
            List<SetReleases> transformedCatalog = this.Service
                .TransformToSetRelease(testSets)
                .ToList();
            #endregion

            #region Assert

            // Assert for FireFists
            SetReleases fireFistActual = transformedCatalog
                .FirstOrDefault(catalog => catalog.SetCode == "FFSE");
            Assert.IsTrue(string.Equals(fireFistActual.SetCode, "FFSE"
                , StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(string.Equals(fireFistActual.ReleaseDate, "2014-04-04"
                , StringComparison.InvariantCultureIgnoreCase));

            // Assert for Phantom Darkness
            SetReleases phantomDarknessActual = transformedCatalog
                .FirstOrDefault(catalog => catalog.SetCode == "PTDN");
            Assert.IsTrue(string.Equals(phantomDarknessActual.SetCode, "PTDN"
                , StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(string.Equals(phantomDarknessActual.ReleaseDate, "2008-02-13"
                , StringComparison.InvariantCultureIgnoreCase));

            #endregion
        }
    }
}

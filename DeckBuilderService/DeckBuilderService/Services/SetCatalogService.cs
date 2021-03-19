using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DeckBuilderService.Models.Data;
using DeckBuilderService.Models.Response;
using DeckBuilderService.Repository;

namespace DeckBuilderService.Services
{
    /// <summary>
    ///     Holds business logic for the set catalog.
    /// </summary>
    public class SetCatalogService
    {
        /// <summary>
        ///     Singleton instance of <see cref="SetCatalogRepo"/>. 
        /// </summary>
        public readonly SetCatalogRepo _setCatalogRepo;

        /// <summary>
        ///     Singleton instance of <see cref="HttpClient"/>.
        /// </summary>
        private readonly HttpClient WebClient;

        /// <summary>
        ///     Blank constructor.
        /// </summary>
        public SetCatalogService() => this.WebClient = new HttpClient();

        /// <summary>
        ///     Constructor for <see cref="SetCatalogService"/>.
        /// </summary>
        public SetCatalogService(SetCatalogRepo setCatalogRepo)
        {
            this._setCatalogRepo = setCatalogRepo
                ?? throw new ArgumentNullException("The set catalog repo failed to intialized.");

            this.WebClient = new HttpClient();
        }

        /// <summary>
        ///     Returns the set catalog. 
        /// </summary>
        public async Task<IEnumerable<SetReleases>> GetSetCatalog()
        {
            var setCatalog = await _setCatalogRepo.GetSetCatalog();
            if (setCatalog == null)
            {
                // TODO decide how to handle null catalog.
                return null;
            }
            else
            {
                return setCatalog;
            }
        }

        /// <summary>
        ///     Returns the first element when queried against the set catalog.
        /// </summary>
        public async Task<SetReleases> SearchFromSetCatalog(string key)
        {
            SetReleases queriedResult = await _setCatalogRepo.SearchFromCatalog(key);

            if (queriedResult == null)
            {
                return null;
            }

            return queriedResult;
        }

        /// <summary>
        ///     Transform collection of <see cref="CardSets"/> to <see cref="SetReleases"/>.
        /// </summary>
        /// <param name="cardSets"></param>
        /// <returns></returns>
        public IEnumerable<SetReleases> TransformToSetRelease(IEnumerable<CardSets> cardSets)
        {
            List<SetReleases> releases = new List<SetReleases>();

            foreach (CardSets set in cardSets)
            {
                releases.Add(new SetReleases()
                    {
                        SetCode = set.SetCode,
                        ReleaseDate = set.ReleaseDate
                    }
                );
            }

            return releases;
        }

        /// <summary>
        ///     Returns all the cards from the card sets API
        ///     in the form of <see cref="IEnumerable{CardSets}"/>.
        /// </summary>
        public async Task<IEnumerable<CardSets>> GetCardSets()
        {
            string response = await this.WebClient
                .GetStringAsync("https://db.ygoprodeck.com/api/v7/cardsets.php");

            List<CardSets> cardSets = JsonSerializer
                .Deserialize<List<CardSets>>(response);

            // Remove Sneak Peaks, their release date & code conflicts with offical sets.
            cardSets.RemoveAll(sets => sets.SetName
                .Contains("Sneak Peek", StringComparison.CurrentCultureIgnoreCase)
            );

            return cardSets;
        }
    }
}

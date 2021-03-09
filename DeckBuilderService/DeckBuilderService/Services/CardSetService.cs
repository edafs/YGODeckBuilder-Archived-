using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DeckBuilderService.Models.Response;

namespace DeckBuilderService.Services
{
    /// <summary>
    ///     Service calls to communicate with the YGOProDeck API.
    ///     https://db.ygoprodeck.com/api/v7/cardsets.php
    /// </summary>
    public class CardSetService
    {
        private readonly HttpClient WebClient;

        public CardSetService()
        {
            this.WebClient = new HttpClient();
        }

        public async Task<IEnumerable<CardSets>> GetCardSets()
        {
            string response = await this.WebClient
                .GetStringAsync("https://db.ygoprodeck.com/api/v7/cardsets.php");

            List<CardSets> cardSets = JsonSerializer
                .Deserialize<List<CardSets>>(response);

            return cardSets;
        }
    }
}

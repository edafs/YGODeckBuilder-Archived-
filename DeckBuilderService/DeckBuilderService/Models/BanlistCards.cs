using DeckBuilderService.Banlist;

namespace DeckBuilderService.Models
{
    public class BanlistCards
    {
        /// <summary>
        ///     The Id of the card.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Whether what restriction the card has on it.
        /// </summary>
        public Restrictions Restriction { get; set; }
    }
}

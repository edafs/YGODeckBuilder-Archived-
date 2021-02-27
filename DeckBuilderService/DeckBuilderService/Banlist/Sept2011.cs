using System;
using System.Collections.Generic;
using DeckBuilderService.Models;

namespace DeckBuilderService.Banlist
{
    /// <summary>
    ///     Handles the banlist.
    /// </summary>
    /// <remarks>
    ///     Effective: Sept 01, 2011 - March 01, 2012
    ///     Banlist available here: https://yugioh.fandom.com/wiki/September_2011_Lists_(TCG)
    /// </remarks>
    public class Sept2011 : IBanlist
    {
        public List<BanlistCards> BanList { get; set; }

        public Sept2011()
        {
            BuildBanlist();
        }

        public void BuildBanlist()
        {
            this.BanList = new List<BanlistCards>() { };

            this.PushCardToBanlist(82301904, Restrictions.Banned); // Chaos Emperor Dragon
            this.PushCardToBanlist(34124316, Restrictions.Banned); // Cyber Jar

            throw new NotImplementedException(
                "Sept2011.cs - BuildBanlist(): Cards in banlist are incomplete."
            );
        }

        /// <summary>
        ///     Checks whether the current card is banned.
        /// </summary>
        public bool IsRestricted()
        {
            if (this.BanList == null) { this.BuildBanlist(); }

            throw new NotImplementedException(
                "Sept2011.cs - IsRestricted(): Look up card to add vs. current deck"
            );
        }

        /// <summary>
        ///     Adds a card into the current banlist.
        /// </summary>
        private void PushCardToBanlist(int cardId, Restrictions restrictionStatus)
        {
            if (cardId < 1) { return; }
            if (this.BanList == null) { this.BanList = new List<BanlistCards>(); };

            BanlistCards cardToAdd = new BanlistCards()
            {
                Id = cardId,
                Restriction = restrictionStatus
            };

            this.BanList.Add(cardToAdd);
        }
    }
}

using System;
using System.Collections.Generic;
using DeckBuilderService.Models;

namespace DeckBuilderService.Banlist
{
    /// <summary>
    ///     Handles the banlist 
    /// </summary>
    public class Sept2011 : IBanlist
    {
        public List<BanlistCards> BanList { get; set; }

        public Sept2011()
        {
            BuildBanlist();
        }

        public void BuildBanlist()
        {
            this.BanList = new List<BanlistCards>()
            {
                // Chaos Emperor Dragon
                new BanlistCards() { Id = 82301904, Restriction = Restrictions.Banned },

                // Cyber Jar
                new BanlistCards() { Id = 34124316, Restriction = Restrictions.Banned }
            };
        }

        public bool IsRestricted()
        {
            return false;
        }
    }
}

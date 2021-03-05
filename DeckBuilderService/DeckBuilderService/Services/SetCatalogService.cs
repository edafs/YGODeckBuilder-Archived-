using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeckBuilderService.Models.Data;
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
        ///     Constructor for <see cref="SetCatalogService"/>.
        /// </summary>
        public SetCatalogService(SetCatalogRepo setCatalogRepo)
        {
            if (setCatalogRepo == null)
            {
                throw new ArgumentNullException("The set catalog repo failed to intialized.");
            }

            this._setCatalogRepo = setCatalogRepo;
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
    }
}

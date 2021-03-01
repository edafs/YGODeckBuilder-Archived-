using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeckBuilderService.Models.Data;
using DeckBuilderService.Repository;

namespace DeckBuilderService.Services
{
    public class SetCatalogService
    {
        public readonly SetCatalogRepo _setCatalogRepo;

        public SetCatalogService(SetCatalogRepo setCatalogRepo)
        {
            this._setCatalogRepo = setCatalogRepo;
        }

        public async Task<IEnumerable<SetReleases>> GetSetCatalog()
        {
            var setCatalog = await _setCatalogRepo.GetSetCatalog();
            return setCatalog;
        }
    }
}

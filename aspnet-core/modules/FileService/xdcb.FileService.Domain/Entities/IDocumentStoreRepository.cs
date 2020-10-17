using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using xdcb.FileService.DocumentStores;

namespace xdcb.FileService.Domain.Entities
{
    public interface IDocumentStoreRepository : IRepository<DocumentStore, Guid>
    {
        Task<List<DocumentStore>> InsertMultiAsync(List<DocumentStore> documentStores);
    }
}
using EFCore.BulkExtensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using xdcb.FileService.DocumentStores;
using xdcb.FileService.Domain.Entities;

namespace xdcb.FileService.EntityFrameworkCore
{
    public class DocumentStoreRepository : EfCoreRepository<FileServiceDbContext, DocumentStore, Guid>, IDocumentStoreRepository
    {
        private readonly IDbContextProvider<FileServiceDbContext> _dbContextProvider;

        public DocumentStoreRepository(IDbContextProvider<FileServiceDbContext> dbContextProvider)
         : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public async Task<List<DocumentStore>> InsertMultiAsync(List<DocumentStore> documentStores)
        {
            await _dbContextProvider.GetDbContext().BulkInsertAsync(documentStores);
            return documentStores;
        }
    }
}
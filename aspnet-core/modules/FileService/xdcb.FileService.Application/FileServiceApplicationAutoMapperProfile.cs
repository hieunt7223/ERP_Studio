using AutoMapper;
using xdcb.FileService.DocumentStoreDtos;
using xdcb.FileService.DocumentStores;

namespace xdcb.FileService
{
    public class FileServiceApplicationAutoMapperProfile : Profile
    {
        public FileServiceApplicationAutoMapperProfile()
        {
            CreateMap<DocumentStore, DocumentStoreDto>();
            CreateMap<DocumentStore, DocumentStoreModel>();
            CreateMap<CreateUpdateDocumentStoreDto, DocumentStore>();
            CreateMap<DocumentStoreDto, CreateUpdateDocumentStoreDto>();
            CreateMap<DocumentStoreModel, DocumentStoreDto>();
            CreateMap<DocumentStoreDto, DocumentStoreModel>();
        }
    }
}
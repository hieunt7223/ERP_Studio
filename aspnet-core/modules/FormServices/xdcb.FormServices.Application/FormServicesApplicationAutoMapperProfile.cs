using AutoMapper;
using xdcb.FormServices.ModuleGroup.Dtos;

namespace xdcb.FormServices
{
    public class FormServicesApplicationAutoMapperProfile : Profile
    {
        public FormServicesApplicationAutoMapperProfile()
        {
            #region ModuleGroup
            CreateMap<ModuleGroups.ModuleGroup, ModuleGroupDto>();
            CreateMap<CreateUpdateModuleGroupDto, ModuleGroups.ModuleGroup>();
            CreateMap<ModuleGroupDto, CreateUpdateModuleGroupDto>();
            #endregion
        }
    }
}
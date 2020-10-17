using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using xdcb.FormServices.ConfigColumns.Dtos;

namespace xdcb.FormServices.SDK
{
    public interface IConfigColumnsApi
    {
        [Get("/api/app/configColumn")]
        Task<List<ConfigColumnDto>> GetAll();

        [Post("/api/app/configColumn")]
        Task Create([Body] ConfigColumnDto info);

        [Get("/api/app/configColumn/{id}")]
        Task<ConfigColumnDto> GetObjectByID(int id);

        [Put("/api/app/configColumn/{id}")]
        Task Update(int id, [Body] ConfigColumnDto info);

        [Delete("/api/app/configColumn/{id}")]
        Task Delete(int id);

        [Get("/api/app/configColumn/byTableName")]
        Task<List<ConfigColumnDto>> GetObjectByTableName(string tableName);
    }
}

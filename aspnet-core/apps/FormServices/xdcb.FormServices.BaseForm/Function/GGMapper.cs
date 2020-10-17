using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xdcb.FormServices.BaseForm
{
    public static class GGMapper<T, T1>
    {
        public static T1 MapSimple(T obj)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<T, T1>(); });
            IMapper iMapper = config.CreateMapper();
            var result = iMapper.Map<T, T1>(obj);
            return result;
        }

        public static IList<T1> MapList(IList<T> list)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<T, T1>(); });
            IMapper iMapper = config.CreateMapper();
            var result = iMapper.Map<IList<T>, IList<T1>>(list);
            return result;
        }
    }
}

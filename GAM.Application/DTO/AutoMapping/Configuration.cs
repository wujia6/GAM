using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GAM.Core.Models;

namespace GAM.Application.DTO.AutoMapping
{
    public static class Configuration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new SourceProfile());
            });
        }
        
        public static IQueryable<M> ConvertDomainModels<D, M>(ICollection<D> dtos) where D: BaseDTO where M: BaseEntity
        {
            Mapper.Initialize(cfg => cfg.CreateMap<D, M>());
            return Mapper.Map<ICollection<D>, IQueryable<M>>(dtos);
        }
    }
}

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
        
        //public static IQueryable<TDest> ConvertDomainModels<TSource, TDest>(ICollection<TSource> dtos) where TSource: BaseDTO where TDest: BaseEntity
        //{
        //    Mapper.Initialize(cfg => cfg.CreateMap<TSource, TDest>());
        //    return Mapper.Map<ICollection<TSource>, IQueryable<TDest>>(dtos);
        //}
    }
}

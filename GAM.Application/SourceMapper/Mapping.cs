using System.Collections;
using System.Collections.Generic;
using AutoMapper;

namespace GAM.Application.SourceMapper
{
    public static class Mapping
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new Rules());
            });
        }
    }
}

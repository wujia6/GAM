using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace GAM.Application.DTO.AutoMapping
{
    public class Configuration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new SourceProfile());
            });
        }
    }
}

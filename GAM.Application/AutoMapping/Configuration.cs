using AutoMapper;

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
    }
}

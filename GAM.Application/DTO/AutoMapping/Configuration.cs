using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using AutoMapper;
using GAM.Core.Models.UserRoot;
using System.IO;
using Microsoft.AspNetCore.Http;

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


            IEnumerable<UserDTO> dtoUsers = new List<UserDTO>();
            Mapper.Initialize(cfg => cfg.CreateMap<UserDTO, User>());
            Mapper.Map<IEnumerable<UserDTO>, IQueryable<User>>(dtoUsers);
        }
    }
}

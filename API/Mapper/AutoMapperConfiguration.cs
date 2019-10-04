using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Mapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration() 
        {
            CreateMap<IdentityRole, RoleModel>().ReverseMap();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> roleManager;
        
        private readonly IMapper mapper;
        private readonly IConfigurationProvider configurationProvider;

        public RoleController(IMapper mapper)
        {
            this.mapper = mapper;
            this.configurationProvider = mapper.ConfigurationProvider;
        }

        public IPagedList<RoleModel> Get(string q, int? p, int pageSize = 10)
        {
            var roles = roleManager.Roles;
            int page = p ?? 1;

            if (!string.IsNullOrEmpty(q))
                foreach (var item in q.Split(' '))
                    roles = roles.Where(x => x.Name.Contains(item) || x.NormalizedName.Contains(item));

            return roles.ProjectTo<RoleModel>(configurationProvider).ToPagedList(page, pageSize);
        }

        public async Task<object> Post(RoleModel model)
        {
            var role = mapper.Map<IdentityRole>(model);
            var result = await roleManager.CreateAsync(role);
            if (result.Succeeded) return new { error = false, message = "Rol creado con exito." };
            else return new { error = true, message = string.Join(",", result.Errors.Select(x => x.Description)) };
        }

        public async Task<RoleModel> Find(string id) => mapper.Map<RoleModel>(await roleManager.FindByIdAsync(id));

        public async Task<RoleModel> Put(RoleModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);
            role.Name = model.Name;
            await roleManager.UpdateAsync(role);
            return model;
        }
        

    }
}
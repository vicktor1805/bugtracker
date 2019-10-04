using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class RoleModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public PagedInformation Pagination { get; set; }
    }
}

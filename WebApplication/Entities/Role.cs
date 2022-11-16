using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public string Decription { get; set; }

        public DateTime Created_at { get; set; }

        public DateTime Updated_at { get; set; }

        //[Key]
        //public long Id { get; set; }

        //[MaxLength(255)]
        //public string RoleName { get; set; }
    }
}

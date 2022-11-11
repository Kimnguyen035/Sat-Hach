using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Entities
{
    public class User : IdentityUser<long>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Created_at { get; set; }

        public DateTime Updated_at { get; set; }

        //[Key]
        //public long Id { get; set; }

        //[MaxLength(255)]
        //public string UserName { get; set; }

        //[MaxLength(255)]
        //public string PassWordHash { get; set; }

        //[MaxLength(255)]
        //public string Email { get; set; }
    }
}

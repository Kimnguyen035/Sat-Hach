using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Entities
{
    public class Permission
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(255)]
        public string PermissionName { get; set; }

        public long RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role role { get; set; }

        public DateTime Created_at { get; set; }

        public DateTime Updated_at { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Entities
{
    public class UserRole
    {
        [Key]
        public long Id { get; set; }

        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public User user { get; set; }

        public long RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role role { get; set; }
    }
}

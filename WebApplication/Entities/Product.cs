using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Entities
{
    public class Product
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public long? UserId { get; set; }

        [ForeignKey("UserId")]
        public User user { get; set; }

        public bool Status { get; set; }

        public DateTime Created_at { get; set; }

        public DateTime Updated_at { get; set; }
    }
}

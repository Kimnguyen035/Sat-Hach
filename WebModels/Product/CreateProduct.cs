using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModels
{
    public class CreateProduct
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModels
{
    public class Producted
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public long? UserId { get; set; }

        public bool Status { get; set; }

        public DateTime Created_at { get; set; }

        public DateTime Updated_at { get; set; }
    }
}

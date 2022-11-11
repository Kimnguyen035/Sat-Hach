using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModels
{
    public class Roled
    {
        public long Id { get; set; }

        public string roleName { get; set; }
        
        public string Decription { get; set; }

        public DateTime Created_at { get; set; }

        public DateTime Updated_at { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModels
{
    public class Usered
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string PassWordHash { get; set; }

        public string Email { get; set; }

        public DateTime Created_at { get; set; }

        public DateTime Updated_at { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModels
{
    public class StatusResponse
    {
        public int StatusCode { get; set; }

        public string Messages { get; set; }
        
        public string Token { get; set; }
    }
}

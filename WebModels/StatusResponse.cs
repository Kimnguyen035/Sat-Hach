using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModels
{
    public class StatusResponse<T>
    {
        public int StatusCode { get; set; }

        public string Messages { get; set; }

        public dynamic Data { get; set; }

        public StatusResponse(dynamic Data, int StatusCode = 200, string Messages = "Successfully!")
        {
            this.Data = Data;
            this.StatusCode = StatusCode;
            this.Messages = Messages;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModels.Pagination
{
    public class PageList<T>
    {
        public StatusResponse statusResponse { get; set; }

        public MetaData metaData { get; set; }

        public List<T> Items { get; set; }

        public PageList() {}

        public PageList(int StatusCode, string messages, string token)
        {
            statusResponse = new StatusResponse()
            {
                StatusCode = StatusCode,
                Messages = messages,
                Token = token
            };
        }

        public PageList(List<T> items, int count, int pageNumber, int pageSize)
        {
            metaData = new MetaData()
            {
                TotalCount = count,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };
            Items = items;
        }
    }
}

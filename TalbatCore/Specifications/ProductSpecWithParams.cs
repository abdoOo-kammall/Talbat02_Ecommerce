using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalbatCore.Specifications
{
    public class ProductSpecWithParams
    {
        public string? Sort { get; set; }
        public int? BrandId { get; set; }

        public int? GategoryId { get; set; }

        private int pageSize;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > 10 ? 10 : value; }
        }
        public int PageIndex { get; set; } = 1;


    }
}

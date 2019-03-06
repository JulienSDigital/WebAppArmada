using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Armada.Helper
{
    public class Pagination
    {
        const int PAGE_SIZE = 3;
        const int PAGE_SIZE_LIMIT = 999;

        private int pageNumber = 1;
        private int pageSize = PAGE_SIZE;

        public int PageNumber { get => pageNumber; set => pageNumber = value; }
        public int PageSize { get => pageSize; set
            {
                pageSize = value > PAGE_SIZE_LIMIT ? PAGE_SIZE : value;
            }
        }
    }
}

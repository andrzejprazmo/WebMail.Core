using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMail.Application.Common.Helpers
{
    public static class Package
    {
        public static int GetPageCount(int totalCount, int pageSize)
        {
            if (totalCount > 0)
            {
                int pageCount = totalCount / pageSize;
                if (totalCount % pageSize > 0)
                {
                    return pageCount + 1;
                }
                return pageCount;
            }
            return 0;
        }
    }
}

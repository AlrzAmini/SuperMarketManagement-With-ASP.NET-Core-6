using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketManagement.Application.DTOs.Paging
{
    public class Pager
    {
        public static BasePaging Build(int pageNum, int totalEntitiesCount, int take, int pageCountAfterAndBefore)
        {
            var totalPages = (int)Math.Ceiling((decimal)totalEntitiesCount / take);

            return new BasePaging
            {
                PageNum = pageNum,
                TotalEntitiesCount = totalEntitiesCount,
                Take = take,
                Skip = (pageNum - 1) * take,
                StartPage = pageNum - pageCountAfterAndBefore <= 0 ? 1 : pageNum - pageCountAfterAndBefore,
                EndPage = pageNum + pageCountAfterAndBefore > totalPages ? totalPages : pageNum + pageCountAfterAndBefore,
                PageCountAfterAndBefore = pageCountAfterAndBefore,
                TotalPages = totalPages
            };
        }
    }
}

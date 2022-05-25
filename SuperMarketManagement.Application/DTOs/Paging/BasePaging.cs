using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketManagement.Application.DTOs.Paging
{
    public class BasePaging
    {
        public BasePaging()
        {
            PageNum = 1;
            
            // it comes from a class that stores solution constants
            Take = Consts.Paging.ItemPerPage;
            
            PageCountAfterAndBefore = 5;
        }

        public int PageNum { get; set; }

        public int TotalPages { get; set; }

        public int TotalEntitiesCount { get; set; }

        public int Take { get; set; }

        public int Skip { get; set; }

        public int StartPage { get; set; }

        public int EndPage { get; set; }
        
        public int PageCountAfterAndBefore { get; set; }

        public BasePaging GetCurrentPaging()
        {
            return this;
        }

    }
}

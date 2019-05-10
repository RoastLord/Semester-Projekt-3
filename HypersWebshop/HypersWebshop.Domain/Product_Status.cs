using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypersWebshop.Domain
{
     public enum Product_Status : int
    {
        Sold,
        Published,
        Unpublished,
        Tested,
        Untested,
        Rejected
    }
}

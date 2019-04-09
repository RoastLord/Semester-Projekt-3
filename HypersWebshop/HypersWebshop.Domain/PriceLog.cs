using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypersWebshop.Domain
{
    public class PriceLog
    {
        public DateTime Date { get; set; }
        public float SalesPrice { get; set; }

        public PriceLog(DateTime date, float salesPrice)
        {
            Date = date;
            SalesPrice = salesPrice;
        }

    }
}

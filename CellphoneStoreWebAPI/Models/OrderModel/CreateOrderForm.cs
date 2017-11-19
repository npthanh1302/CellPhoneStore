using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellphoneStoreWebAPI.Models
{
    public class CreateOrderForm
    {
        public Order OrderInfo { get; set; }
        public List<DetailedOrder> ListDetailedOrder { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CellphoneStoreWebAPI.Models.OrderModel
{
    public class OrderDetailView
    {
        public OrderDetailView(int orderID, string name, int price, int quantity)
        {
            this.OrderID = orderID;
            this.ItemName = name;
            this.Price = price;
            this.Quantity = quantity;
        }
        public int OrderID { get; set; }
        public string ItemName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }


    }
}

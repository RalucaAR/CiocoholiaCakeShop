using System;
using System.Collections.Generic;

namespace CakeShop.API.ViewModels
{
    public class MyOrderViewModel
    {
        public OrderViewModel OrderPlaceDetails { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime OrderPlacedTime { get; set; }
        public IEnumerable<MyCakeOrderInfo> CakeOrderInfos { get; set; }

    }

    public class MyCakeOrderInfo
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
    }
}

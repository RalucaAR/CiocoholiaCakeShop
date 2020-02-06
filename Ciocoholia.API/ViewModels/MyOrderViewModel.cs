using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace CakeShop.API.ViewModels
{
    public class MyOrderViewModel
    {
        public int Id { get; set; }
        public OrderViewModel OrderPlaceDetails { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime OrderPlacedTime { get; set; }
        public IEnumerable<MyCakeOrderInfo> CakeOrderInfos { get; set; }
        public string OrderState { get; set; }
        public List<SelectListItem> OrderStates { get; set; } = new List<SelectListItem>
        {
            new SelectListItem{ Value = "Waiting", Text = "Waiting"},
            new SelectListItem{ Value = "Delivering", Text = "Delivering"},
            new SelectListItem{ Value = "Delivered", Text = "Delivered"}
        };

    }

    public class MyCakeOrderInfo
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
    }
}

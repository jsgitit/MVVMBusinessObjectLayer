using System.Collections.Generic;

namespace MVVMBusinessObjectLayer.Models
{
    public class Cart
    {
        public int Id{ get; set; }
        public int CustomerID { get; set; }
        public List<CartItem> Items { get; set; } = new()
    }
}

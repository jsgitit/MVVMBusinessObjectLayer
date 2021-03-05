using MVVMBusinessObjectLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVVMBusinessObjectLayer.BusinessModels
{
    public class CartModel : Cart
    {
        private List<CartItemModel> items = new();  // new list of cart items (line items)
        
        // Override the Items collection property (using new keyword), changing to a list of CartItemModel,
        // Remember: CartItemModel inherits from CartItem.
        public new List<CartItemModel> Items // specific list of CartItems
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
            }
        }
        // This sets up a read-only property for the Total - it's not a method
        // By making Total a property it will work better with binding
        public decimal Total 
        {
            get
            {
                // Add up all the cart item totals
                decimal total = 0;
                foreach (var item in Items)
                {
                    total += item.Total;
                }
                return total;
            }
        }
    }
}

using MVVMBusinessObjectLayer.BusinessModels;
using MVVMBusinessObjectLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVVMBusinessObjectLayer.ViewModels
{
    public class IndexViewModel : IIndexViewModel
    {
        private readonly DataService dataService;

        public IndexViewModel(DataService dataService)
        {
            this.dataService = dataService;

            // Setup dummy shopping cart data
            // Normally the shopping cart would be injected

            // Set CustomerId for shopping cart
            ShoppingCart.CustomerId = 1;

            // Add a few shopping cart items
            ShoppingCart.Items.Add(new CartItemModel(dataService)
            {
                Id = 1,
                ProductId = 1,
                Quantity = 1
            });
            ShoppingCart.Items.Add(new CartItemModel(dataService)
            {
                Id = 2,
                ProductId = 2,
                Quantity = 2
            });
            ShoppingCart.Items.Add(new CartItemModel(dataService)
            {
                Id = 3,
                ProductId = 3,
                Quantity = 3
            });
        }
        public CartModel ShoppingCart { get; set; } = new();

        public void UpdateModels() // supports "Update Models" button on page
        {
            // For demo purposes only.
            // Update a property value from the ViewModel
            // This helps demonstrate the product's price updating on the UI
            dataService.Products[0].Price += (decimal)1.0;
        }
    }
}

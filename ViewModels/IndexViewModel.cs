using Microsoft.AspNetCore.Components;
using MVVMBusinessObjectLayer.BusinessModels;
using MVVMBusinessObjectLayer.Data;
using MVVMBusinessObjectLayer.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MVVMBusinessObjectLayer.ViewModels
{

    public class IndexViewModel : IIndexViewModel, IDisposable
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
            AddCartItem(new CartItem()
            {
                Id = 1,
                ProductId = 1,
                Quantity = 1
            });
            AddCartItem(new CartItem()
            {
                Id = 2,
                ProductId = 2,
                Quantity = 2
            });
            AddCartItem(new CartItem()
            {
                Id = 3,
                ProductId = 3,
                Quantity = 3
            });
            UpdateComputedValue();
        }

        public void AddCartItem(CartItem item)
        {
            // In order to hook the event, we need to control
            // adding and removing cart items
            var model = new CartItemModel(dataService)
            {
                Id = item.Id,
                ProductId = item.ProductId,
                Quantity = item.Quantity
            };
            model.Product.StateChanged += Product_StateChanged;
            ShoppingCart.Items.Add(model);
        }

        public void DeleteCartItem(CartItemModel item)
        {
            // Unhook the StateChanged event before removing from Items
            item.Product.StateChanged -= Product_StateChanged;
            ShoppingCart.Items.Remove(item);
        }
        private void Product_StateChanged()
        {
            // When a product's price changes, rebuild the computed summary string
            UpdateComputedValue();
        }

        public CartModel ShoppingCart { get; set; } = new();

        public void UpdateModels() // supports "Update Models" button on page
        {
            // For demo purposes only.
            // Update a property value from the ViewModel
            // This helps demonstrate the product's price updating on the UI
            dataService.Products[0].Price += (decimal)1.0;
        }
        public CartItemModel SelectedCartItemModel { get; set; }

        public async Task SelectCartItemModel(ChangeEventArgs args)
        {
            await Task.Delay(0);
            // Set the SelectedCartItemModel based on the item selected
            // in a <select> element
            SelectedCartItemModel = (from x in ShoppingCart.Items
                                     where x.Id == Convert.ToInt32(args.Value.ToString())
                                     select x).FirstOrDefault();

        }
        public string ComputedValue { get; set; }

        public void UpdateComputedValue()
        {
            var result = "Your cart contains ";
            foreach (var item in ShoppingCart.Items)
            {
                result += $"{item.Quantity} of {item.Product.Name} at an item cost of ${item.Product.Price}";
                if (item != ShoppingCart.Items.Last())
                    result += ", ";
                else
                    result += $". The total is ${ShoppingCart.Total}";
            }
            ComputedValue = result;
        }
        /// <summary>
        /// We're using IDisposable for disposing events after use.
        /// See time index 16:45, episode 25 for more info.
        /// after the end of life of this class we need to unhook
        /// the StateChanged event for ALL items
        /// </summary>
        public void Dispose()
        {
            foreach (var item in ShoppingCart.Items)
            {
                item.Product.StateChanged -= Product_StateChanged;
            }
        }

    }
}

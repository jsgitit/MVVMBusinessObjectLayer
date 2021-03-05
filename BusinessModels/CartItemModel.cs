using MVVMBusinessObjectLayer.Data;
using MVVMBusinessObjectLayer.Models;
using System.Linq;

namespace MVVMBusinessObjectLayer.BusinessModels
{
    public class CartItemModel : CartItem
    {
        private readonly DataService _dataService;

        public CartItemModel(DataService dataService)
        {
            _dataService = dataService;
        }

        // TIP! Override base properties and methods with the new keyword
        // It doesn't require virtual members
        public int productId;
        public new int ProductId
        {
            get
            {
                return productId;
            }
            set
            {
                productId = value;
                // Set the Product property, based on the productId
                Product = (from x in _dataService.Products
                           where x.Id == value
                           select x).FirstOrDefault();
            }
        }

        // Product will be availble to us in the UI.
        public ProductModel Product { get; set; }

        public decimal Total
        {
            get
            {
                // Calculate total for this cart item
                return (decimal)Quantity * Product.Price;
            }
        }
    }
}

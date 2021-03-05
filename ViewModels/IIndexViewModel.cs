using Microsoft.AspNetCore.Components;
using MVVMBusinessObjectLayer.BusinessModels;
using System.Threading.Tasks;

namespace MVVMBusinessObjectLayer.ViewModels
{
    // interface extracted to suppor the ViewModel,
    // remember to add scoped service in Startup.cs

    public interface IIndexViewModel
    {
        CartModel ShoppingCart { get; set; }

        void UpdateModels();

        // Handle an onchange event from a <select> element
        // for use with binding onchange event in the Index page
        Task SelectCartItemModel(ChangeEventArgs args);

        // This property will help us bind to the selected cart item in the Index page
        CartItemModel SelectedCartItemModel { get; set; }

        // ComputedValue is a string that represents the contents of the cart
        // I don't like this implementation personally, but it is a demo.

        string ComputedValue { get; set; }
        void UpdateComputedValue();

    }
}
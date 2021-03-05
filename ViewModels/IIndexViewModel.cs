using MVVMBusinessObjectLayer.BusinessModels;

namespace MVVMBusinessObjectLayer.ViewModels
{
    // interface extracted to suppor the ViewModel,
    // remember to add scoped service in Startup.cs

    public interface IIndexViewModel
    {
        CartModel ShoppingCart { get; set; }

        void UpdateModels();
    }
}
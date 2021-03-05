using MVVMBusinessObjectLayer.Models;
using System;

namespace MVVMBusinessObjectLayer.BusinessModels
{
    public class ProductModel : Product
    {
        public event Action StateChanged; // event delegate
        private void NotifyStateChanged() => StateChanged?.Invoke(); // call StateChanged event when needed, if it's not null.

        // Override Price property so we can raise the StateChanged event, after it has been set
        public new decimal Price
        {
            get
            {
                return base.Price;
            }
            set
            {
                // Wenever Price is updated in the Business logic, notify the ViewModel with this event
                base.Price = value;
                NotifyStateChanged();
            }
        }
    }


}

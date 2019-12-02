using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.UI.Interfaces.ViewModel.OrderPreparation
{
    public interface ISelectedProductsListViewModel
    {
        Task LoadProductOptionToOrderItemOptionsAsync(int productOptionId);
        Task LoadProductToOrderItemsAsync(int productId);
    }
}

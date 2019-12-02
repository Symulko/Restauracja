using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.UI.Interfaces.ViewModel.OrderPreparation
{
    public interface IProductListViewModel
    {
        Task LoadAsync(int productTypeId);
    }
}

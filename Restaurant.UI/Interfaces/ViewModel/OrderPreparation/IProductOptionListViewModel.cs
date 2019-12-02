using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.UI.Interfaces.ViewModel.OrderPreparation
{
    public interface IProductOptionListViewModel
    {
        Task LoadAsync(int productTypeId);
    }
}

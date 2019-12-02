using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.UI.Interfaces.ViewModel.OrderHistory
{
    public interface IOrderHistoryListViewModel
    {
        Task LoadAsync();
    }
}

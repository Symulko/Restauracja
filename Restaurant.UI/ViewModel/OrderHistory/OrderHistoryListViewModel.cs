using Restaurant.Model.ModelWrappers;
using Restaurant.UI.Data;
using Restaurant.UI.Helpers;
using Restaurant.UI.Interfaces.ViewModel.OrderHistory;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Restaurant.UI.ViewModel.OrderHistory
{
    public class OrderHistoryListViewModel : BindableBase, IOrderHistoryListViewModel
    {
        private IOrdersRepository _orderRepository;
        private ObservableCollection<OrderInfo> _orderInfos;
        public OrderHistoryListViewModel(
            IOrdersRepository orderRepository
            )
        {
            _orderRepository = orderRepository;
            _orderInfos = new ObservableCollection<OrderInfo>();
        }

        public async Task LoadAsync()
        {
            var orders = await _orderRepository.GetAllOrdersWithOrderItemsAsync();
            OrderInfos.Clear();
            foreach (var order in orders)
            {
                var orderInfoItem = new OrderInfo
                {
                    OrderId = order.Id,
                    Quantity = order.GetOrderItemsCount(),
                    OrderDate = order.OrderDate,
                    AmountTotal = order.Total()
                };
                OrderInfos.Add(orderInfoItem);
            }
        }

        public ObservableCollection<OrderInfo> OrderInfos
        {
            get
            {
                return _orderInfos;
            }
        }
    }
}

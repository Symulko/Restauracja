using Prism.Events;
using Restaurant.Model.Entities;
using Restaurant.UI.Data;
using Restaurant.UI.Event;
using Restaurant.UI.Helpers;
using Restaurant.UI.Interfaces.ViewModel.OrderPreparation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.UI.ViewModel.OrderPreparation
{
    public class SelectedProductsListViewModel : BindableBase, ISelectedProductsListViewModel
    {
        private IOrdersRepository _ordersRepository;
        private IEventAggregator _eventAggregator;
        private FullyObservableCollection<OrderItem> _orderItems;
        private decimal _total;
        private string _orderNotes;

        public SelectedProductsListViewModel(IOrdersRepository ordersRepository,
          IEventAggregator eventAggregator)
        {
            _orderItems = new FullyObservableCollection<OrderItem>();
            _ordersRepository = ordersRepository;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<AddProductToSelectedProductsViewEvent>()
              .Subscribe(OnAddProduct);
            _eventAggregator.GetEvent<AddProductOptionToSelectedProductsViewEvent>()
              .Subscribe(OnAddProductOption);
            _eventAggregator.GetEvent<NotesChangedEvent>()
              .Subscribe(OnNotesChanged);
            AddOrderCommand = new RelayCommand(OnAddOrder, CanAddOrder);
        }

        private async void OnAddProduct(int productId)
        {
            await LoadProductToOrderItemsAsync(productId);
        }

        public async Task LoadProductToOrderItemsAsync(int productId)
        {
            var product = await _ordersRepository.GetProductByIdAsync(productId);
            if (product == null) return;

            var orderItem = new OrderItem(product, 1);
            OrderItems.Add(orderItem);
            Total += product.Price;
        }

        private async void OnAddProductOption(int productOptionId)
        {
            await LoadProductOptionToOrderItemOptionsAsync(productOptionId);
        }

        public async Task LoadProductOptionToOrderItemOptionsAsync(int productOptionId)
        {
            var productOption = await _ordersRepository.GetProductOptionByIdAsync(productOptionId);
            if (productOption == null || OrderItems.Count == 0) return;
            var lastAddedOrderItem = OrderItems.Last();
            if (lastAddedOrderItem == null || (lastAddedOrderItem.Product.ProductTypeId != productOption.ProductTypeId)) return;
            if (!OrderItemOptionExistsInOrderItems(lastAddedOrderItem, productOptionId))
            {
                var orderItemOption = new OrderItemOption(productOption.Id, productOption, productOption.Price, 1);
                var orderItemOptions = lastAddedOrderItem.OrderItemOptions;
                orderItemOptions.Add(orderItemOption);
                lastAddedOrderItem.OrderItemOptions = new List<OrderItemOption>(orderItemOptions);
            }
            else
            {
                var orderItemOption = lastAddedOrderItem.OrderItemOptions
                    .FirstOrDefault(orderOption => orderOption.ProductOptionId == productOptionId);
                if (orderItemOption != null)
                {
                    orderItemOption.Quantity++;
                }
            }
            Total += productOption.Price;
        }

        private bool OrderItemOptionExistsInOrderItems(OrderItem orderItem, int productOptionId)
        {
            return orderItem.OrderItemOptions
                .SingleOrDefault(orderOption => orderOption.ProductOptionId == productOptionId) != null;
        }

        private void OnNotesChanged(string notes)
        {
            _orderNotes = notes;
        }

        private bool CanAddOrder()
        {
            return true;
        }

        private async void OnAddOrder()
        {
            var order = new Order(new Comment(_orderNotes), OrderItems.ToList());
            await _ordersRepository.AddOrderAsync(order);
            ClearSelectedProducts();
            var orderAsJson = SerializerResultAsJson(order);
            PublishSendOrderEmailEvent(orderAsJson);
        }

        private void ClearSelectedProducts()
        {
            OrderItems.Clear();
            Total = 0;
        }

        public string SerializerResultAsJson(Order order)
        {
            if(order == null) return " ";
            return Serializer<Order>.JsonSerializer(order);
        }
        public void PublishSendOrderEmailEvent(string result)
        {
            _eventAggregator.GetEvent<SendOrderEmailEvent>()
                      .Publish(result);
        }

        public FullyObservableCollection<OrderItem> OrderItems
        {
            get
            {
                return _orderItems;
            }
        }

        public decimal Total
        {
            get
            {
                return _total;
            }
            set
            {
                _total = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand AddOrderCommand { get; private set; }
    }
}

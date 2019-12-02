using Prism.Events;
using Restaurant.Model.Entities;
using Restaurant.UI.Data;
using Restaurant.UI.Event;
using Restaurant.UI.Helpers;
using Restaurant.UI.Interfaces.ViewModel.OrderPreparation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Restaurant.UI.ViewModel.OrderPreparation
{
    public class ProductTypeListViewModel : BindableBase, IProductTypeListViewModel
    {
        private IOrdersRepository _orderRepository;
        private IEventAggregator _eventAggregator;
        private ProductType _selectedProductType;
        private ObservableCollection<ProductType> _productTypes;
        public ProductTypeListViewModel(
            IOrdersRepository orderRepository,
            IEventAggregator eventAggregator)
        {
            _orderRepository = orderRepository;
            _eventAggregator = eventAggregator;
            _productTypes = new ObservableCollection<ProductType>();
        }

        public async Task LoadAsync()
        {
            var lookup = await _orderRepository.GetProductTypesAsync();
            ProductTypes.Clear();
            foreach (var item in lookup)
            {
                ProductTypes.Add(item);
            }
        }

        public ObservableCollection<ProductType> ProductTypes
        {
            get
            {
                return _productTypes;
            }
        }

        public ProductType SelectedProductType
        {
            get { return _selectedProductType; }
            set
            {
                _selectedProductType = value;
                OnPropertyChanged();
                if (_selectedProductType != null)
                {
                    _eventAggregator.GetEvent<OpenProductViewEvent>()
                      .Publish(_selectedProductType.Id);
                    _eventAggregator.GetEvent<OpenProductOptionViewEvent>()
                      .Publish(_selectedProductType.Id);
                }
            }
        }
    }
}

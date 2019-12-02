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
    public class ProductListViewModel : BindableBase, IProductListViewModel
    {
        private IOrdersRepository _ordersRepository;
        private IEventAggregator _eventAggregator;
        private Product _selectedProduct;
        private ObservableCollection<Product> _products;
        public ProductListViewModel(IOrdersRepository ordersRepository,
          IEventAggregator eventAggregator)
        {
            _products = new ObservableCollection<Product>();
            _ordersRepository = ordersRepository;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenProductViewEvent>()
              .Subscribe(OnOpenProductView);
        }

        private async void OnOpenProductView(int productTypeId)
        {
            await LoadAsync(productTypeId);
        }

        public async Task LoadAsync(int productTypeId)
        {
            var products = await _ordersRepository.GetProductsByProductTypeIdAsync(productTypeId);

            Products.Clear();
            foreach (var item in products)
            {
                Products.Add(item);
            }
        }

        public ObservableCollection<Product> Products
        {
            get
            {
                return _products;
            }
        }

        public Product SelectedProduct
        {
            get
            {
                return _selectedProduct;
            }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged();
                if (_selectedProduct != null)
                {
                    _eventAggregator.GetEvent<AddProductToSelectedProductsViewEvent>()
                      .Publish(_selectedProduct.Id);
                    _selectedProduct = null;
                }
            }
        }
    }
}

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
    public class ProductOptionListViewModel : BindableBase, IProductOptionListViewModel
    {
        private IOrdersRepository _ordersRepository;
        private IEventAggregator _eventAggregator;
        private ProductOption _selectedProductOption;
        private ObservableCollection<ProductOption> _productOptions;

        public ProductOptionListViewModel(IOrdersRepository ordersRepository,
          IEventAggregator eventAggregator)
        {
            _productOptions = new ObservableCollection<ProductOption>();
            _ordersRepository = ordersRepository;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenProductOptionViewEvent>()
              .Subscribe(OnOpenProductOptionView);
        }

        private async void OnOpenProductOptionView(int productTypeId)
        {
            await LoadAsync(productTypeId);
        }

        public async Task LoadAsync(int productTypeId)
        {
            var productOptions = await _ordersRepository.GetProductOptionsByIdAsync(productTypeId);

            ProductOptions.Clear();
            foreach (var item in productOptions)
            {
                ProductOptions.Add(item);
            }
        }

        public ObservableCollection<ProductOption> ProductOptions
        {
            get
            {
                return _productOptions;
            }
        }


        public ProductOption SelectedProductOption
        {
            get
            {
                return _selectedProductOption;
            }
            set
            {
                _selectedProductOption = value;
                OnPropertyChanged();
                if (_selectedProductOption != null)
                {
                    _eventAggregator.GetEvent<AddProductOptionToSelectedProductsViewEvent>()
                      .Publish(_selectedProductOption.Id);
                    _selectedProductOption = null;
                }
            }
        }
    }
}

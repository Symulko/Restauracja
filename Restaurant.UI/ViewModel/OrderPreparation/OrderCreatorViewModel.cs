using Restaurant.UI.Helpers;
using Restaurant.UI.Interfaces.ViewModel.OrderPreparation;
using System.Threading.Tasks;

namespace Restaurant.UI.ViewModel.OrderPreparation
{
    public class OrderCreatorViewModel : BindableBase, IOrderCreatorViewModel
    {
        public OrderCreatorViewModel(
            IProductTypeListViewModel productTypeListViewModel,
            IProductListViewModel productListViewModel,
            ISelectedProductsListViewModel selectedProductsListViewModel,
            IProductOptionListViewModel productOptionListViewModel,
            IOrderNotesViewModel orderNotesViewModel)
        {
            ProductTypeListViewModel = productTypeListViewModel;
            ProductListViewModel = productListViewModel;
            SelectedProductsListViewModel = selectedProductsListViewModel;
            ProductOptionListViewModel = productOptionListViewModel;
            OrderNotesViewModel = orderNotesViewModel;
        }
        public async Task LoadAsync()
        {
            await ProductTypeListViewModel.LoadAsync();
        }

        public IProductTypeListViewModel ProductTypeListViewModel { get; }
        public IProductOptionListViewModel ProductOptionListViewModel { get; }
        public IProductListViewModel ProductListViewModel { get; }
        public ISelectedProductsListViewModel SelectedProductsListViewModel { get; }
        public IOrderNotesViewModel OrderNotesViewModel { get; }
    }
}

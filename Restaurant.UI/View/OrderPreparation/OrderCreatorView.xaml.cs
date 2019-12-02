using Restaurant.UI.ViewModel.OrderPreparation;
using System.Windows;
using System.Windows.Controls;

namespace Restaurant.UI.View.OrderPreparation
{
    public partial class OrderCreatorView : UserControl
    {
        public OrderCreatorView()
        {
            InitializeComponent();
            Loaded += OrderCreatorView_Loaded;
        }

        private async void OrderCreatorView_Loaded(object sender, RoutedEventArgs e)
        {
            if(this.DataContext != null)
            {
                var _viewModel = (OrderCreatorViewModel)this.DataContext;
                await _viewModel.LoadAsync();
            }
        }
    }
}

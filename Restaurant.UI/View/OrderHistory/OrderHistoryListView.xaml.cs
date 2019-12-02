using Restaurant.UI.ViewModel.OrderHistory;
using System.Windows;
using System.Windows.Controls;

namespace Restaurant.UI.View.OrderHistory
{
    public partial class OrderHistoryListView : UserControl
    {
        public OrderHistoryListView()
        {
            InitializeComponent();
            Loaded += OrderHistoryListView_Loaded;
        }

        private async void OrderHistoryListView_Loaded(object sender, RoutedEventArgs e)
        {
            if(this.DataContext != null)
            {
                var _viewModel = (OrderHistoryListViewModel)this.DataContext;
                await _viewModel.LoadAsync();
            }
        }
    }
}

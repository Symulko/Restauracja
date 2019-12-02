using Restaurant.UI.Helpers;
using Restaurant.UI.Interfaces.ViewModel.Email;
using Restaurant.UI.Interfaces.ViewModel.OrderHistory;
using Restaurant.UI.Interfaces.ViewModel.OrderPreparation;
using Restaurant.UI.ViewModel.Email;
using Restaurant.UI.ViewModel.OrderHistory;
using Restaurant.UI.ViewModel.OrderPreparation;

namespace Restaurant.UI.ViewModel
{
    public class MainViewModel : BindableBase
    {
        private BindableBase _CurrentViewModel;
        public MainViewModel(IOrderCreatorViewModel orderCreatorViewModel,
            IOrderHistoryListViewModel orderHistoryListViewModel,
            IEmailOptionsViewModel emailOptionsViewModel
            )
        {
            OrderCreatorViewModel = orderCreatorViewModel;
            OrderHistoryListViewModel = orderHistoryListViewModel;
            EmailOptionsViewModel = emailOptionsViewModel;
            NavCommand = new RelayCommand<string>(OnNav);
        }
        public IEmailOptionsViewModel EmailOptionsViewModel { get; }
        public IOrderCreatorViewModel OrderCreatorViewModel { get; }
        public IOrderHistoryListViewModel OrderHistoryListViewModel { get; }

        public BindableBase CurrentViewModel
        {
            get
            {
                return _CurrentViewModel;
            }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "orderHistory":
                    CurrentViewModel = (OrderHistoryListViewModel)OrderHistoryListViewModel;
                    break;
                case "emailSettings":
                    CurrentViewModel = (EmailOptionsViewModel)EmailOptionsViewModel;
                    break;
                case "newOrder":
                default:
                    CurrentViewModel = (OrderCreatorViewModel)OrderCreatorViewModel;
                    break;
            }
        }

        public RelayCommand<string> NavCommand { get; private set; }
    }
}

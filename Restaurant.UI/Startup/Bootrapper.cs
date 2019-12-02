using Autofac;
using Prism.Events;
using Restaurant.DataAccess;
using Restaurant.UI.Data;
using Restaurant.UI.Interfaces;
using Restaurant.UI.Interfaces.ViewModel.Email;
using Restaurant.UI.Interfaces.ViewModel.OrderHistory;
using Restaurant.UI.Interfaces.ViewModel.OrderPreparation;
using Restaurant.UI.Services;
using Restaurant.UI.ViewModel;
using Restaurant.UI.ViewModel.Email;
using Restaurant.UI.ViewModel.OrderHistory;
using Restaurant.UI.ViewModel.OrderPreparation;

namespace Restaurant.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterType<RestaurantDbContext>().AsSelf();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<ProductTypeListViewModel>().As<IProductTypeListViewModel>();
            builder.RegisterType<ProductListViewModel>().As<IProductListViewModel>();
            builder.RegisterType<SelectedProductsListViewModel>().As<ISelectedProductsListViewModel>();
            builder.RegisterType<ProductOptionListViewModel>().As<IProductOptionListViewModel>();
            builder.RegisterType<OrderCreatorViewModel>().As<IOrderCreatorViewModel>();
            builder.RegisterType<OrderHistoryListViewModel>().As<IOrderHistoryListViewModel>();
            builder.RegisterType<EmailOptionsViewModel>().As<IEmailOptionsViewModel>();
            builder.RegisterType<OrderNotesViewModel>().As<IOrderNotesViewModel>();

            builder.RegisterType<EmailSender>().As<IEmailSender>();
            builder.RegisterType<OrdersRepository>().As<IOrdersRepository>();

            return builder.Build();
        }
    }
}

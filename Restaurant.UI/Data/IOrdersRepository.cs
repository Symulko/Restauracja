using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.Model.Entities;

namespace Restaurant.UI.Data
{
    public interface IOrdersRepository
    {
        Task<Order> AddOrderAsync(Order order);
        Task DeleteOrderAsync(int orderId);
        Task<List<Order>> GetAllOrdersAsync();
        Task<List<ProductOption>> GetProductOptionsAsync();
        Task<List<ProductOption>> GetProductOptionsByIdAsync(int productOptionId);
        Task<ProductOption> GetProductOptionByIdAsync(int productOptionId);
        Task<List<Product>> GetProductsAsync();
        Task<List<Product>> GetProductsByProductTypeIdAsync(int productTypeId);
        Task<List<Order>> GetAllOrdersWithOrderItemsAsync();
        Task<List<ProductType>> GetProductTypesAsync();
        Task<Order> UpdateOrderAsync(Order order);
        Task<Product> GetProductByIdAsync(int productId);
    }
}
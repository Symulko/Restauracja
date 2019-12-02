using Microsoft.EntityFrameworkCore;
using Restaurant.DataAccess;
using Restaurant.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Restaurant.UI.Data
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly RestaurantDbContext _context = new RestaurantDbContext();

        public OrdersRepository()
        {

        }
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .ToListAsync();
        }

        public async Task<List<Order>> GetAllOrdersWithOrderItemsAsync()
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.OrderItemOptions)
                .ToListAsync();
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            if (!_context.Orders.Local.Any(o => o.Id == order.Id))
            {
                _context.Orders.Attach(order);
            }
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var order = _context.Orders.Include("OrderItems").Include("OrderItems.OrderItemOptions").FirstOrDefault(o => o.Id == orderId);
                if (order != null)
                {
                    foreach (OrderItem item in order.OrderItems)
                    {
                        _context.OrderItems.Remove(item);
                    }
                    _context.Orders.Remove(order);
                }
                await _context.SaveChangesAsync();
                scope.Complete();
            }
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
        }

        public async Task<List<ProductOption>> GetProductOptionsAsync()
        {
            return await _context.ProductOptions.ToListAsync();
        }

        public async Task<ProductOption> GetProductOptionByIdAsync(int productOptionId)
        {
            return await _context.ProductOptions.FirstOrDefaultAsync(po=> po.Id == productOptionId);
        }

        public async Task<List<ProductOption>> GetProductOptionsByIdAsync(int productTypeId)
        {
            return await _context.ProductOptions.Where(po=>po.ProductTypeId == productTypeId).ToListAsync();
        }

        public async Task<List<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<List<Product>> GetProductsByProductTypeIdAsync(int productTypeId)
        {
            return await _context.Products
                .Where(p => p.ProductTypeId == productTypeId)
                .ToListAsync();
        }
    }
}

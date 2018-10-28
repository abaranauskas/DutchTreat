using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Data
{
    public class DutchRepository : IDutchRepository
    {
        private readonly DutchContext _ctx;
        private readonly ILogger<DutchRepository> _logger;

        public DutchRepository(DutchContext ctx, ILogger<DutchRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;


        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }

        public void AddOrder(Order newOrder)
        {
            foreach (var item in newOrder.Items)
            {
                item.Product = _ctx.Products.Find(item.Product.Id);
            }

            AddEntity(newOrder);
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            if (includeItems)
            {
                return _ctx.Orders.OrderBy(o => o.OrderDate)
                              .Include(o => o.Items)
                              .ThenInclude(i => i.Product)
                              .ToList();
            }
            return _ctx.Orders.ToList();
        }

        public IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems)
        {
            if (includeItems)
            {
                return _ctx.Orders.Where(o => o.User.UserName == username)
                              .Include(o => o.Items)
                              .ThenInclude(i => i.Product)
                              .ToList();
            }

            return _ctx.Orders.Where(o => o.User.UserName == username).ToList();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("GetAllProducts was called!");

                return _ctx.Products
                           .OrderBy(p => p.Title)
                           .ToList(); ;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to get all products: {ex}");
                return null;
            }

           
        }

        public Order GetOrdersById(string username, int id)
        {
            return _ctx.Orders                       
                       .Include(o => o.Items)
                       .ThenInclude(i => i.Product)
                       .Where(o => o.User.UserName == username)
                       .FirstOrDefault(o => o.Id == id);
                              

            //return _ctx.Orders.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Product> GetProdyctByCategory(string categoryName)
        {
            return _ctx.Products.Where(p => p.Category == categoryName).ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}

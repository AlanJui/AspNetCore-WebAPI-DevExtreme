using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc;

using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class NorthwindController : Controller
    {
        private readonly NorthwindContext _context;

        public NorthwindController(NorthwindContext context)
        {
            _context = context;
        }

        [HttpGet("list-order")]
        public object Orders(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_context.Orders, loadOptions);
        }

        [HttpGet("order-details/{orderID}")]
        public object GetOrderDetails([FromRoute] int orderID, DataSourceLoadOptions options)
        {
            return DataSourceLoader.Load(
                from i in _context.OrderDetails
                where i.OrderId == orderID
                select new
                {
                    Product = i.Product.ProductName,
                    Price = i.UnitPrice,
                    Quantity = i.Quantity,
                    Sum = i.UnitPrice * i.Quantity
                },
                options
            );
        }

        [HttpGet("order-details")]
        public object OrderDetails(int orderID, DataSourceLoadOptions options)
        {
            return DataSourceLoader.Load(
                from i in _context.OrderDetails
                where i.OrderId == orderID
                select new
                {
                    Product = i.Product.ProductName,
                    Price = i.UnitPrice,
                    Quantity = i.Quantity,
                    Sum = i.UnitPrice * i.Quantity
                },
                options
            );
        }

        [HttpGet("customers-lookup")]
        public object CustomersLookup(DataSourceLoadOptions options)
        {
            return DataSourceLoader.Load(
                from c in _context.Customers
                orderby c.CompanyName
                select new
                {
                    Value = c.CustomerId,
                    Text = $"{c.CompanyName} ({c.Country})"
                },
                options
            );
        }

        [HttpGet("shippers-lookup")]
        public object ShippersLookup(DataSourceLoadOptions options)
        {
            return DataSourceLoader.Load(
                from s in _context.Shippers
                orderby s.CompanyName
                select new
                {
                    Value = s.ShipperId,
                    Text = s.CompanyName
                },
                options
            );
        }

        [HttpGet("employees-lookup")]
        public object EmployeesLookup(DataSourceLoadOptions options)
        {
            return DataSourceLoader.Load(
                from e in _context.Employees
                orderby e.FirstName
                select new {
                    Value = e.EmployeeId,
                    Text = $"{e.FirstName} {e.LastName}"
                },
                options
            );
        }

        [HttpPut("update-order")]
        public IActionResult UpdateOrder(int key, string values)
        {
            var order = _context.Orders.First(o => o.OrderId == key);
            JsonConvert.PopulateObject(values, order);

            if (!TryValidateModel(order))
                return BadRequest(ModelState.ToFullErrorString());

            _context.SaveChanges();

            return Ok();
        }

        [HttpPost("insert-order")]
        public IActionResult InsertOrder(string values)
        {
            var order = new Order();
            JsonConvert.PopulateObject(values, order);

            if (!TryValidateModel(order))
                return BadRequest(ModelState.ToFullErrorString());

            _context.Orders.Add(order);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("delete-order")]
        public void DeleteOrder(int key)
        {
            var order = _context.Orders.First(o => o.OrderId == key);
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        [HttpGet("products")]
        public object Products(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(
                _context.Products.Include(p => p.Category),
                loadOptions
            );
        }
    }
}

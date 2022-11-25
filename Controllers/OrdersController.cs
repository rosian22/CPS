using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CPS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        public static List<Order> OrdersDB = new List<Order>();

        public OrdersController(ILogger<OrdersController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetOrders")]
        public IActionResult GetOrders()
        {
            return Ok(JsonConvert.SerializeObject(OrdersDB));
        }

        [HttpPost("ImportOrders")]
        public void ImportOrders()
        {
            var file = Request.Form?.Files[0];
            if(file == null)
            {
                return;
            }

            var xml = XDocument.Load(file.OpenReadStream());

            var orders = xml.Root?.Elements().Select(t =>
            {
                return new Order
                {
                    CustomerEmail = t.Attribute("CustomerEmail").Value.ToString(),
                    DateRequired = t.Attribute("DateRequired").Value.ToString(),
                    Size = double.Parse(t.Attribute("Size").Value.ToString()),
                    Notes = t.Attribute("Notes").Value.ToString(),
                    Quantity = int.Parse(t.Attribute("Quantity").Value.ToString()),
                    CustomerName = t.Attribute("CustomerName").Value.ToString()
                };
            }).ToList();

            foreach (var order in orders)
            {
                try
                {
                    Validator.ValidateObject(order, new ValidationContext(order), validateAllProperties: true);
                    OrdersDB.Add(order);
                }
                catch (Exception)
                {
                }
            }
        }




    }
}
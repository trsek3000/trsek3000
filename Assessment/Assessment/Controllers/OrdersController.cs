using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assessment.Models;
using Assessment.Services;

namespace Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderRepository orderRepository;
        public OrdersController(IOrderRepository _orderRepository)
        {
            orderRepository = _orderRepository;
        }

        [HttpGet]
        [Route("GetNewOrderNumber")]
        public async Task<IActionResult> GetAlGetNewOrderNumberlOrders()
        {
            try
            {
                var client = await orderRepository.GetAllOrders();
                if (client == null)
                {
                    return NotFound();
                }

                return Ok(client);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("GetOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var client = await orderRepository.GetAllOrders();
                if (client == null)
                {
                    return NotFound();
                }

                return Ok(client);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }



        [HttpGet("{OrderId}")]
        //[Route("GetOrders")]
        public async Task<IActionResult> GetOrders(int? OrderId)
        {
            if (OrderId == null)
            {
                return BadRequest();
            }

            try
            {
                var client = await orderRepository.GetOrder(OrderId);

                if (client == null)
                {
                    return NotFound();
                }

                return Ok(client);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddOrder")]
        public async Task<IActionResult> AddOrder([FromBody] Order model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var clientId = await orderRepository.AddOrder(model);
                    if (clientId > 0)
                    {
                        return Ok(clientId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int? id)
        {
            int result = 0;

            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await orderRepository.DeleteOrder(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] Order model, int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await orderRepository.UpdateOrder(model, id);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                             "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }

    }
}

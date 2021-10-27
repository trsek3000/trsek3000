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
    public class OrderDetailsController : ControllerBase
    {
        IOrderDetailRepository orderdetailRepository;
        public OrderDetailsController(IOrderDetailRepository _orderdetailRepository)
        {
            orderdetailRepository = _orderdetailRepository;
        }

        [HttpGet]
        //[Route("GetAllOrderDetails")]
        public async Task<IActionResult> GetAllPrGetAllOrderDetailsoducts()
        {
            try
            {
                var client = await orderdetailRepository.GetAllOrderDetails();
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



        [HttpGet("{OrderDetailId}")]
        //[Route("GetProduct")]
        public async Task<IActionResult> GetOrderDetail(int? OrderDetailId)
        {
            if (OrderDetailId == null)
            {
                return BadRequest();
            }

            try
            {
                var client = await orderdetailRepository.GetOrderDetail(OrderDetailId);

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
        //[Route("AddOrderDetail")]
        public async Task<IActionResult> AddOrderDetail([FromBody] OrderDetail model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var clientId = await orderdetailRepository.AddOrderDetail(model);
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
        public async Task<IActionResult> DeleteOrderDetail(int? id)
        {
            int result = 0;

            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await orderdetailRepository.DeleteOrderDetail(id);
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
        public async Task<IActionResult> UpdateOrderDetail([FromBody] OrderDetail model, int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await orderdetailRepository.UpdateOrderDetail(model, id);

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

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
    public class ProductsController : ControllerBase
    {
        IProductRepository productRepository;
        public ProductsController(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }

        [HttpGet]
        //[Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var client = await productRepository.GetAllProducts();
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



        [HttpGet("{ProductId}")]
        //[Route("GetProduct")]
        public async Task<IActionResult> GetProduct(int? ProductId)
        {
            if (ProductId == null)
            {
                return BadRequest();
            }

            try
            {
                var client = await productRepository.GetProduct(ProductId);

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
        //[Route("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] Product model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var clientId = await productRepository.AddProduct(model);
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
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            int result = 0;

            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await productRepository.DeleteProduct(id);
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
        public async Task<IActionResult> UpdateProduct([FromBody] Product model, int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await productRepository.UpdateProduct(model,id) ;

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

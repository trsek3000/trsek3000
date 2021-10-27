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
    public class UsersController : ControllerBase
    {
        IUserRepository userRepository;
        public UsersController(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        [HttpGet]
        //[Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var client = await userRepository.GetAllUsers();
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



        [HttpGet("{UserId}")]
        //[Route("GetProduct")]
        public async Task<IActionResult> GetUser(int? UserId)
        {
            if (UserId == null)
            {
                return BadRequest();
            }

            try
            {
                var client = await userRepository.GetUser(UserId);

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


        ////For user login   

        //[HttpPost]
        //[Route("Login")]
        //public async Task<IActionResult> Login(User model)
        //{
        //    var LG = await userRepository.Login(model);

        //    return Ok(LG);
        //}

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] User model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var clientId = await userRepository.Login(model);
                    if (!(clientId is not
                    {
                    null))
                    {
                    }
                    else}

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

        [HttpPost]
        [Route("Register")]
        public async Task<int> Register([FromBody] User model)
        {
            //if (ModelState.IsValid)
            //{
                //try
                //{
                    var clientId = await userRepository.AddUser(model);
                   
                        return clientId;
                   
                //}
                //catch (Exception)
                //{

                //    return BadRequest();
                //}

            ////}

            //return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int? id)
        {
            int result = 0;

            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await userRepository.DeleteUser(id);
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
        public async Task<IActionResult> UpdateUser([FromBody] User model, int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await userRepository.UpdateUser(model, id);

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

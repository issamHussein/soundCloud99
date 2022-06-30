using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.SoundCloud.Core.Data;
using Tahaluf.SoundCloud.Core.Service;

namespace Tahaluf.SoundCloud.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;

        public CartController(ICartService _cartService)
        {
            cartService = _cartService;
        }

        [HttpGet]
        [Route("GetUserCart/{id}")]
        public List<Cart> GetUserCart(int id)
        {
            return cartService.GetUserCart(id);
        }

        [HttpPost]
        [Route("CreateCart")]
        public bool CreateCart([FromBody] Cart cart)
        {
            return cartService.CreateCart(cart);
        }

        [HttpPut]
        [Route("UpdateCart")]

        public bool UpdateCart([FromBody] Cart cart)
        {
            return cartService.UpdateCart(cart);
        }

        [HttpDelete]
        [Route("DeleteCart/{id}")]
        public bool DeleteCart(int id)
        {
            return cartService.DeleteCart(id);
        }


    }
}

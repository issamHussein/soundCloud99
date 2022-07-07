using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.SoundCloud.Core.Data;
using Tahaluf.SoundCloud.Core.Repository;
using Tahaluf.SoundCloud.Core.Service;

namespace Tahaluf.SoundCloud.Infra.Service
{
    public class CartService : ICartService
    {


        private readonly ICartRepository cartRepository;

        public CartService(ICartRepository _cartRepository)
        {
            cartRepository = _cartRepository;
        }

        public bool CreateCart(Cart cart)
        {
            return cartRepository.CreateCart(cart);
        }

        public bool DeleteCart(int id)
        {
            return cartRepository.DeleteCart(id);
        }

        public List<Cart> GetUserCart(int id)
        {
            return cartRepository.GetUserCart(id);
        }

        public bool UpdateCart(Cart cart)
        {
            return cartRepository.UpdateCart(cart);
        }
    }
}

using Nyobanyoba.Factory;
using Nyobanyoba.Model;
using Nyobanyoba.Modules;
using Nyobanyoba.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nyobanyoba.Handler
{
    public class CartHandler
    {
        public static Response<List<MsCart>> GetCartsByUserId(int uid)
        {
            List<MsCart> cart = CartRepository.GetCartsByUserId(uid);

            if (cart.Count == 0)
            {
                return new Response<List<MsCart>>()
                {
                    Success = false,
                    Message = "Failed",
                    Payload = null
                };
            }

            return new Response<List<MsCart>>()
            {
                Success = true,
                Message = "Success",
                Payload = cart
            };
        }

        public static Response<MsCart> CreateCart(int uid, int sid, int quantity)
        {
            MsCart cart = CartFactory.CreateCart(uid, sid, quantity);

            bool isCreated = CartRepository.CreateCart(cart);

            if (!isCreated)
            {
                return new Response<MsCart>()
                {
                    Success = false,
                    Message = "Failed",
                    Payload = null
                };
            }
            return new Response<MsCart>()
            {
                Success = true,
                Message = "Success",
                Payload = cart
            };
        }

        public static Response<MsCart> UpdateCart(int cid, int uid, int sid, int quantity)
        {
            MsCart cart = CartRepository.GetCartByUserIdAndSupplementId(uid, sid);
            MsCart newcart = CartFactory.CreateCart(uid, sid, quantity);
            newcart.CartID = cid;
            newcart.Quantity = quantity;

            bool isCreated = CartRepository.UpdateCart(uid, sid, newcart.CartID, newcart.Quantity);

            if (!isCreated)
            {
                return new Response<MsCart>()
                {
                    Success = false,
                    Message = "Failed",
                    Payload = null
                };
            }
            return new Response<MsCart>()
            {
                Success = true,
                Message = "Success",
                Payload = cart
            };
        }

        public static Response<List<MsCart>> CheckoutCart(int uid)
        {
            var checkEmpty = GetCartsByUserId(uid);

            if (!checkEmpty.Success)
            {
                return new Response<List<MsCart>>()
                {
                    Success = false,
                    Message = "Cart cannot be found",
                    Payload = null
                };
            }
            else
            {
                if (checkEmpty.Payload.Count == 0)
                {
                    return new Response<List<MsCart>>()
                    {
                        Success = false,
                        Message = "Cart cannot be empty",
                        Payload = null
                    };
                }
            }

            var firstResponse = TransactionHeaderHandler.CreateTransactionHeader(uid, DateTime.Now, "Unhandled");

            if (!firstResponse.Success)
            {
                return new Response<List<MsCart>>()
                {
                    Success = false,
                    Message = "Failed to checkout cart.",
                    Payload = null
                };
            }

            var secondResponse = GetCartsByUserId(uid);

            if (!secondResponse.Success)
            {
                return new Response<List<MsCart>>()
                {
                    Success = false,
                    Message = "Failed to checkout cart.",
                    Payload = null
                };
            }


            int tid = firstResponse.Payload.TransactionID;
            List<MsCart> carts = secondResponse.Payload;

            foreach (MsCart cart in carts)
            {
                var thirdResponse = TransactionDetailHandler.CreateTransactionDetail(tid, cart.SupplementID, cart.Quantity);

                if (!thirdResponse.Success)
                {
                    return new Response<List<MsCart>>()
                    {
                        Success = false,
                        Message = "Failed to checkout cart.",
                        Payload = null
                    };
                }
            }

            var fourthResponse = DeleteCart(uid);

            if (!fourthResponse.Success)
            {
                return new Response<List<MsCart>>()
                {
                    Success = false,
                    Message = "Failed to checkout cart.",
                    Payload = null
                };
            }

            return new Response<List<MsCart>>()
            {
                Success = true,
                Message = "Succesfully checkout cart.",
                Payload = null
            };
        }

        public static Response<List<MsCart>> DeleteCart(int uid)
        {
            List<MsCart> carts = CartRepository.GetCartsByUserId(uid);

            foreach (MsCart cart in carts)
            {
                bool isDeleted = CartRepository.DeleteCart(cart.CartID);

                if (!isDeleted)
                {
                    return new Response<List<MsCart>>()
                    {
                        Success = false,
                        Message = "Failed",
                        Payload = null
                    };
                }
            }

            return new Response<List<MsCart>>()
            {
                Success = true,
                Message = "Success",
                Payload = null
            };
        }

        
    }
}
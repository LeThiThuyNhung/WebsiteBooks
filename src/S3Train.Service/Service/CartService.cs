using System;
using System.Collections.Generic;
using System.Linq;
using S3Train.Contract;
using S3Train.Domain;



//namespace S3Train.Service
//{
//    public class CartService: GenenicServiceBase<Product>, ICartService
//    {
//        public CartService(ApplicationDbContext dbContext) : base(dbContext)
//        {
//        }

//        public IList<Product> GetCart(Guid Id, int Quantity)
//        {
//            var cart = DbContext.Products.Where(x => x.Id == Id)
//                .Select (n => new Product
//                {
//                    Id = n.Id,
//                    NameProduct = n.NameProduct,
//                    ImagePath = n.ImagePath,
//                    Price = n.Price,
//                }).ToList();
//            return cart;
//        }
//    }
//}

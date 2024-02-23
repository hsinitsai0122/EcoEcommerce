using BLL_EcoEcommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL = BLL_EcoEcommerce.Entities;
using DAL = DAL_EcoEcommerce.Entities;

namespace BLL_EcoEcommerce.Mappers
{
    internal static class Mapper
    {
        #region Product
        public static BLL.Product ToBLL(this DAL.Product entity)
        {
            if (entity == null) return null;
            return new BLL.Product(
                entity.Id_Product,
                entity.Name,
                entity.Description,
                entity.Price,
                Enum.Parse<Category>(entity.ProCateg),
                Enum.Parse<EcoScore>(entity.EcoCriteria)
                
            );
        }

        public static DAL.Product ToDAL(this BLL.Product entity)
        {
            if (entity == null) return null;
            return new DAL.Product
            {
                Id_Product = entity.Id_Product,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                ProCateg = entity.ProCateg.ToString(),
                EcoCriteria = entity.EcoCriteria.ToString()
            };
        }
        #endregion

        #region Media
        public static BLL.Media ToBLL(this DAL.Media entity)
        {
            if (entity == null) return null;
            return new BLL.Media(
                entity.Id_Media,
                entity.ImgUrl,
                entity.Id_Product
                                                        );
        }

        public static DAL.Media ToDAL(this BLL.Media entity)
        {
            if (entity == null) return null;
            return new DAL.Media
            {
                Id_Media = entity.Id_Media,
                ImgUrl = entity.ImgUrl,
                Id_Product = entity.Id_Product
            };
        }

        #endregion

        #region Cart
        public static BLL.Cart ToBLL(this DAL.Cart entity)
        {
            if (entity == null) return null;
            return new BLL.Cart(
                entity.Id_Cart,
                entity.OrderNumber,
                entity.OrderDate
                        );
        }

        public static DAL.Cart ToDAL(this BLL.Cart entity)
        {
            if (entity == null) return null;
            return new DAL.Cart
            {
                Id_Cart = entity.Id_Cart,
                OrderNumber = entity.OrderNumber,
                OrderDate = entity.OrderDate
            };
        }

        #endregion

        #region OrderItem

        public static BLL.OrderItem ToBLL(this DAL.OrderItem entity)
        {
            if (entity == null) return null;
            return new BLL.OrderItem(
                    entity.Id_OrderItem,
                    entity.Id_Product,
                    entity.Id_Cart,
                    entity.Quantity
                  );
        }

        public static DAL.OrderItem ToDAL(this BLL.OrderItem entity)
        {
            if (entity == null) return null;
            return new DAL.OrderItem
            {
                Id_OrderItem = entity.Id_OrderItem,
                Id_Product = entity.Id_Product,
                Id_Cart = entity.Id_Cart,
                Quantity = entity.Quantity
            };
        }

        #endregion



    }
}

using ASP_EcoEcommerce.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using BLL = BLL_EcoEcommerce.Entities;


namespace ASP_EcoEcommerce.Handlers
{
    public static class Mapper
    {
        #region Product
        public static ProductListItemViewModel ToListItem(this BLL.Product entity)
        {
            if (entity == null) return null;
            return new ProductListItemViewModel
            {
                Id_Product = entity.Id_Product,
                Name = entity.Name,
                Price = entity.Price,
                ProCateg = entity.ProCateg,
                EcoCriteria = entity.EcoCriteria,

            };
        }

        public static ProductDetailsViewModel ToDetails(this BLL.Product entity)
        {
            if (entity == null) return null;
            return new ProductDetailsViewModel
            {
                Id_Product = entity.Id_Product,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                ProCateg = entity.ProCateg,
                EcoCriteria = entity.EcoCriteria
            };
        }

        public static BLL.Product ToBLL(this ProductCreateForm entity)
        {
            if (entity == null) return null;
            return new BLL.Product(
                0,
                entity.Name,
                entity.Description,
                entity.Price,
                entity.ProCateg,
                entity.EcoCriteria
                );

        }

        public static ProductEditForm ToEdit(this BLL.Product entity)
        {
            if (entity == null) return null;
            return new ProductEditForm
            {
                Id_Product = entity.Id_Product,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                ProCateg = entity.ProCateg,
                EcoCriteria = entity.EcoCriteria
            };
        }

        public static BLL.Product ToBLL(this ProductEditForm entity)
        {
            if (entity == null) return null;
            return new BLL.Product(
                entity.Id_Product,
                entity.Name,
                entity.Description,
                entity.Price,
                entity.ProCateg,
                entity.EcoCriteria
                );

        }


        public static ProductDeleteForm ToDelete(this BLL.Product entity)
        {
            if (entity is null) return null;
            return new ProductDeleteForm() {
                Id_Product = entity.Id_Product,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                ProCateg = entity.ProCateg,
                EcoCriteria = entity.EcoCriteria
            };
        }
    }



    #endregion

    //#region Cart
    //public static CartListItemViewModel ToListItem(this BLL.Cart entity)
    //{
    //    if (entity == null) return null;
    //    return new CartListItemViewModel
    //    {
    //        Id_Cart = entity.Id_Cart,
    //        OrderNumber = entity.OrderNumber,
    //        OrderDate = entity.OrderDate,
    //        OrderItems = entity.OrderItems.Select(d => d.ToListItem()),
    //    };
    //}


    //#endregion

    //#region OrderItem
    //public static OrderItemListItemViewModel ToListItem(this BLL.OrderItem entity)
    //{
    //    if (entity == null) return null;
    //    return new OrderItemListItemViewModel
    //    {
    //        Id_OrderItem = entity.Id_OrderItem,
    //        Quantity = entity.Quantity,
    //        Id_Product = entity.Id_Product,
    //        ItemPrice = entity.ItemPrice,
    //        Id_Cart = entity.Id_Cart
    //    };
    //}

    //#endregion


}

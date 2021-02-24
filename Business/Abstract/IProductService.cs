using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);//Belirlenen aralıktaki fiyatları getir
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);
        IResult Add(Product product); //void'i data olmadığı çin IResult yaptık, diğerlerini data var diye IDataResult olarak aldık.
        IResult Update(Product product);

        //http:(internet protokolü ,bir kaynağa ulaşmak için izlediğimiz yol)
        //RESTFUL --> HTTP --> 
    }
}

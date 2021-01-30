using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //DAL: Data Access Layer
    public interface IProductDal
    {
        //Aşağıdaki methodlar default olarak "public"tir.

        //Entities altındaki Product class'ını çağırabilmek için önce Entities refere edilir,
        //ardından Concrete yukarıya eklenir.
        List<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        List<Product> GetAllByCategory(int categoryId);
    }
}

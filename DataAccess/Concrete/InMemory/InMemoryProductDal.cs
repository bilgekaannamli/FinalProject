﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        //ctor --- constructor
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product
                {
                    ProductId = 1,
                    CategoryId = 1,
                    ProductName = "Bardak",
                    UnitPrice = 15,
                    UnitsInStock = 15,
                },
                new Product
                {
                    ProductId = 2,
                    CategoryId = 1,
                    ProductName = "Kamera",
                    UnitPrice = 500,
                    UnitsInStock = 3,
                },
                new Product
                {
                    ProductId = 3,
                    CategoryId = 2,
                    ProductName = "Telefon",
                    UnitPrice = 1500,
                    UnitsInStock = 2,
                },
                new Product
                {
                    ProductId = 4,
                    CategoryId = 1,
                    ProductName = "Klavye",
                    UnitPrice = 150,
                    UnitsInStock = 65,
                },
                new Product
                {
                    ProductId = 5,
                    CategoryId = 2,
                    ProductName = "Fare",
                    UnitPrice = 85,
                    UnitsInStock = 1,
                },

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //Çözüm:
            // LINQ-- - Language Integrated Query
            // "=>" : Lambda 
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            //Seçenek 2:
            //Aşağıdaki bloğu kullanmak yerine LINQ kullandık.
            //Product productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}
            //_products.Remove(productToDelete);                     

            //Seçenek 1:
            //Aşağıdaki satır burada işe yaramaz.
            //Bu satır sadece değer siler; burada referans silmemiz gerekir.
            //_products.Remove(product);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //Methoda verilen ID ile listedeki IDleri karşılaştırır.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}

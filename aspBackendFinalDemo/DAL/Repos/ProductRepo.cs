﻿using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ProductRepo : Repo, IRepo<Product, int, Product>,IProductFeature
    {
        public Product Create(Product obj)
        {
            db.Products.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Products.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public List<Product> Get()
        {
            return db.Products.ToList();
        }

        public List<Product> SearchByName(string name)
        {
            return db.Products.Where(x=>x.Name.Contains(name)).ToList();
        }

        public Product Update(Product obj)
        {
            var exobj = Get(obj.Id);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return exobj;
        }
    }
}

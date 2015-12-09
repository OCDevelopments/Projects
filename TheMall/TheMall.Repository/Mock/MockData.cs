using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheMall.Model;
using TheMall.Repository.Mock;

namespace TheMall.Repository.Mock
{
    public class MockData<TEntity> : IDisposable, IDataContext<TEntity> where TEntity : class
    {
        private readonly Product[] _products;
        private readonly Store[] _stores;
        private readonly Category[] _categories;
        private IQueryable<TEntity> _entity;

        public MockData()
        {
            //===========================Product=================================

            Product[] products =
            {
                new Product
                {
                    Id = 1,
                    //StoreId = 1,
                    Name = "Chair",
                    //Category = "Groceries",
                    //CategoryId = 1,
                    Price = 13.99M,
                    Currency = "ILS",
                    Details = "Include 4 legs!",
                    ProductCategory = new Category {Id = 1, Name = "Groceries"},
                    ProductStore = new Store {Id = 1, Name = "Fastraza shop"}
                },
                new Product
                {
                    Id = 2,
                    //StoreId = 1,
                    Name = "Table",
                    //Category = "Toys",
                    //CategoryId = 1,
                    Price = 3.75M,
                    Currency = "ILS",
                    Details = "Include 3 legs!",
                    ProductCategory = new Category {Id = 1, Name = "Toys"},
                    ProductStore = new Store {Id = 1, Name = "ToyRus"}
                },
                new Product
                {
                    Id = 3,
                    //StoreId = 2,
                    Name = "Hammer",
                    //Category = "Hardware",
                    //CategoryId = 2,
                    Price = 16.99M,
                    Currency = "ILS",
                    Details = "Include driller!",
                    ProductCategory = new Category {Id = 2, Name = "Hardware"},
                    ProductStore = new Store {Id = 2, Name = "Home Center"}
                },
                new Product
                {
                    Id = 4,
                    //StoreId = 3,
                    Name = "Hammer2",
                    //Category = "Hardware2",
                    //CategoryId = 3,
                    Price = 14.99M,
                    Currency = "ILS",
                    Details = "Include driller + zriller!",
                    ProductCategory = new Category {Id = 3, Name = "Hardware2"},
                    ProductStore = new Store {Id = 3, Name = "Home Center2"}
                }
            };

            _products = products;
            //===========================Store=================================

            Store[] stores =
            {
                new Store
                {
                    Id = 1,
                    Name = "Store1",
                },
                new Store
                {
                    Id = 2,
                    Name = "Store2",
                },
                new Store
                {
                    Id = 3,
                    Name = "Store3",
                }
            };

            _stores = stores;
            //==========================Category===============================

            Category[] categories =
            {
                new Category
                {
                    Id = 1,
                    Name = "Cat1",
                },
                new Category
                {
                    Id = 2,
                    Name = "Cat2",
                },
                new Category
                {
                    Id = 3,
                    Name = "Cat3",
                }
            };

            _categories = categories;
        }

        public IEnumerable<Product> Product
        {
            get { return _products; }
        }

        public IEnumerable<Store> Store
        {
            get { return _stores; }
        }

        public IEnumerable<Category> Category
        {
            get { return _categories; }
        }


        public IQueryable<TEntity> Entity
        {
            get
            {
                if (typeof(TEntity) == typeof(Product))
                {
                    _entity = (IQueryable<TEntity>)Product.AsQueryable();
                }

                if (typeof(TEntity) == typeof(Store))
                {
                    _entity = (IQueryable<TEntity>)Store.AsQueryable();
                }

                if (typeof(TEntity) == typeof(Category))
                {
                    _entity = (IQueryable<TEntity>)Category.AsQueryable();
                }

                return _entity;
            }
        }

        public void Dispose()
        {

        }
    }
}
using EcomProj.DataAccess.Data;
using EcomProj.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProj.DataAccess.Repository
{

    public class UnitOfWork : IUnitOfWork
    {

        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ShoppingCart = new ShoppingCartRepository(_db);


        }

        public IShoppingCartRepository ShoppingCart { get;private set; }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}

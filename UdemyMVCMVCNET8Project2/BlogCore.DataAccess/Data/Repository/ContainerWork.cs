using BlogCore.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyMVCMVCNET8Project2.Data;

namespace BlogCore.DataAccess.Data.Repository
{
    public class ContainerWork : IContainerWork
    {
        private readonly ApplicationDbContext _db;

        public ContainerWork(ApplicationDbContext db)
        {
            _db = db;
            CategoryRepository = new CategoryRepository(_db);
        }

        public ICategoryRepository CategoryRepository { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

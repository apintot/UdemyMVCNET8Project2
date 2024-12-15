using BlogCore.DataAccess.Data.Repository.IRepository;
using BlogCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyMVCMVCNET8Project2.Data;

namespace BlogCore.DataAccess.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            Category objDb = _db.Category.FirstOrDefault(s => s.Id == category.Id);
            objDb.Order = category.Order;

            _db.SaveChanges();
        }
    }
}

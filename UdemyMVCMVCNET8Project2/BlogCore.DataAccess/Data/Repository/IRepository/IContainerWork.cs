using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.DataAccess.Data.Repository.IRepository
{
    public interface IContainerWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }

        void Save();
    }
}

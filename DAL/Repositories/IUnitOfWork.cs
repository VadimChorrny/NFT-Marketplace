using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Repository<Animation> AnimationRepository { get; }
        Repository<Cart> CartRepository { get; }
        Repository<Category> CategoryRepository { get; }
        Repository<Collection> CollectionRepository { get; }
        void Save();
    }
}

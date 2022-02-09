using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext context;

        private Repository<Animation> animationRepository;
        private Repository<Cart> cartRepository;
        private Repository<Category> categoryRepository;
        private Repository<Collection> collectionRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;

            animationRepository = new Repository<Animation>(context);
            cartRepository = new Repository<Cart>(context);
            categoryRepository = new Repository<Category>(context);
            collectionRepository = new Repository<Collection>(context);
        }

        public Repository<Animation> AnimationRepository => animationRepository;
        public Repository<Cart> CartRepository => cartRepository;
        public Repository<Category> CategoryRepository => categoryRepository;
        public Repository<Collection> CollectionRepository => collectionRepository;

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

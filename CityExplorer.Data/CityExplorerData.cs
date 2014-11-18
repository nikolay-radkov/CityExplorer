namespace CityExplorer.Data
{
    using CityExplorer.Data.Contracts;
    using CityExplorer.Data.Repositories.Base;
    using CityExplorer.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CityExplorerData : ICityExplorerData
    {
        private readonly ICityExplorerDbContext context;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public CityExplorerData(ICityExplorerDbContext context)
        {
            this.context = context;
        }

        public ICityExplorerDbContext Context
        {
            get
            {
                return this.context;
            }
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }


        public IDeletableEntityRepository<City> Cities
        {
            get { return this.GetDeletableEntityRepository<City>(); }
        }

        public IDeletableEntityRepository<Comment> Comments
        {
            get { return this.GetDeletableEntityRepository<Comment>(); }
        }

        public IDeletableEntityRepository<Continent> Continents
        {
            get { return this.GetDeletableEntityRepository<Continent>(); }
        }

        public IDeletableEntityRepository<Country> Countries
        {
            get { return this.GetDeletableEntityRepository<Country>(); }
        }

        public IDeletableEntityRepository<Event> Events
        {
            get { return this.GetDeletableEntityRepository<Event>(); }
        }

        public IDeletableEntityRepository<Photo> Photos
        {
            get { return this.GetDeletableEntityRepository<Photo>(); }
        }

        public IDeletableEntityRepository<Place> Places
        {
            get { return this.GetDeletableEntityRepository<Place>(); }
        }

        public IDeletableEntityRepository<Rating> Ratings
        {
            get { return this.GetDeletableEntityRepository<Rating>(); }
        }

        public IDeletableEntityRepository<VIP> VIPs
        {
            get { return this.GetDeletableEntityRepository<VIP>(); }
        }

        public IDeletableEntityRepository<Feedback> Feedbacks
        {
            get { return this.GetDeletableEntityRepository<Feedback>(); }
        }

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">Thrown if the context has been disposed.</exception>
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }

    }
}

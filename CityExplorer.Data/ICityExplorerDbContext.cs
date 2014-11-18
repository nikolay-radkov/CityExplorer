namespace CityExplorer.Data
{
    using CityExplorer.Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface ICityExplorerDbContext
    {
        IDbSet<City> Cities { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Continent> Continents { get; set; }

        IDbSet<Country> Countries { get; set; }

        IDbSet<Event> Events { get; set; }

        IDbSet<Photo> Photos { get; set; }

        IDbSet<Place> Places { get; set; }

        IDbSet<Rating> Ratings { get; set; }

        IDbSet<VIP> VIPs { get; set; }

        IDbSet<Feedback> Feedbacks { get; set; }

        DbContext DbContext { get; }

        int SaveChanges();

        void Dispose();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}

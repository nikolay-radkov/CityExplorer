namespace CityExplorer.Data
{
    using CityExplorer.Data.Contracts;
    using CityExplorer.Models;

    public interface ICityExplorerData
    {
        ICityExplorerDbContext Context { get; }

        IDeletableEntityRepository<City> Cities { get; }

        IDeletableEntityRepository<Comment> Comments { get; }

        IDeletableEntityRepository<Continent> Continents { get; }

        IDeletableEntityRepository<Country> Countries { get; }

        IDeletableEntityRepository<Event> Events { get; }

        IDeletableEntityRepository<Photo> Photos { get; }

        IDeletableEntityRepository<Place> Places { get; }

        IDeletableEntityRepository<Rating> Ratings { get; }

        IDeletableEntityRepository<VIP> VIPs { get; }

        IRepository<User> Users { get; }

        int SaveChanges();
    }
}

namespace CityExplorer.Data
{
    using System.Data.Entity;
    using CityExplorer.Data.Migrations;
    using CityExplorer.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class CityExplorerDbContext : IdentityDbContext<User>
    {
        public CityExplorerDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CityExplorerDbContext, Configuration>());
        }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Continent> Continents { get; set; }
        
        public virtual IDbSet<Country> Countries { get; set; }
        
        public virtual IDbSet<Event> Events { get; set; }
        
        public virtual IDbSet<Photo> Photos { get; set; }
        
        public virtual IDbSet<Place> Places { get; set; }
        
        public virtual IDbSet<Rating> Ratings { get; set; }
        
        public virtual IDbSet<VIP> VIPs { get; set; }

        public static CityExplorerDbContext Create()
        {
            return new CityExplorerDbContext();
        }
    }
}

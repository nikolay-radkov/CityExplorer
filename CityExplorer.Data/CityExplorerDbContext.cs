namespace CityExplorer.Data
{
    using System.Linq;
    using System.Data.Entity;
    using CityExplorer.Data.Migrations;
    using CityExplorer.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using CityExplorer.Data.Contracts.CodeFirstConventions;
    using CityExplorer.Data.Contracts;
    using System;

    public class CityExplorerDbContext : IdentityDbContext<User>, ICityExplorerDbContext
    {
        public CityExplorerDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CityExplorerDbContext, Configuration>());
        }

        public CityExplorerDbContext()
            : this("DefaultConnection")
        {
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

        public virtual IDbSet<Feedback> Feedbacks { get; set; }

        public static CityExplorerDbContext Create()
        {
            return new CityExplorerDbContext();
        }


        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            this.ApplyDeletableEntityRules();
            return base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new IsUnicodeAttributeConvention());

            base.OnModelCreating(modelBuilder); // Without this call EntityFramework won't be able to configure the identity model
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        private void ApplyDeletableEntityRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (
                var entry in
                    this.ChangeTracker.Entries()
                        .Where(e => e.Entity is IDeletableEntity && (e.State == EntityState.Deleted)))
            {
                var entity = (IDeletableEntity)entry.Entity;

                entity.DeletedOn = DateTime.Now;
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }
    }
}

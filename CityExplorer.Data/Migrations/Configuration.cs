namespace CityExplorer.Data.Migrations
{
    using CityExplorer.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<CityExplorerDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CityExplorerDbContext context)
        {
            if (!context.Continents.Any())
            {
                context.Continents.Add(
                  new Continent { Name = "Europe" }
                );
                context.Continents.Add(
                  new Continent { Name = "Asia" }
                  );
                context.Continents.Add(
                    new Continent { Name = "Africa" }
                );
                context.Continents.Add(
                    new Continent { Name = "North America" }
                );
                context.Continents.Add(
                    new Continent { Name = "South America" }
                );
                context.Continents.Add(
                    new Continent { Name = "Australia" }
                );




                context.SaveChanges();
            }
        }
    }
}

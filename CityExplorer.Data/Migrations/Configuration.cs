namespace CityExplorer.Data.Migrations
{
    using CityExplorer.Models;
    using System;
    using System.Collections.Generic;
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
                this.SeedContinents(context);
            }

            if (!context.Countries.Any())
            {
                this.SeedCountries(context);
            }

            if (!context.Cities.Any())
            {
                this.SeedCities(context);
            }

            if (!context.Places.Any())
            {
                this.SeedPlaces(context);
            }
        }

        private void SeedContinents(CityExplorerDbContext context)
        {
            context.Continents.Add(
               new Continent
               {
                   Name = "Europe",
                   Image = @"https://i.imgur.com/7t1YlwA.png"
               }
             );
            context.Continents.Add(
              new Continent
              {
                  Name = "Asia",
                  Image = @"https://i.imgur.com/yaU0XSt.png"
              }
              );
            context.Continents.Add(
                new Continent
                {
                    Name = "Africa",
                    Image = @"https://i.imgur.com/cZztAc2.png"
                }
            );
            context.Continents.Add(
                new Continent
                {
                    Name = "North America",
                    Image = @"https://i.imgur.com/8e9e1xr.png"
                }
            );
            context.Continents.Add(
                new Continent
                {
                    Name = "South America",
                    Image = @"https://i.imgur.com/wmQnC3q.png"
                }
            );
            context.Continents.Add(
                new Continent
                {
                    Name = "Australia",
                    Image = @"https://i.imgur.com/tmywZ0v.png"
                }
            );

            context.Continents.Add(
                new Continent
                {
                    Name = "Antarctica",
                    Image = @"https://i.imgur.com/uf0FpHG.png"
                }
            );

            context.SaveChanges();
        }

        private void SeedCountries(CityExplorerDbContext context)
        {
            var europe = context.Continents.FirstOrDefault(c => c.Name == "Europe");

            if (europe != null)
            {
                var bulgaria = new Country
                {
                    Name = "Bulgaria",
                    Image = "https://i.imgur.com/pTMpT1k.png"
                };

                var italy = new Country
                {
                    Name = "Italy",
                    Image = "https://i.imgur.com/arnrry7.png"
                };
                
                europe.Countries.Add(bulgaria);
                europe.Countries.Add(italy);
            }

            var asia = context.Continents.FirstOrDefault(c => c.Name == "Asia");

            if (asia != null)
            {
                var china = new Country
                {
                    Name = "China",
                    Image = "https://i.imgur.com/ti911Ck.png"
                };

                asia.Countries.Add(china);
            }


            var africa = context.Continents.FirstOrDefault(c => c.Name == "Africa");

            if (africa != null)
            {
                var sudan = new Country
                {
                    Name = "Sudan",
                    Image = "https://i.imgur.com/ti911Ck.png"
                };

           
                var congo = new Country
                {
                    Name = "Congo",
                    Image = "https://i.imgur.com/rphhNKv.png"
                };

                africa.Countries.Add(sudan); 
                africa.Countries.Add(congo);            
            }

            var southAmerica = context.Continents.FirstOrDefault(c => c.Name == "South America");

            if (southAmerica != null)
            {
                var colombia = new Country
                {
                    Name = "Colombia",
                    Image = "https://i.imgur.com/jTT9XGT.png"
                };


                var argentina = new Country
                {
                    Name = "Argentina",
                    Image = "https://i.imgur.com/XkplaGd.png"
                };

                southAmerica.Countries.Add(colombia);
                southAmerica.Countries.Add(argentina);
            }

            var northAmerica = context.Continents.FirstOrDefault(c => c.Name == "North America");


            if (northAmerica != null)
            {
                var mexico = new Country
                {
                    Name = "Mexico",
                    Image = "https://i.imgur.com/1hytU9R.png"
                };

                northAmerica.Countries.Add(mexico);
            }

            context.SaveChanges();
        }


        private void SeedCities(CityExplorerDbContext context)
        {
            var bulgaria = context.Countries.FirstOrDefault(c => c.Name == "Bulgaria");

            if (bulgaria != null)
            {
                var sofia = new City
                {
                    Name = "Sofia",
                    Area = 1344,
                    Population = 1424527,
                    Website = "https://www.sofia.bg",
                    SettledYear = "5th century B.C",
                    Description = "Sofia  is the capital and largest city of Bulgaria. Sofia is located at the foot of Mount Vitosha in the western part of the country. It occupies a strategic position at the centre of the Balkan Peninsula. Sofia's history spans 2,400 years. Its ancient name Serdica derives from the local Celtic tribe of the Serdi who established the town in the 5th century BC. It remained a relatively small settlement until 1879, when it was declared the capital of Bulgaria."
                };

                var plovdiv = new City
                {
                    Name = "Plovdiv",
                    Area = 101,
                    Population = 403153,
                    Website = "https://www.plovdiv.bg",
                    SettledYear = "4000 BC",
                    Description = "Plovdiv is the second-largest city in Bulgaria after the capital Sofia with a population of 341,041 inhabitants as of June 2013. It is the administrative center of Plovdiv Province and the municipalities of the City of Plovdiv, Maritsa municipality and Rodopi municipality, whose municipal body had a population of 403,153 inhabitants as of February 2011. It is an important economic, transport, cultural and educational center, as well as the second-largest city in the historical international region of Thrace after Istanbul. It is the tenth-largest city in the Balkans after Istanbul, Athens, Bucharest, Belgrade, Sofia, Thessaloniki, Zagreb, Skopje and Tirana."
                };

                bulgaria.Cities.Add(sofia);
                bulgaria.Cities.Add(plovdiv);
            }

            context.SaveChanges();
        }

        private void SeedPlaces(CityExplorerDbContext context)
        {
            var sofia = context.Cities.FirstOrDefault(c => c.Name == "Sofia");

            if (sofia != null)
            {
                var ivanVazovNationalTheatre = new Place
                {
                    Name = "Ivan Vazov National Theatre",
                    CityId = sofia.Id,
                    Photos = new HashSet<Photo>
                    {
                        new Photo
                        {
                            Url = "https://i.imgur.com/4W85rEJ.jpg"
                        },
                        new Photo
                        {
                            Url = "https://i.imgur.com/lwf18rw.jpg"
                        },
                        new Photo
                        {
                            Url = "https://i.imgur.com/rt166GM.jpg"
                        }
                    }
                };

                var nationalHistoricalMuseum = new Place
                {
                    Name = "National Historical Museum",
                    CityId = sofia.Id,
                    Photos = new HashSet<Photo>
                    {
                        new Photo
                        {
                            Url = "https://i.imgur.com/hbMD8G6.jpg"
                        },
                        new Photo
                        {
                            Url = "https://i.imgur.com/oWFjkCq.jpg"
                        },
                        new Photo
                        {
                            Url = "https://i.imgur.com/3sGq1EF.jpg"
                        }
                    }
                };

                context.Places.Add(ivanVazovNationalTheatre);
                context.Places.Add(nationalHistoricalMuseum);
            }
        
            var plovdiv = context.Cities.FirstOrDefault(c => c.Name == "Plovdiv");

            if (plovdiv != null)
            {
                var plovdivRomanTheatre = new Place
                {
                    Name = "Plovdiv Roman Theatre",
                    CityId = plovdiv.Id,
                    Photos = new HashSet<Photo>
                    {
                        new Photo
                        {
                            Url = "https://i.imgur.com/NWDorac.jpg"
                        },
                        new Photo
                        {
                            Url = "https://i.imgur.com/RebOjDW.jpg"
                        }
                    }
                };


                context.Places.Add(plovdivRomanTheatre);
            }

            context.SaveChanges();
        }

    }
}

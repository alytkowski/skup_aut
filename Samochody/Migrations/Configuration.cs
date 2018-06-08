namespace Samochody.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Samochody.Models.CarDBCtxt>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Samochody.Models.CarDBCtxt";
        }

        protected override void Seed(Samochody.Models.CarDBCtxt context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}

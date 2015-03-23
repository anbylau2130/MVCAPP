namespace Repository.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Repository.Domain.TestDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Repository.Domain.TestDbContext context)
        {
            DBConfiguration.Seed(context);
        }
    }
}

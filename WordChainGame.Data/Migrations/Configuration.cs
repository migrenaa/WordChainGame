namespace WordChainGame.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using WordChainGame.Data.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<WordChainGameContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WordChainGameContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}

namespace VetSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<VetSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
			this.AutomaticMigrationDataLossAllowed = false;
			this.ContextKey = "VetSystem.Data.VetSystemDbContext";
        }

        protected override void Seed(VetSystemDbContext context)
        {
        }
    }
}

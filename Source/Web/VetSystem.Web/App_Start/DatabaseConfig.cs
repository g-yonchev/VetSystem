namespace VetSystem.Web
{
    using System.Data.Entity;

    using VetSystem.Data;
    using VetSystem.Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<VetSystemDbContext, Configuration>());
            VetSystemDbContext.Create().Database.Initialize(true);
        }
    }
}
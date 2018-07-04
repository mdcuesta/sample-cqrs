namespace Sampler.CQRS.Migrations
{
    public interface IDbMigrator
    {
        bool Migrate();
    }
}


namespace BE.Persistence.DataSeeds
{
    public class BuildingDataSeedContributor : IDataSeedContributor
    {
        private readonly ApplicationDbContext context;

        public BuildingDataSeedContributor(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Task SeedAsync()
        {
            throw new NotImplementedException();
        }
    }
}

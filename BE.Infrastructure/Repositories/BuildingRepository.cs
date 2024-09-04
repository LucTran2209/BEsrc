using BE.Domain.Entities.Building;
using BE.Infrastructure.Abstractions;
using BE.Persistence;

namespace BE.Infrastructure.Repositories
{
    public class BuildingRepository : BaseRepository, IBuildingRepository
    {
        public BuildingRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void Delete(Building entity)
        {
            context.Buildings.Remove(entity);
        }

        public async Task<Building> FindByIdAsync(int id)
        {
            var build = context.Buildings.SingleOrDefault(b => b.Id == id);
            return build;
        }

        public IQueryable<Building> GetAll()
        {
            var query = context.Buildings
                .AsQueryable();
            return query;
        }

        public void Insert(Building entity)
        {
            context.Buildings.AddAsync(entity);
        }



        public void Update(Building entity)
        {
            context.Buildings.Update(entity);
        }
    }
}

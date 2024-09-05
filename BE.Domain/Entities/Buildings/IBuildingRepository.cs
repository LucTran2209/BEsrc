using BE.Domain.Abstractions.IRepositories;

namespace BE.Domain.Entities.Buildings
{
    public interface IBuildingRepository : IBaseRepository<Building, int>
    {
        IQueryable<Building> GetAll();

    }
}

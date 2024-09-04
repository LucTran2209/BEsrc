using BE.Domain.Abstractions.IRepositories;

namespace BE.Domain.Entities.Building
{
    public interface IBuildingRepository : IBaseRepository<Building, int>
    {
        IQueryable<Building> GetAll();

    }
}

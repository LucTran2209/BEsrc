using BE.Application.Common.Results;
using BE.Application.Services.Building.BuildingServiceInputDto;

namespace BE.Application.Abstractions.ServiceInterfaces
{
    public interface IBuildingSerivce
    {
        Task<ResultService> GetBuilding(GetListBuildingInputDto inputDto);

        Task<ResultService> CreateBuilding(CreateBuildingInputDto input);
        Task<ResultService> UpdateBuilding(UpdateBuildingInputDto inputDto);
        Task<ResultService> DeleteBuilding(DeleteBuildingInputDto inputDto);
    }
}

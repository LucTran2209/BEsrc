using BE.Application.Abstractions;
using BE.Application.Abstractions.ServiceInterfaces;
using BE.Application.Common.Results;
using BE.Application.Extensions;
using BE.Application.Services.Building.BuildingServiceInputDto;
using BE.Domain.Abstractions.UnitOfWork;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BE.Application.Services.Building
{
    public class BuildingService : BaseService, IBuildingSerivce
    {
        private readonly IValidator<CreateBuildingInputDto> createBuildingValidator;
        private readonly IValidator<UpdateBuildingInputDto> updateBuildingValidator;

        public BuildingService(IUnitOfWork unitOfWork,
                                IValidator<CreateBuildingInputDto> createBuildingValidator,
                                IValidator<UpdateBuildingInputDto> updateBuildingValidator
            ) : base(unitOfWork)
        {
            this.createBuildingValidator = createBuildingValidator;
            this.updateBuildingValidator = updateBuildingValidator;
        }

        public async Task<ResultService> CreateBuilding(CreateBuildingInputDto inputDto)
        {

            await createBuildingValidator.ValidateAndThrowAsync(inputDto);

            var build = inputDto.ToEntity();

            unitOfWork.BuildingRepository.Insert(build);
            await unitOfWork.SaveChangesAsync();

            return new ResultService
            {
                StatusCode = HttpStatusCode.Created.ToString(),
                Message = "Success"
            };
        }

        public async Task<ResultService> DeleteBuilding(DeleteBuildingInputDto inputDto)
        {
            var build = await unitOfWork.BuildingRepository.FindByIdAsync(inputDto.Id);
            if (build != null)
            {
                unitOfWork.BuildingRepository.Delete(build);
                await unitOfWork.SaveChangesAsync();
            }


            return new ResultService
            {
                StatusCode = HttpStatusCode.Created.ToString(),
                Message = "Success"
            };
        }

        public async Task<ResultService> GetBuilding(GetListBuildingInputDto inputDto)
        {
            var buil = unitOfWork.BuildingRepository.GetAll();
            var query = buil.Filter(inputDto.Search, u => u.BuildingName.Contains(inputDto.Search));

            var res = await query.OrderBy(inputDto.OrderBy, inputDto.OrderByDesc)
                                                .ThenBy(inputDto.ThenBy, inputDto.ThenByDesc)
                                                .ToPageList(inputDto)
                                                .ToPageResult(await query.CountAsync(), inputDto, b => BuildingExtention.ToDto(b));

            return new ResultService
            {
                StatusCode = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Datas = res
            };
        }


        public async Task<ResultService> UpdateBuilding(UpdateBuildingInputDto inputDto)
        {

            await updateBuildingValidator.ValidateAndThrowAsync(inputDto);

            var build = await unitOfWork.BuildingRepository.FindByIdAsync(inputDto.Id);

            build.UpdateBuildingToEntity(inputDto);

            if (build != null)
            {
                unitOfWork.BuildingRepository.Update(build);
                await unitOfWork.SaveChangesAsync();
            }

            return new ResultService
            {
                StatusCode = HttpStatusCode.Created.ToString(),
                Message = "Success"
            };
        }

    }
}

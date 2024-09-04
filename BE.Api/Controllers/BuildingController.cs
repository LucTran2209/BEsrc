using BE.Application.Abstractions.ServiceInterfaces;
using BE.Application.Services.Building.BuildingServiceInputDto;
using Microsoft.AspNetCore.Mvc;

namespace BE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly ILogger<BuildingController> _logger;
        private readonly IBuildingSerivce buildingService;

        public BuildingController(ILogger<BuildingController> logger, IBuildingSerivce buildingService)
        {
            _logger = logger;
            this.buildingService = buildingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync([FromQuery] GetListBuildingInputDto inputDto)
        {

            var output = await buildingService.GetBuilding(inputDto);
            return Ok(output);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] CreateBuildingInputDto inputDto)
        {
            var output = await buildingService.CreateBuilding(inputDto);
            return Created(output.StatusCode, output);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateBuildingInputDto inputDto)
        {
            var output = await buildingService.UpdateBuilding(inputDto);
            return Created(output.StatusCode, output);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteBuildingInputDto inputDto)
        {
            var output = await buildingService.DeleteBuilding(inputDto);
            return Created(output.StatusCode, output);
        }
    }
}

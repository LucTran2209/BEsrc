using BE.Application.Services.Building.BuildingServiceInputDto;
using BE.Application.Services.Building.BuildingServiceOutputDto;
using BE.Domain.Entities.Buildings;

public static class BuildingExtention
{
    public static Building ToEntity(this CreateBuildingInputDto command)
    {
        var build = new Building();
        build.BuildingName = command.BuildingName;
        build.BuildingType = command.BuildingType;
        build.Address = command.Address;
        build.NumberOfFloor = command.NumberOfFloor;
        build.ContactNumber = command.ContactNumber;
        build.YearConstucted = command.YearConstucted;
        build.ManagerName = command.ManagerName;
        build.Notes = command.Notes;
        build.IsValiable = command.IsValiable;
        build.Image = command.Image;
        build.Capacity = command.Capacity;
        build.EmergencyContact = command.EmergencyContact;
        return build;
    }
    public static void UpdateBuildingToEntity(this Building building, UpdateBuildingInputDto command)
    {

        building.BuildingName = command.BuildingName;
        building.BuildingType = command.BuildingType;
        building.Address = command.Address;
        building.NumberOfFloor = command.NumberOfFloor;
        building.ContactNumber = command.ContactNumber;
        building.YearConstucted = command.YearConstucted;
        building.ManagerName = command.ManagerName;
        building.Notes = command.Notes;
        building.IsValiable = command.IsValiable;
        building.Image = command.Image;
        building.Capacity = command.Capacity;
        building.EmergencyContact = command.EmergencyContact;

    }

    public static GetListBuildingOutputDto ToDto(this Building building)
    {
        return new GetListBuildingOutputDto
        {
            Id = building.Id,
            Address = building.Address,
            BuildingName = building.BuildingName,
            BuildingType = building.BuildingType,
            Capacity = building.Capacity,
            ContactNumber = building.ContactNumber,
            EmergencyContact = building.EmergencyContact,
            Image = building.Image,
            IsValiable = building.IsValiable,
            ManagerName = building.ManagerName,
            Notes = building.Notes,
            NumberOfFloor = building.NumberOfFloor,
            YearConstucted = building.YearConstucted,

        };
    }
}
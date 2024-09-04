namespace BE.Application.Services.Building.BuildingServiceInputDto
{
    public class UpdateBuildingInputDto
    {
        public int Id { get; set; }
        public string BuildingName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int? NumberOfFloor { get; set; } = null!;
        public int? YearConstucted { get; set; } = null!;
        public string BuildingType { get; set; } = null!;
        public string ManagerName { get; set; } = null!;
        public string? ContactNumber { get; set; } = null!;
        public string EmergencyContact { get; set; } = null!;
        public int? Capacity { get; set; } = null!;
        public string Image { get; set; } = null!;
        public int? IsValiable { get; set; } = null!;
        public string Notes { get; set; } = null!;
    }
}

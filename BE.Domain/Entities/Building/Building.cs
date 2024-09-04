using BE.Domain.Abstractions;
using BE.Domain.Abstractions.IEntities;

namespace BE.Domain.Entities.Building
{
    public class Building : EntityAuditBase, IEntityBase<int>
    {
        public int Id { get; set; }
        public string BuildingName { get; set; }
        public string Address { get; set; }
        public int? NumberOfFloor { get; set; }
        public int? YearConstucted { get; set; }
        public string BuildingType { get; set; }
        public string ManagerName { get; set; }
        public string? ContactNumber { get; set; }
        public string EmergencyContact { get; set; }
        public int? Capacity { get; set; }
        public string Image { get; set; }
        public int? IsValiable { get; set; }
        public string Notes { get; set; }

    }
}

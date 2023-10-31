using TailorWebApp.Domain.Entities.Accounts;
using TailorWebApp.Domain.Entities.Common;
using TailorWebApp.Domain.Entities.Products;

namespace TailorWebApp.Domain.Entities.Orders
{
    public record Order : BaseEntity
    {
        public string? ManufacturingDetails { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public float? TotalCost { get; set; }
        public int Status { get; set; }
        public string AsigneeId { get; set; }
        public AppUserAccount? EmployeeAccount { get; set; }
        public Guid? ProductId { get; set; }
        public Product? Product { get; set; }
        public Guid ServiceId { get; set; }
        public OfferedService? Service { get; set; }
        public ICollection<Measurement> Measurements { get; set; } = new List<Measurement>();
    }
}
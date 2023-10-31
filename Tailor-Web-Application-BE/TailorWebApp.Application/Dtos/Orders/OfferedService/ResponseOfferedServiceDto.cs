using TailorWebApp.Application.Dtos.Orders.ServiceCategory;

namespace TailorWebApp.Application.Dtos.Orders.OfferedService
{
    public class ResponseOfferedServiceDto : BaseOfferedServiceDto
    {
        public Guid Id { get; set; }
        public ResponseServiceCategoryDto ServiceCategory { get; set; }
    }
}
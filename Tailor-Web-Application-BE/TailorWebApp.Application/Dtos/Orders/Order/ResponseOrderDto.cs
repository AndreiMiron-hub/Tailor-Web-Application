using TailorWebApp.Application.Dtos.Identity;
using TailorWebApp.Application.Dtos.Orders.OfferedService;
using TailorWebApp.Application.Dtos.Products.Product;

namespace TailorWebApp.Application.Dtos.Orders.Order
{
    public class ResponseOrderDto : BaseOrderDto
    {
        public Guid Id { get; set; }
        public ResponseUserDto EmployeeAccount { get; set; }
        public ResponseProductDto? Product { get; set; }
        public ResponseOfferedServiceDto? Service { get; set; }
    }
}
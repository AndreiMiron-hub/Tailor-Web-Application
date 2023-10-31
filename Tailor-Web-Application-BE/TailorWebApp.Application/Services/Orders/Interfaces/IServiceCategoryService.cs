using TailorWebApp.Application.Dtos.Orders.ServiceCategory;

namespace TailorWebApp.Application.Services.Orders.Interfaces
{
    public interface IServiceCategoryService
    {
        Task<ResponseServiceCategoryDto> Create(ServiceCategoryDto serviceCategoryDto);

        Task<ICollection<ResponseServiceCategoryDto>> GetAll();

        Task<ResponseServiceCategoryDto> GetById(int id);

        Task<ICollection<ResponseServiceCategoryDto>> GetById(ICollection<int> ids);

        Task<ResponseServiceCategoryDto> Update(int id, ServiceCategoryDto serviceCategoryDto);

        Task Delete(int id);
    }
}
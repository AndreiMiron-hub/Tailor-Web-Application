using AutoMapper;
using TailorWebApp.Application.Dtos.Authentication;
using TailorWebApp.Application.Dtos.Identity;
using TailorWebApp.Application.Dtos.Locations.Country;
using TailorWebApp.Application.Dtos.Locations.Location;
using TailorWebApp.Application.Dtos.Locations.Region;
using TailorWebApp.Application.Dtos.NewsArticles;
using TailorWebApp.Application.Dtos.Orders.Appointment;
using TailorWebApp.Application.Dtos.Orders.Measurement;
using TailorWebApp.Application.Dtos.Orders.OfferedService;
using TailorWebApp.Application.Dtos.Orders.Order;
using TailorWebApp.Application.Dtos.Orders.ServiceCategory;
using TailorWebApp.Application.Dtos.Products.Product;
using TailorWebApp.Application.Dtos.Products.ProductCategory;
using TailorWebApp.Application.Dtos.Products.ProductSize;
using TailorWebApp.Application.Dtos.Products.ProductStatus;
using TailorWebApp.Application.Dtos.Products.ProductTags;
using TailorWebApp.Application.Dtos.Products.ProductTypes;
using TailorWebApp.Application.Dtos.Staff.StaffSchedule;
using TailorWebApp.Domain.Entities.Accounts;
using TailorWebApp.Domain.Entities.Locations;
using TailorWebApp.Domain.Entities.NewsArticles;
using TailorWebApp.Domain.Entities.Orders;
using TailorWebApp.Domain.Entities.Products;
using TailorWebApp.Domain.Entities.StaffRelated;

namespace TailorWebApp.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ConfigureProductCategoryMapping();
            ConfigureProductMapping();
            ConfigureProductSizeMapping();
            ConfigureProductStatusMapping();
            ConfigureProductTagsMapping();
            ConfigureProductTypeMapping();
            ConfigureLocationMapping();
            ConfigureRegionMapping();
            ConfigureCountryMApping();
            ConfigureAppUserAccountMapping();
            ConfigureStaffScheduleMapping();
            ConfigureAppointmentMapping();
            ConfigureMeasurementsMapping();
            ConfigureOfferedServicesMapping();
            ConfigureOrderMapping();
            ConfigureServiceCategoryMapping();
            ConfigureNewsMapping();
            ConfigureNewsStatusMapping();
        }

        private void ConfigureProductCategoryMapping()
        {
            CreateMap<ProductCategoryDto, ProductCategory>();

            CreateMap<ProductCategory, ResponseProductCategoryDto>();

            CreateMap<ProductCategory, ResponseProductCategoryRelationsDto>();
        }

        private void ConfigureProductMapping()
        {
            CreateMap<ProductDto, Product>();

            CreateMap<Product, ResponseProductDto>()
                .ForMember(dto => dto.ProductTags, opt => opt.MapFrom(x => x.Tags.Select(y => y.Tag).ToList()));
        }

        private void ConfigureProductSizeMapping()
        {
            CreateMap<ProductSizeDto, ProductSize>();

            CreateMap<ProductSize, ResponseProductSizeDto>();
        }

        private void ConfigureProductStatusMapping()
        {
            CreateMap<ProductStatusDto, ProductStatus>();

            CreateMap<ProductStatus, ResponseProductStatusDto>();
        }

        private void ConfigureProductTagsMapping()
        {
            CreateMap<ProductTagDto, ProductTag>();

            CreateMap<ProductTag, ResponseProductTagDto>();
        }

        private void ConfigureProductTypeMapping()
        {
            CreateMap<ProductTypeDto, ProductType>();

            CreateMap<ProductType, ResponseProductTypeDto>();

            CreateMap<ProductType, ResponseProductTypeRelationsDto>();
        }

        private void ConfigureLocationMapping()
        {
            CreateMap<LocationDto, Location>();

            CreateMap<Location, ResponseLocationDto>();
        }

        private void ConfigureRegionMapping()
        {
            CreateMap<RegionDto, Region>();

            CreateMap<Region, ResponseRegionDto>();
        }

        private void ConfigureCountryMApping()
        {
            CreateMap<CountryDto, Country>();

            CreateMap<Country, CountryDto>();

            CreateMap<Country, ResponseCountryDto>();
        }

        private void ConfigureAppUserAccountMapping()
        {
            CreateMap<RegisterAccountDto, AppUserAccount>()
                .ForMember(dest => dest.UserName,
                    opt => opt.MapFrom(src => src.Email));

            CreateMap<AppUserTokens, AuthenticationTokensDto>()
                .ForMember(dest => dest.AccessToken,
                    opt => opt.MapFrom(src => src.Value));

            CreateMap<AppUserAccount, ResponseUserDto>();
        }

        private void ConfigureStaffScheduleMapping()
        {
            CreateMap<StaffScheduleDto, StaffSchedule>();

            CreateMap<StaffSchedule, StaffScheduleDto>();

            CreateMap<StaffSchedule, ResponseStaffScheduleDto>();
        }

        private void ConfigureAppointmentMapping()
        {
            CreateMap<AppointmentDto, Appointment>();

            CreateMap<Appointment, AppointmentDto>();

            CreateMap<Appointment, ResponseAppointmentDto>();
        }

        private void ConfigureMeasurementsMapping()
        {
            CreateMap<MeasurementDto, Measurement>();

            CreateMap<Measurement, MeasurementDto>();

            CreateMap<Measurement, ResponseMeasurementDto>();
        }

        private void ConfigureOfferedServicesMapping()
        {
            CreateMap<OfferedServiceDto, OfferedService>();

            CreateMap<OfferedService, OfferedServiceDto>();

            CreateMap<OfferedService, ResponseOfferedServiceDto>();
        }

        private void ConfigureOrderMapping()
        {
            CreateMap<OrderDto, Order>();

            CreateMap<Order, OrderDto>();

            CreateMap<Order, ResponseOrderDto>();
        }

        private void ConfigureServiceCategoryMapping()
        {
            CreateMap<ServiceCategoryDto, ServiceCategory>();

            CreateMap<ServiceCategory, ServiceCategoryDto>();

            CreateMap<ServiceCategory, ResponseServiceCategoryDto>();
        }

        private void ConfigureNewsMapping()
        {
            CreateMap<CreateNewsRequestDto, News>()
                .ForMember(news => news.Hashtags,
                opt => opt.MapFrom(news => string.Join('#', news.Hashtags)));

            CreateMap<NewsDto, News>();

            CreateMap<News, ResponseNewsDto>()
                .ForMember(dest => dest.Hashtags,
                opt => opt.MapFrom(src => src.Hashtags.Split('#', StringSplitOptions.None)))
                .ForMember(dest => dest.NewsStatusId,
                opt => opt.MapFrom(src => src.NewsStatus.Id));
        }

        private void ConfigureNewsStatusMapping()
        {
            CreateMap<NewsStatusDto, NewsStatus>();

            CreateMap<NewsStatus, ResponseNewsStatusDto>();
        }
    }
}
using AutoMapper;
using Demo.RealestateApp.App1.Service.Base;
using Demo.RealestateApp.App1.ViewModels;
using Demo.RealestateApp1.App.ViewModels;

namespace DemoRealestateApp.App1.Profiles
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<PropertyDetailVeiwModel, CreatePropertyCommand>()
                    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.ProductAddress))
                    .ForMember(dest=>dest.BuildingId , opt=>opt.MapFrom(src=>src.BuildingId))
                    .ForMember(dest => dest.ImagesPath, opt => opt.MapFrom(src => src.ImagesPath));
            CreateMap<PropertyDetailVeiwModel, UpdatePropertyCommand>()
                 .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.ProductAddress))
                 .ForMember(dest => dest.BuildingId, opt => opt.MapFrom(src => src.BuildingId))
                 .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.ImagesPath));
            CreateMap<BuildingViewModel, CreateBuildingCommand>()
                 .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.ProductAddress))
                 .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId))
                 .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images));

            CreateMap<PropertyDto, PropertyDetailVeiwModel>()
                .ForMember(dest => dest.ProductAddress , opt => opt.MapFrom(src => src.ProductAddress));
            CreateMap<BuildingDto, BuildingViewModel>()
           .ForMember(dest => dest.ProductAddress, opt => opt.MapFrom(src => src.ProductAddress));

            CreateMap<AddressViewModel, CreateAddreesDto>().ReverseMap();
            CreateMap<AddressViewModel, AddressDto>().ReverseMap();
            CreateMap<AddressViewModel, UpdateAddressDto>().ReverseMap();
            CreateMap<ImageUploadRequestDto, ImageViewModel>().ReverseMap();
          
        }

    }
}
/*
 CreateMap<Property, PropertiesBuildingDto>().ReverseMap();
            CreateMap<Property, PropertyDto>().ReverseMap()
                    .ForMember(dest => dest.ProductAddress, opt => opt.MapFrom(src => src.ProductAddress))
                    .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.ImagesPath));

            CreateMap<Property, CreatePropertyCommand>().ReverseMap()
                    .ForMember(dest => dest.ProductAddress, opt => opt.MapFrom(src => src.Address))
                    .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.ImagesPath));

            CreateMap<Property, UpdatePropertyCommand>().ReverseMap()
                    .ForMember(dest => dest.ProductAddress, opt => opt.MapFrom(src => src.Address))
                    .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images));

            CreateMap<Property, DeletePropertyCommand>().ReverseMap();



            CreateMap<Project, ProjectDto>().ReverseMap()
                     .ForMember(dest => dest.ProductAddress, opt => opt.MapFrom(src => src.ProductAddress));

            CreateMap<Project, CreateProjectCommand>().ReverseMap()
                     .ForMember(dest => dest.ProductAddress, opt => opt.MapFrom(src => src.Address))
                     .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images));

            CreateMap<Project, UpdateProjectCommand>().ReverseMap()
                     .ForMember(dest => dest.ProductAddress, opt => opt.MapFrom(src => src.Address))
                     .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images));

            CreateMap<Project, DeleteProjectCommand>().ReverseMap();



            CreateMap<Building, BuildingDto>().ReverseMap()
                .ForMember(dest => dest.ProductAddress, opt => opt.MapFrom(src => src.ProductAddress))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images));

            CreateMap<Building, CreateBuildingCommand>().ReverseMap()
                .ForMember(dest => dest.ProductAddress, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images));


            CreateMap<Building, UpdateBuildingCommand>().ReverseMap()
                .ForMember(dest => dest.ProductAddress, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images));

            CreateMap<Building, DeleteBuildingCommand>().ReverseMap();

            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<CreateAddreesDto, Address>();
            CreateMap<Address, UpdateAddressDto>().ReverseMap();
            CreateMap<Image, ImageUploadRequestDto>().ReverseMap()
                .ForMember(dest => dest.FileExtension, opt => opt.MapFrom(src =>Path.GetExtension( src.File.FileName)))
                .ForMember(dest => dest.FileSizeInBytes, opt => opt.MapFrom(src => src.File.Length))
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.File.FileName));

            CreateMap<OrderProduct, GetOrderProductDto>().ReverseMap();
            CreateMap<OrderProduct, CreateOrderProductCommand>().ReverseMap();
 
 */
using AutoMapper;
using Demo.RealestateApp.Application.Features.Addresses;
using Demo.RealestateApp.Application.Features.Buildings.Commands.CreateBuilding;
using Demo.RealestateApp.Application.Features.Buildings.Commands.DeleteBuilding;
using Demo.RealestateApp.Application.Features.Buildings.Commands.UpdateBuilding;
using Demo.RealestateApp.Application.Features.Buildings.Queries;
using Demo.RealestateApp.Application.Features.Images;
using Demo.RealestateApp.Application.Features.OrderProducts.Commands.CreateOrderProduct;
using Demo.RealestateApp.Application.Features.OrderProducts.Queries;
using Demo.RealestateApp.Application.Features.Projects.Commands.CreateProject;
using Demo.RealestateApp.Application.Features.Projects.Commands.DeleteProject;
using Demo.RealestateApp.Application.Features.Projects.Commands.UpdateProject;
using Demo.RealestateApp.Application.Features.Projects.Queries;
using Demo.RealestateApp.Application.Features.Properties.Commands.CreateProperty;
using Demo.RealestateApp.Application.Features.Properties.Commands.DeleteProperty;
using Demo.RealestateApp.Application.Features.Properties.Commands.UpdateProperty;
using Demo.RealestateApp.Application.Features.Properties.Queries;
using Demo.RealestateApp.Domain.Common;
using Demo.RealestateApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

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





        }
    }
}

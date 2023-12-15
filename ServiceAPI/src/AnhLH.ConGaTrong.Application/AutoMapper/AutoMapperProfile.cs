using AnhLH.ConGaTrong.Dtos;
using AutoMapper;

namespace AnhLH.ConGaTrong.AutoMapper
{
    partial class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Customers, CustomersDto>().ReverseMap();
            CreateMap<OrderDto, Orders>()
                .ForMember(dst => dst.ID, opts => opts.Ignore())
                .ForMember(dst => dst.CustomerCode, opts => opts.MapFrom(src => src.CustomerCode))
                .ForMember(dst => dst.CustomerName, opts => opts.MapFrom(src => src.CustomerName))
                .ForMember(dst => dst.PhoneNumber, opts => opts.MapFrom(src => src.PhoneNumber))
                .ForMember(dst => dst.TicketCode, opts => opts.Ignore())
                .ForMember(dst => dst.TicketNumber, opts => opts.MapFrom(src => src.TicketNumber))
                .ForMember(dst => dst.ReleaseDate, opts => opts.Ignore())
                .ForMember(dst => dst.Remark, opts => opts.MapFrom(src => src.Remark))
                .ForMember(dst => dst.Status, opts => opts.Ignore())
                .ForMember(dst => dst.CreatedDate, opts => opts.Ignore())
                .ForMember(dst => dst.UpdatedDate, opts => opts.Ignore());

            CreateMap<Orders, OrderResponseDto>()
                .ForMember(dst => dst.CustomerCode, opts => opts.MapFrom(src => src.CustomerCode))
                .ForMember(dst => dst.CustomerName, opts => opts.MapFrom(src => src.CustomerName))
                .ForMember(dst => dst.PhoneNumber, opts => opts.MapFrom(src => src.PhoneNumber))
                .ForMember(dst => dst.TicketCode, opts => opts.MapFrom(src => src.TicketCode))
                .ForMember(dst => dst.TicketNumber, opts => opts.MapFrom(src => src.TicketNumber))
                .ForMember(dst => dst.ReleaseDate, opts => opts.MapFrom(src => src.ReleaseDate))
                .ForMember(dst => dst.Remark, opts => opts.MapFrom(src => src.Remark));

            CreateMap<TicketResults, TicketResultsDto>()
                .ForMember(dst => dst.TicketCode, opts => opts.MapFrom(src => src.TicketCode))
                .ForMember(dst => dst.TicketNumber, opts => opts.MapFrom(src => src.TicketNumber))
                .ForMember(dst => dst.ReleaseDate, opts => opts.MapFrom(src => src.ReleaseDate));
        }
    }
}

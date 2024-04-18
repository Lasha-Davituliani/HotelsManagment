using HotelManagment.Models.DTOs;
using HotelManagment.Models;
using AutoMapper;

namespace HotelsManagment.web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GuestReservation, GuestReservationDto>()
                .ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id))
                .ForMember(dest => dest.GuestId, options => options.MapFrom(src => src.GuestId))
                .ForMember(dest => dest.FirstName, options => options.MapFrom(src => src.Guest.FirstName))
                .ForMember(dest => dest.LastName, options => options.MapFrom(src => src.Guest.LastName))
                .ForMember(dest => dest.PersonalNumber, options => options.MapFrom(src => src.Guest.PersonalNumber))
                .ForMember(dest => dest.PhoneNumber, options => options.MapFrom(src => src.Guest.PhoneNumber))
                .ForMember(dest => dest.ReservationId, options => options.MapFrom(src => src.ReservationId))
                .ForMember(dest => dest.CheckInDate, options => options.MapFrom(src => src.Reservation.CheckInDate))
                .ForMember(dest => dest.CheckOutDate, options => options.MapFrom(src => src.Reservation.CheckOutDate))
                .ReverseMap();

            CreateMap<GuestReservationForCreatingDto, GuestReservation>().ReverseMap();
            CreateMap<GuestReservationForCreatingDto, Guest>().ReverseMap();
            CreateMap<GuestReservationForCreatingDto, Reservation>().ReverseMap();


            CreateMap<GuestReservation, GuestWithReservationForUpdatingDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.GuestId, opt => opt.MapFrom(src => src.GuestId))
               .ForMember(dest => dest.ReservationId, opt => opt.MapFrom(src => src.ReservationId))
               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Guest.FirstName))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Guest.LastName))
               .ForMember(dest => dest.PersonalNumber, opt => opt.MapFrom(src => src.Guest.PersonalNumber))
               .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Guest.PhoneNumber))
               .ForMember(dest => dest.CheckInDate, opt => opt.MapFrom(src => src.Reservation.CheckInDate))
               .ForMember(dest => dest.CheckOutDate, opt => opt.MapFrom(src => src.Reservation.CheckOutDate));

            CreateMap<GuestWithReservationForUpdatingDto, Guest>()
            .ForMember(dest => dest.Id, options => options.MapFrom(src => src.GuestId));

            CreateMap<GuestWithReservationForUpdatingDto, Reservation>()
            .ForMember(dest => dest.Id, options => options.MapFrom(src => src.ReservationId));

            CreateMap<GuestWithReservationForUpdatingDto, GuestReservation>()
                .ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id));
        }
    }
}

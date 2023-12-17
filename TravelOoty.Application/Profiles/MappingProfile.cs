using AutoMapper;

using TravelOoty.Application.Features;
using TravelOoty.Application.Features.Amenities.Commands.CreateAmenities;
using TravelOoty.Application.Features.Amenities.Commands.UpdateAmenities;
using TravelOoty.Application.Features.Amenities.Query.GetAmenities;
using TravelOoty.Application.Features.Bookings.Command.CreateBooking;
using TravelOoty.Application.Features.Bookings.Command.UpdateBooking;
using TravelOoty.Application.Features.Bookings.Query;
using TravelOoty.Application.Features.City.Command.CreateCity;
using TravelOoty.Application.Features.City.Query.GetCity;
using TravelOoty.Application.Features.HotelCategory.Commands;
using TravelOoty.Application.Features.HotelCategory.Commands.CreateHotelCategory;
using TravelOoty.Application.Features.HotelCategory.Commands.UpdateHotelCategory;
using TravelOoty.Application.Features.HotelCategory.Query.GetHotelCategory;
using TravelOoty.Application.Features.Hotels.Commands.CreateHotel;
using TravelOoty.Application.Features.Hotels.Queries.GetHotelExport;
using TravelOoty.Application.Features.PaymentDetails.Command.Create;
using TravelOoty.Application.Features.PromoCodes.Command.CreatePromoCodes;
using TravelOoty.Application.Features.PromoCodes.Query.GetPromoCodes;
using TravelOoty.Application.Features.Property.Command.CreateProperty;
using TravelOoty.Application.Features.Property.Command.UpdateProperty;
using TravelOoty.Application.Features.Property.Command.UpdatePropertyApproval;
using TravelOoty.Application.Features.Property.Query.GetProperty;
using TravelOoty.Application.Features.PropertyAmenitiesLink.Command;
using TravelOoty.Application.Features.PropertyImageDetails.Command.UpdatePropertyImage;
using TravelOoty.Application.Features.PropertyImageDetails.Query;
using TravelOoty.Application.Features.PropertyType.Commands.CreatePropertyType;
using TravelOoty.Application.Features.PropertyType.Commands.UpdatePropertyType;
using TravelOoty.Application.Features.PropertyType.Query.GetPropertyType;
using TravelOoty.Application.Features.RoomCategory.Command.CreateRoomCategory;
using TravelOoty.Application.Features.RoomCategory.Command.UpdateRoomCategory;
using TravelOoty.Application.Features.RoomCategory.Query.GetRoomCategory;
using TravelOoty.Application.Features.Roomfacilities.Command.CreateRoomFacility;
using TravelOoty.Application.Features.Roomfacilities.Command.UpdateRoomFacility;
using TravelOoty.Application.Features.Roomfacilities.Query.GetRoomFacilty;
using TravelOoty.Application.Features.RoomFacilityLink.Query;
using TravelOoty.Application.Features.Rooms.Command.CreateRoom;
using TravelOoty.Application.Features.Rooms.Command.UpdateRoom;
using TravelOoty.Application.Features.Rooms.Query;
using TravelOoty.Application.Features.RoomsImageDetails.Command;
using TravelOoty.Application.Features.RoomsImageDetails.Query;
using TravelOoty.Domain.Entities;

namespace TravelOoty.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Hotel, HotelsListVM>();
            CreateMap<Hotel, CreateHotelDto>();                        
            CreateMap<Hotel, CreateHotelCommand>().ReverseMap();
            CreateMap<Hotel, HotelExportFileVm>().ReverseMap();
            CreateMap<Hotel, HotelExportDto>().ReverseMap();

            CreateMap<PropertyType, PropertyTypeListVM>();
            CreateMap<PropertyType, CreatePropertyTypeDto>();
            CreateMap<PropertyType, UpdatePropertyTypeDto>();            
            CreateMap<PropertyType, CreatePropertyTypeCommand>().ReverseMap();
            CreateMap<PropertyType, UpdatePropertyTypeCommand>().ReverseMap();

            CreateMap<Amenities, AmenitiesListVM>();
            CreateMap<Amenities, Features.Amenities.Commands.CreateAmenities.AmenitiesDto>();
            CreateMap<Amenities, CreateAmenitiesCommand>().ReverseMap();
            CreateMap<Amenities, UpdateAmenitiesCommand>().ReverseMap();

            CreateMap<HotelCategory, HotelCategoryVM>();
            CreateMap<HotelCategory, HotelCategoriesDto>();
            CreateMap<HotelCategory, CreateHotelCategoryCommand>().ReverseMap();
            CreateMap<HotelCategory, UpdateHotelCategoryCommand>().ReverseMap();

            CreateMap<RoomCategory, RoomCategoryVM>();
            CreateMap<RoomCategory, RoomCategoriesDto>();
            CreateMap<RoomCategory, CreateRoomCategoryCommand>().ReverseMap();
            CreateMap<RoomCategory, UpdateRoomCategoryCommand>().ReverseMap();

            CreateMap<RoomFacility, RoomFacilityListVM>();
            CreateMap<RoomFacility, CreateRoomFacilityDto>();
            CreateMap<RoomFacility, CreateRoomFacilityCommand>().ReverseMap();
            CreateMap<RoomFacility, UpdateRoomFacilityCommand>().ReverseMap();

            CreateMap<Property, PropertyDto>();
            CreateMap<Property, CreatePropertyCommand>().ReverseMap();
            CreateMap<Property, PropertyListVM>();
            CreateMap<Property, UpdatePropertyCommand>().ReverseMap();

            CreateMap<PaymentDetails, CreatePaymentDetailsDto>();
            CreateMap<PaymentDetails, CreatePaymentDetailsCommand>().ReverseMap();      

            CreateMap<UpdatePropertyCommand, PropertyDto>().ReverseMap();

            CreateMap<PropertyListVM, UpdatePropertyCommand>().ReverseMap();
            CreateMap<Property, TravelOoty.Application.Features.Property.Command.UpdateProperty.UpdatePropertyCmd>().ReverseMap();
            CreateMap<PropertyListVM, TravelOoty.Application.Features.Property.Command.UpdateProperty.UpdatePropertyCmd>().ReverseMap();
            CreateMap<Property, TravelOoty.Application.Features.Property.Command.UpdatePropertyApproval.UpdatePropertyCommandResponse>().ReverseMap();

            CreateMap<RoomFacilityLink, RoomFacilityLinkListDto>().ReverseMap();
            CreateMap<RoomFacilityLink, UpdateRoomFacilityLinkDto>().ReverseMap();

            CreateMap<RoomCategoryDto, RoomCategory>().ReverseMap();
            CreateMap<RoomFacilityLinkDto, RoomFacilityLink>().ReverseMap();
            CreateMap<Rooms, RoomListDto>().ReverseMap();

            CreateMap<City, CreateCityDto>();
            CreateMap<City, CreateCityCommand>().ReverseMap();
            CreateMap<City, CityListVM>().ReverseMap();


            CreateMap<Rooms, RoomDto>().ReverseMap();
            CreateMap<Rooms, RoomVM>().ReverseMap();
            CreateMap<Rooms, CreateRoomCommand>().ReverseMap();
            CreateMap<Rooms, UpdateRoomCommand>().ReverseMap();
            CreateMap<Rooms, UpdateRoomListDto>().ReverseMap();

            CreateMap<RoomBookingLink, RoomBookingDto>().ReverseMap();
            CreateMap<Booking, BookingDto>().ReverseMap();
            CreateMap<Booking, CreateBookingCommand>().ReverseMap();
            CreateMap<Booking, BookingVM>()
                .ForMember(dest => dest.BookedDate, opt => opt.MapFrom(src => src.CreatedDate)).ReverseMap();
                
            CreateMap<Booking, UpdateBookingCommand>().ReverseMap();
            CreateMap<Booking, UpdateBookingCommand>().ReverseMap();


            CreateMap<RoomImageDetails, UploadRoomImageCommand>().ReverseMap();
            CreateMap<RoomImageDetails, RoomImageVM>().ReverseMap();
            CreateMap<PropertyImageDetails, PropertyImageVM>().ReverseMap();
            CreateMap<PropertyImageDetails, UploadRoomImageCommand>().ReverseMap();
            CreateMap<PropertyImageDetails, UpdatePropImageCommand>().ReverseMap();
            
            CreateMap<PromoCode, PromoCodeVM>();
            CreateMap<PromoCode, PromoCodesDto>().ReverseMap();
            CreateMap<PromoCode, PromoCodesCommand>().ReverseMap();
            


            CreateMap<RoomFacilityLink, RoomFacilityLinkDto>().ReverseMap();

            CreateMap<PropertyAmenitiesLink, PropertyAmenitiesLinkDto>().ReverseMap();   

            CreateMap<Amenities, TravelOoty.Application.Features.Property.Query.GetProperty.PropertyAmenitiesDto>().ReverseMap();
            CreateMap<PropertyType, TravelOoty.Application.Features.Property.Query.GetProperty.PropPropertyTypeDto>().ReverseMap();
           

        }
    }
}

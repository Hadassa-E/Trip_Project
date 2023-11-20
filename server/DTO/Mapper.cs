using AutoMapper;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Kind, KindDTO>();
            CreateMap<KindDTO, Kind>();
            CreateMap<Order, OrderDTO>().ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User.UserFirstName+" "+ src.User.UserLastName))
            .ForMember(dest => dest.UserPhone, opt => opt.MapFrom(src => src.User.UserPhon))
            .ForMember(dest => dest.TripDestination, opt => opt.MapFrom(src => src.Trip.TripDestination))
            .ForMember(dest => dest.TripDate, opt => opt.MapFrom(src => src.Trip.TripDate));
            CreateMap<OrderDTO, Order>();
            CreateMap<Trip, TripDTO>().ForMember(dest => dest.KindName, opt => opt.MapFrom(src => src.Kind.KindName))
             .ForMember(x => x.Paramedic, map => map.MapFrom(y => !(y.Orders.Any(v => v.User.UserFirstAid == true))));
            CreateMap<TripDTO, Trip>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}

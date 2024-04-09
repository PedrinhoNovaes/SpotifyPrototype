using SpotifyPrototype.Application.Account.Dto;
using SpotifyPrototype.Domain.Account.Aggregates;
using SpotifyPrototype.Domain.Transaction.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Application.Account.Profile
{
    public class UserProfile : AutoMapper.Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>();

            CreateMap<User, UserDto>()
                .AfterMap((source, destination) =>
                {
                    var plan = source.Signatures?.FirstOrDefault(a => a.Active)?.Plan;

                    if (plan != null)
                        destination.PlanId = plan.Id;

                    destination.Password = "xxxxxxxxx";
                });

            CreateMap<CardDto, Card>()
                .ForMember(dest => dest.Limit, opt => opt.MapFrom(src => src.Limit))
                .ReverseMap();
        }
    }

}

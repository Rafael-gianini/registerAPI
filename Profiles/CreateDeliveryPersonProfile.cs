using AutoMapper;
using registerAPI.Commands.Person.CreateDeliveryPerson;
using registerAPI.Entity;

namespace registerAPI.Profiles
{
    public class CreateDeliveryPersonProfile : Profile
    {
        public CreateDeliveryPersonProfile()
        {
            CreateMap<CreateDeliveryPersonCommand, DeliveryPersonRegister>(MemberList.None)
                .ForMember(x => x.Id, o => o.Ignore())
                .ForMember(x => x.DateOfBirth, o => o.Ignore());

                
        }
    }
}

using ApplicationLayer.Services.Dinners.Commands;
using Contracts.Dinners; 
using DomainLayer.DinnerAggregate.Entities;
using Mapster;

namespace PresentationLayer.Common.Mapping
{
    public class ReservationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(ReserveDinnerRequest req, string guestid, string dinnerid), ReserveDinnerCommand>()
                .Map(dest => dest.GuestId, src => src.guestid)
                .Map(dest => dest.DinnerId, src => src.dinnerid)
                .Map(dest => dest, src => src.req);

            config.NewConfig<Reservation, ReserveDinnerResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.guestId, src => src.GuestId.Value)
                .Map(dest => dest.CreatedAt, src => src.CreatedAt)
                .Map(dest => dest.UpdatedAt, src => src.UpdatedAt);

        }
    }
}
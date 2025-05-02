using ApplicationLayer.Services.Dinners.Commands;
using Contracts.Dinners;
using DomainLayer.DinnerAggregate.Entities;
using Mapster;

namespace PresentationLayer.Common.Mapping
{
    public class GuestArrivedMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(GuestArrivedAtRequest req, string reservationId, string dinnerid), GuestArrivedAtCommand>() 
                .Map(dest => dest.DinnerId, src => src.dinnerid)
                .Map(dest => dest.ReservationId, src => src.reservationId)
                .Map(dest => dest, src => src.req);

            config.NewConfig<Reservation, ReserveDinnerResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);

        }
    }
}
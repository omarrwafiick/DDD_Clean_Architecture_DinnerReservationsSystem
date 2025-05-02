using ApplicationLayer.Services.Dinners.Commands;
using Contracts.Dinners;
using DomainLayer.DinnerAggregate; 
using Mapster;

namespace PresentationLayer.Common.Mapping
{
    public class EndDinnerMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(EndDinnerRequest req, string hostid, string dinnerid), EndDinnerCommand>()
                .Map(dest => dest.HostId, src => src.hostid)
                .Map(dest => dest.DinnerId, src => src.dinnerid)
                .Map(dest => dest, src => src.req);

            config.NewConfig<Dinner, EndDinnerResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);

        }
    }
}
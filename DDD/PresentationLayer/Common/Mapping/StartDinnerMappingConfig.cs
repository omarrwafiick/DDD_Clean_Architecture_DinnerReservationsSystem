using ApplicationLayer.Services.Dinners.Commands;
using Contracts.Dinners;
using DomainLayer.DinnerAggregate; 
using Mapster;

namespace PresentationLayer.Common.Mapping
{
    public class StartDinnerMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(StartDinnerRequest req, string hostid, string dinnerid), StartDinnerCommand>()
                .Map(dest => dest.HostId, src => src.hostid)
                .Map(dest => dest.DinnerId, src => src.dinnerid)
                .Map(dest => dest, src => src.req);

            config.NewConfig<Dinner, StartDinnerResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);

        }
    }
}
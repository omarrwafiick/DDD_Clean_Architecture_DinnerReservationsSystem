using ApplicationLayer.Services.Dinners.Commands;
using Contracts.Dinners;
using DomainLayer.DinnerAggregate;
using Mapster;

namespace PresentationLayer.Common.Mapping
{
    public class DinnerMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateDinnerRequest req, string hostId), CreateDinnerCommand>()
                .Map(dest => dest.HostId, src => src.hostId)
                .Map(dest => dest, src => src.req);

            config.NewConfig<Dinner, DinnerResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.HostId, src => src.HostId.Value)
                .Map(dest => dest.CreatedAt, src => src.CreatedAt)
                .Map(dest => dest.UpdatedAt, src => src.UpdatedAt);
             
        }
    }
}
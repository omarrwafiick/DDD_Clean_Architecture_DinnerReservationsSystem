using Contracts.Bills;
using DomainLayer.BillAggregate;
using Mapster;

namespace PresentationLayer.Common.Mapping
{
    public class BillQueryMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Bill, BillQueryResponse>()
             .Map(dest => dest.Id, src => src.Id.Value)
             .Map(dest => dest.DinnerId, src => src.DinnerId.Value)
             .Map(dest => dest.GuestId, src => src.GuestId.Value)
             .Map(dest => dest.HostId, src => src.HostId.Value)
             .Map(dest => dest.CreatedAt, src => src.CreatedAt)
             .Map(dest => dest.UpdatedAt, src => src.UpdatedAt);

        }
    }
}
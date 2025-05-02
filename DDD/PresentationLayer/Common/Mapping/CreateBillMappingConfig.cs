using ApplicationLayer.Services.Bills.Commands;
using Contracts.Bills;
using Contracts.Dinners;
using DomainLayer.BillAggregate;
using Mapster;

namespace PresentationLayer.Common.Mapping
{
    public class CreateBillMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(StartDinnerRequest req, string guestid), CreateBillCommand>()
                .Map(dest => dest.HostId, src => src.guestid) 
                .Map(dest => dest, src => src.req);

            config.NewConfig<Bill, CreateBillResponse>()
                .Map(dest => dest.Id, src => src.Id.Value); 
        }
    }
}
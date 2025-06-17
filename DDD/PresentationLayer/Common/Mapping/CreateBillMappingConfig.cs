using ApplicationLayer.Services.Bills.Commands;
using Contracts.Bills; 
using Mapster;

namespace PresentationLayer.Common.Mapping
{
    public class CreateBillMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateBillRequest req, string guestid), CreateBillCommand>()
                .Map(dest => dest.HostId, src => src.guestid)
                .Map(dest => dest, src => src.req);
        }
    }
}
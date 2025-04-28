using ApplicationLayer.Services.Menus.Commands;
using Contracts.Menus;
using DomainLayer.MenuAggregate;
using DomainLayer.MenuAggregate.Entities;
using Mapster;

namespace ApplicationLayer.Common.Mapping
{
    public class MenuMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateMenuRequest req, string hostId), CreateMenuCommand>()
                .Map(dest => dest.HostId, src => src.hostId)
                .Map(dest => dest, src => src.req);

            config.NewConfig<Menu, MenuResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.HostId, src => src.HostId.Value)
                .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(x=>x.Value))
                .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(x => x.Value))
                .Map(dest => dest.AverageRating, src => src.AverageRating.Value > 0 ? src.AverageRating.Value : 0);

            config.NewConfig<MenuSection, MenuSectionResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);

            config.NewConfig<MenuItem, MenuItemResponse>()
                .Map(dest => dest.Id, src => src.Id.Value); 
               
        }
    }
}
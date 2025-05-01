using ApplicationLayer.Common.Interfaces.Repositories;
using DomainLayer.HostAggregate.ValueObjects;
using DomainLayer.MenuAggregate;
using DomainLayer.MenuAggregate.Entities;
using FluentResults;
using MediatR;

namespace ApplicationLayer.Services.Dinners.Commands
{
    public class CreateDinnerCommandHandler : IRequestHandler<CreateDinnerCommand, Result<Menu>>
    {
        private readonly IMenuRepository _menuRepository;
        public CreateDinnerCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        public async Task<Result<Menu>> Handle(CreateDinnerCommand request, CancellationToken cancellationToken)
        {
            var menu = Menu.Create(
                request.Name,
                request.Description,
                HostId.Create(Guid.Parse( request.HostId)),
                request.Sections.Select(
                        sec => MenuSection.Create(sec.Name, sec.Description, sec.Items.Select(
                                itm => MenuItem.Create(itm.Name, itm.Description)
                            ).ToList()
                        )
                    ).ToList()
                );
            await _menuRepository.AddAsync(menu);
            return menu;
        }
    }
}

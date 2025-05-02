using ApplicationLayer.Common.Interfaces.Repositories;
using DomainLayer.HostAggregate.ValueObjects;
using DomainLayer.MenuAggregate;
using DomainLayer.MenuAggregate.Entities;
using FluentResults;
using MediatR;

namespace ApplicationLayer.Services.Menus.Commands
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, Result<Menu>>
    {
        private readonly ICreateRepository<Menu> _menuRepository;
        public CreateMenuCommandHandler(ICreateRepository<Menu> menuRepository)
        {
            _menuRepository = menuRepository;
        } 
        public async Task<Result<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
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

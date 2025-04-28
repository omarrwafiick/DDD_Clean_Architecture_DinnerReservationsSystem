

using DomainLayer.MenuAggregate;
using FluentResults;
using MediatR;

namespace ApplicationLayer.Services.Menus.Commands
{
    public record CreateMenuCommand
    ( 
        string Name,
        string Description,
        string HostId,
        List<MenuSectionCommand> Sections
    ) : IRequest<Result<Menu>>;
    public record MenuSectionCommand(
        string Name, 
        string Description, 
        List<MenuItemCommand> Items
    );
    public record MenuItemCommand(
        string Name, 
        string Description
    );
}

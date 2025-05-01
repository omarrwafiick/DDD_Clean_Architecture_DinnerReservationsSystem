

using DomainLayer.MenuAggregate;
using FluentResults;
using MediatR;

namespace ApplicationLayer.Services.Dinners.Commands
{
    public record CreateDinnerCommand
    ( 
        string Name,
        string Description,
        string HostId, 
        List<MenuSectionCommand> Sections
    ) : IRequest<Result<Menu>>;
    public record MenuSectionCommand(
        string Name, 
        string Description
        //List<MenuItemCommand> Items
    ); 
}

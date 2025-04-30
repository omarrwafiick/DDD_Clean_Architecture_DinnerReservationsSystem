using DomainLayer.MenuAggregate.Events;
using MediatR;

namespace DomainLayer.DinnerAggregate.Events
{
    public class AddMenuHandler : INotificationHandler<MenuCreated>
    {
        public Task Handle(MenuCreated notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

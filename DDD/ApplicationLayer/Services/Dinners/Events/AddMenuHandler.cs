using DomainLayer.MenuAggregate.Events;
using MediatR;

namespace DomainLayer.DinnerAggregate.Events
{
    public class AddMenuHandler : INotificationHandler<MenuCreated>
    {
        public Task Handle(MenuCreated notification, CancellationToken cancellationToken)
        {
            //handle side effects due to creating new menu
            throw new NotImplementedException();
        }
    }
}

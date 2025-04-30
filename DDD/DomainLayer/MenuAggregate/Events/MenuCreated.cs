
using DomainLayer.Common.BaseClasses;

namespace DomainLayer.MenuAggregate.Events
{
    public record MenuCreated(Menu menu) : IDomainEvent;
}

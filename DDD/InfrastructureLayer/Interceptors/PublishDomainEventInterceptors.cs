
using DomainLayer.Common.BaseClasses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace InfrastructureLayer.Interceptors
{
    public class PublishDomainEventInterceptors : SaveChangesInterceptor
    {
        private readonly IPublisher _mediator;
        public PublishDomainEventInterceptors(IPublisher mediator)
        {
            _mediator = mediator;
        }
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            PublicDomainEvents(eventData.Context).GetAwaiter().GetResult();
            return base.SavingChanges(eventData, result);
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            await PublicDomainEvents(eventData.Context);
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private async Task PublicDomainEvents(DbContext? dbContext)
        {
            if (dbContext is null) return;
            //get entities with events
            var entities = dbContext.ChangeTracker.Entries<IHasDomainEvents>()
                .Where(e => e.Entity.DomainEvents.Any())
                .Select(e => e.Entity)
                .ToList();
            //select all events
            var domainEvents = entities.SelectMany(e => e.DomainEvents).ToList();
            //clear them to avoid recursion
            entities.ForEach(e => e.ClearDomainEvents());
            //publish now events by mediator to publish events to handler
            foreach (var domainEvent in domainEvents) { 
                await _mediator.Publish(domainEvent);
            }
        }
    }
}

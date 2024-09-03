
using MediatR;

namespace E_Commerce.Infrastructure.Interceptors
{
    public class DispatchDomainEventsInterceptor : SaveChangesInterceptor
    {
        private readonly IMediator _mediator;

        public DispatchDomainEventsInterceptor(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            DispatchDomainEvents(eventData.Context).GetAwaiter().GetResult();
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result
            , CancellationToken cancellationToken = default)
        {
            DispatchDomainEvents(eventData.Context).GetAwaiter().GetResult();

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
        public async Task DispatchDomainEvents(DbContext? context)
        {
            if (context == null) return;
            // get entites that inhiert BaseEntity and have DomainEvents
            var entities = context.ChangeTracker
                .Entries<BaseEntity>()
                .Where(e => e.Entity.DomainEvents.Any())
                .Select(e => e.Entity);
            // store domain events of entity on array 
            var domainEvents = entities
                .SelectMany(e => e.DomainEvents)
                .ToList();
            // clear events from entities
            entities.ToList().ForEach(e => e.ClearDomainEvents());
            // publish events on array by mediator
            foreach (var domainEvent in domainEvents)
                await _mediator.Publish(domainEvent);
        }
    }
}

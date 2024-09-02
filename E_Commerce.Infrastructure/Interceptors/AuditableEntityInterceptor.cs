﻿namespace E_Commerce.Infrastructure.Interceptors
{
    public class AuditableEntityInterceptor : SaveChangesInterceptor
    {
        private readonly IUser _user;
        private readonly TimeProvider _dateTime;

        public AuditableEntityInterceptor(
            IUser user,
            TimeProvider dateTime)
        {
            _user = user;
            _dateTime = dateTime;
        }
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);

            return base.SavingChanges(eventData, result);
        }
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
        public void UpdateEntities(DbContext? context)
        {
            if (context == null) return;

            foreach (var entry in context.ChangeTracker.Entries<BaseAuditableEntity>())
            {
                if (entry.State is EntityState.Added or EntityState.Modified)
                {
                    var utcNow = _dateTime.GetUtcNow();
                    if (entry.State == EntityState.Added)
                    {
                        entry.Entity.CreatedBy = _user.Id;
                        entry.Entity.CreatedAt = utcNow;
                    }
                    entry.Entity.LastModifiedBy = _user.Id;
                    entry.Entity.LastModifiedAt = utcNow;
                }
            }
        }

    }
}

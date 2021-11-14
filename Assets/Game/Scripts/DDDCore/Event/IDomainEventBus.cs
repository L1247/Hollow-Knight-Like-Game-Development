#region

using System;
using DDDCore.Model;

#endregion

namespace DDDCore
{
    public interface IDomainEventBus
    {
    #region Public Methods

        void HandleEvent(DomainEvent domainEvent);

        void Post(DomainEvent       domainEvent);
        void PostAll(IAggregateRoot aggregateRoot);

        void Register<T>(Action<T> callBackAction , bool isEarly = false)
        where T : DomainEvent;

    #endregion

        // SignalBus SignalBus { get; }
    }
}
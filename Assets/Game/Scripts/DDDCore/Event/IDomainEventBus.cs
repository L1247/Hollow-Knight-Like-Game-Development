#region

using System;
using DDDCore.Model;
using Zenject;

#endregion

namespace DDDCore
{
    public interface IDomainEventBus
    {
    #region Public Variables

        SignalBus SignalBus { get; }

    #endregion

    #region Public Methods

        void HandleEvent(DomainEvent domainEvent);

        void Post(DomainEvent       domainEvent);
        void PostAll(IAggregateRoot aggregateRoot);

        void Register<T>(Action<T> callBackAction , bool isEarly = false)
        where T : DomainEvent;

    #endregion
    }
}
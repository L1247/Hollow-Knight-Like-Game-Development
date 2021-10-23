#region

using System;
using DDDCore.Model;
using Zenject;

#endregion

namespace DDDCore
{
    public abstract class EventHandler
    {
    #region Protected Variables

        protected enum HandlerType
        {
            Domain , View
        }

        protected HandlerType handlerType = HandlerType.Domain;

        protected readonly IDomainEventBus domainEventBus;

    #endregion

    #region Constructor

        [Inject]
        protected EventHandler(IDomainEventBus domainEventBus)
        {
            this.domainEventBus = domainEventBus;
        }

    #endregion

    #region Protected Methods

        protected void Register<T>(Action<T> callBackAction) where T : DomainEvent
        {
            var isEarly = handlerType == HandlerType.View;
            domainEventBus.Register(callBackAction , isEarly);
        }

    #endregion
    }
}
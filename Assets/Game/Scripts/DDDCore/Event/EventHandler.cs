using System;
using DDDCore.Model;
using Zenject;

namespace DDDCore
{
    public abstract class EventHandler
    {
    #region Private Variables

        private readonly EventStore _eventStore;

        protected HandlerType _handlerType = HandlerType.Domain;

        protected enum HandlerType
        {
            Domain , View
        }

    #endregion

    #region Protected Methods


        protected void Register<T>(Action<T> callBackAction) where T : DomainEvent
        {
            var isEarly = _handlerType == HandlerType.View;
            _eventStore.Register(callBackAction , isEarly);
        }

    #endregion


        [Inject]
        protected EventHandler(EventStore eventStore)
        {
            _eventStore = eventStore;
        }
    }
}
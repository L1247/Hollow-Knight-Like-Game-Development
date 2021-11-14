#region

using System;
using System.Collections.Generic;
using DDDCore.Model;
using MessagePipe;
using Zenject;

#endregion

namespace DDDCore
{
    public class DomainEventBus : IDomainEventBus
    {
    #region Private Variables

        private readonly Dictionary<Type , List<Action<object>>> callBacks
            = new Dictionary<Type , List<Action<object>>>();

        private readonly IPublisher<DomainEvent> publisher;

    #endregion

    #region Constructor

        [Inject]
        public DomainEventBus(ISubscriber<DomainEvent> subscriber , IPublisher<DomainEvent> publisher)
        {
            this.publisher = publisher;
            subscriber.Subscribe(HandleEvent);
        }

    #endregion

    #region Public Methods

        public virtual void HandleEvent(DomainEvent domainEvent)
        {
            var type        = domainEvent.GetType();
            var containsKey = callBacks.ContainsKey(type);
            if (containsKey)
            {
                var actions = callBacks[type];
                actions.ForEach(action => action.Invoke(domainEvent));
            }
        }

        public void Post(DomainEvent domainEvent)
        {
            // SignalBus.TryFire(domainEvent);
            publisher.Publish(domainEvent);
        }

        public void PostAll(IAggregateRoot aggregateRoot)
        {
            foreach (var domainEvent in aggregateRoot.GetDomainEvents())
                Post(domainEvent);
            aggregateRoot.ClearDomainEvents();
        }

        public void Register<T>(Action<T> callBackAction , bool isEarly = false)
        where T : DomainEvent
        {
            var type        = typeof(T);
            var containsKey = callBacks.ContainsKey(type);
            if (containsKey)
            {
                var actions = callBacks[type];
                if (isEarly) actions.Insert(0 , o => callBackAction((T)o));
                else actions.Add(o => callBackAction((T)o));
            }
            else
            {
                var actions = new List<Action<object>>();
                actions.Add(o => callBackAction((T)o));
                callBacks.Add(type , actions);
            }
        }

    #endregion
    }
}
#region

using System;
using System.Collections.Generic;
using System.Linq;
using DDDCore.Model;
using Zenject;

#endregion

namespace DDDCore
{
    public class DomainEventBus : IDomainEventBus
    {
    #region Public Variables

        public SignalBus SignalBus { get; }

    #endregion

    #region Private Variables

        private readonly Dictionary<Type , List<Action<object>>> callBacks
            = new Dictionary<Type , List<Action<object>>>();

    #endregion

    #region Constructor

        [Inject]
        public DomainEventBus(SignalBus signalBus)
        {
            SignalBus = signalBus;
            SignalBus = signalBus;
            SignalBus.Subscribe<DomainEvent>(HandleEvent);
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
            SignalBus.TryFire(domainEvent);
        }

        public void PostAll(IAggregateRoot aggregateRoot)
        {
            var domainEvents = aggregateRoot.GetDomainEvents();
            var cacheEvents  = domainEvents.Select(_ => _).ToList();
            aggregateRoot.ClearDomainEvents();
            foreach (var domainEvent in cacheEvents)
                Post(domainEvent);

            domainEvents.Clear();
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
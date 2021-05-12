using System;
using System.Collections.Generic;
using DDDCore.Model;
using Zenject;

namespace DDDCore
{
    public class EventStore
    {
    #region Protected Variables

        protected readonly SignalBus _signalBus;

    #endregion

    #region Private Variables

        private readonly Dictionary<Type , List<Action<object>>> _callBacks
            = new Dictionary<Type , List<Action<object>>>();

    #endregion

    #region Constructor

        [Inject]
        public EventStore(SignalBus signalBus)
        {
            _signalBus = signalBus;
            _signalBus.Subscribe<DomainEvent>(HandleEvent);
        }

    #endregion

    #region Public Methods

        public void Register<T>(Action<T> callBackAction , bool isEarly = false)
        where T : DomainEvent
        {
            var type        = typeof(T);
            var containsKey = _callBacks.ContainsKey(type);
            if (containsKey)
            {
                var actions = _callBacks[type];
                if (isEarly) actions.Insert(0 , o => callBackAction((T)o));
                else actions.Add(o => callBackAction((T)o));
            }
            else
            {
                var actions = new List<Action<object>>();
                actions.Add(o => callBackAction((T)o));
                _callBacks.Add(type , actions);
            }
        }

    #endregion

    #region Protected Methods

        protected virtual void HandleEvent(DomainEvent domainEvent)
        {
            var type        = domainEvent.GetType();
            var containsKey = _callBacks.ContainsKey(type);
            if (containsKey)
            {
                var actions = _callBacks[type];
                actions.ForEach(action => action.Invoke(domainEvent));
            }
        }

    #endregion
    }
}
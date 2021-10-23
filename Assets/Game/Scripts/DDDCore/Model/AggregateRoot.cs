#region

using System.Collections.Generic;

#endregion

namespace DDDCore.Model
{
    public abstract class AggregateRoot : IAggregateRoot
    {
    #region Protected Variables

        protected readonly string id;

    #endregion

    #region Private Variables

        private readonly List<DomainEvent> domainEvents = new List<DomainEvent>();

    #endregion

    #region Constructor

        protected AggregateRoot(string id)
        {
            this.id = id;
        }

    #endregion

    #region Public Methods

        public void AddDomainEvent(DomainEvent domainEvent)
        {
            domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            domainEvents.Clear();
        }

        public T FindDomainEvent<T>() where T : DomainEvent
        {
            var tEvent = domainEvents.Find(domainEvent => domainEvent is T);
            return tEvent as T;
        }

        public List<DomainEvent> GetDomainEvents()
        {
            return domainEvents;
        }

        public string GetId()
        {
            return id;
        }

    #endregion
    }
}
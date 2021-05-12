using System.Collections.Generic;

namespace DDDCore.Model
{
    public abstract class AggregateRoot : Entity<string>
    {
    #region Private Variables

        private readonly List<DomainEvent> _domainEvents = new List<DomainEvent>();

    #endregion

    #region Public Methods

        public void AddDomainEvent(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        public List<DomainEvent> GetDomainEvents()
        {
            return _domainEvents;
        }

    #endregion

        protected AggregateRoot(string id) : base(id) { }
    }
}
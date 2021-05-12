using System.Linq;
using Zenject;

namespace DDDCore.Model
{
    public class DomainEventBus
    {
    #region Private Variables

        private readonly SignalBus _signalBus;

    #endregion

    #region Constructor

        [Inject]
        public DomainEventBus(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

    #endregion

    #region Public Methods

        public void Post(DomainEvent domainEvent)
        {
            _signalBus.TryFire(domainEvent);
        }

        public void PostAll(AggregateRoot aggregateRoot)
        {
            var domainEvents = aggregateRoot.GetDomainEvents();
            var cacheEvents  = domainEvents.Select(_ => _).ToList();
            aggregateRoot.ClearDomainEvents();
            foreach (var domainEvent in cacheEvents)
                Post(domainEvent);

            domainEvents.Clear();
        }

    #endregion
    }
}
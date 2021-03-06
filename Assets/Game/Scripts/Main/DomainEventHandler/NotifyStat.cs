#region

using DDDCore;
using Entity.Events;
using Main.Controller;
using Main.UseCases.Repository;
using Zenject;

#endregion

namespace Main.DomainEventHandler
{
    public class NotifyStat : EventHandler
    {
    #region Private Variables

        [Inject]
        private StatController statController;

        [Inject]
        private IDataRepository dataRepository;

    #endregion

    #region Constructor

        public NotifyStat(IDomainEventBus domainEventBus) : base(domainEventBus)
        {
            Register<ActorCreated>(OnActorCreated);
        }

    #endregion

    #region Private Methods

        private void OnActorCreated(ActorCreated created)
        {
            var actorId     = created.ActorId;
            var actorDataId = created.ActorDataId;
            var actorData   = dataRepository.GetActorData(actorDataId);
            foreach (var statData in actorData.StatDatas)
            {
                var statName = statData.StatName;
                var amount   = statData.Amount;
                statController.CreateStat(actorId , statName , amount);
            }
        }

    #endregion
    }
}
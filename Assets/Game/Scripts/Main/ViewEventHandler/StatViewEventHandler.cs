#region

using DDDCore;
using Main.Entity.Event;
using Main.Presenters;
using Zenject;

#endregion

namespace Main.EventHandler.View
{
    public class StatViewEventHandler : DDDCore.EventHandler
    {
    #region Private Variables

        [Inject]
        private StatPresenter statPresenter;

    #endregion

    #region Constructor

        public StatViewEventHandler(IDomainEventBus domainEventBus) : base(domainEventBus)
        {
            handlerType = HandlerType.View;
            Register<StatCreated>(OnStatCreated);
            Register<AmountModified>(OnAmountModified);
        }

    #endregion

    #region Private Methods

        private void OnAmountModified(AmountModified amountModified)
        {
            var actorId  = amountModified.ActorId;
            var statName = amountModified.StatName;
            var amount   = amountModified.Amount;
            statPresenter.ModifyAmountText(actorId , statName , amount);
        }

        private void OnStatCreated(StatCreated created)
        {
            var actorId  = created.ActorId;
            var statName = created.StatName;
            var amount   = created.Amount;
            statPresenter.CreateStatText(actorId , statName , amount);
        }

    #endregion
    }
}
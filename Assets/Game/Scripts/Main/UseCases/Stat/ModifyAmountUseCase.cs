#region

using DDDCore;
using DDDCore.Usecase;
using Utilities.Contract;

#endregion

namespace Main.UseCases.Stat
{
    public class ModifyAmountInput
    {
    #region Public Variables

        public int    Amount;
        public string ActorId;
        public string StatName;

    #endregion
    }

    public class ModifyAmountUseCase : UseCase<ModifyAmountInput , IStatRepository>
    {
    #region Constructor

        public ModifyAmountUseCase(IDomainEventBus domainEventBus , IStatRepository repository) : base(
            domainEventBus , repository) { }

    #endregion

    #region Public Methods

        public override void Execute(ModifyAmountInput input)
        {
            var actorId = input.ActorId;
            Contract.RequireString(actorId , "actorId");
            var statName = input.StatName;
            Contract.RequireString(statName , "statName");
            var stat = repository.FindStat(actorId , statName);
            if (stat == null) return;
            var amount           = input.Amount;
            var statAmount       = stat.Amount;
            var calculatedAmount = statAmount + amount;
            stat.SetAmount(calculatedAmount);

            domainEventBus.PostAll(stat);
        }

    #endregion
    }
}
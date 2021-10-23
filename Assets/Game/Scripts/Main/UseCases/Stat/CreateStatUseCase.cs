#region

using DDDCore;
using DDDCore.Usecase;
using Main.Entity;
using Utilities.Contract;

#endregion

namespace Main.UseCases.Stat
{
    public class CreateStatInput
    {
    #region Public Variables

        public int    Amount;
        public string ActorId;

        public string StatId;
        public string StatName;

    #endregion
    }

    public class CreateStatUseCase : UseCase<CreateStatInput , IRepository<Entity.Stat>>
    {
    #region Constructor

        public CreateStatUseCase(IDomainEventBus domainEventBus , IRepository<Entity.Stat> repository) : base(
            domainEventBus , repository) { }

    #endregion

    #region Public Methods

        public override void Execute(CreateStatInput input)
        {
            var statId   = input.StatId;
            var statName = input.StatName;
            Contract.RequireString(statName , "statName");
            var actorId = input.ActorId;
            Contract.RequireString(actorId , "actorId");
            var amount = input.Amount;
            var stat = StatBuilder
                       .NewInstance()
                       .SetStatId(statId)
                       .SetActorId(actorId)
                       .SetStatName(statName)
                       .SetAmount(amount)
                       .Build();
            repository.Save(stat);
            domainEventBus.PostAll(stat);
        }

    #endregion
    }
}
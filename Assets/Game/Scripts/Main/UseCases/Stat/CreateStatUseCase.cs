#region

using DDDCore;
using DDDCore.Usecase;
using Utilities.Contract;

#endregion

namespace Main.UseCases.Stat
{
    public class CreateStatInput
    {
    #region Public Variables

        public string StatId;

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
            var statId = input.StatId;
            Contract.RequireString(statId , "statId");
            var stat = repository.FindById(statId);
            Contract.RequireNotNull(stat , $"statId : {statId} , stat");

            domainEventBus.PostAll(stat);
        }

    #endregion
    }
}
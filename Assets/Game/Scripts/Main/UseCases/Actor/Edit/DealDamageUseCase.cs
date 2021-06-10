using DDDCore.Model;
using DDDCore.Usecase;
using Main.UseCases.Repository;

namespace Main.UseCases.Actor.Edit
{
    public class DealDamageInput : Input
    {
    #region Public Variables

        public string ActorId;

    #endregion
    }

    public class DealDamageUseCase : UseCase<DealDamageInput , ActorRepository>
    {
    #region Constructor

        public DealDamageUseCase(DomainEventBus domainEventBus , ActorRepository repository) : base(
            domainEventBus , repository) { }

    #endregion

    #region Public Methods

        public override void Execute(DealDamageInput input) { }

    #endregion
    }
}
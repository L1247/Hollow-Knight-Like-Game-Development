using DDDCore.Model;
using DDDCore.Usecase;
using Main.UseCases.Repository;

namespace Main.UseCases.Actor.Edit
{
    public class ChangeDirectionInput : Input
    {
    #region Public Variables

        public string ActorId;

    #endregion
    }

    public class ChangeDirectionUseCase : UseCase<ChangeDirectionInput , ActorRepository>
    {
    #region Constructor

        public ChangeDirectionUseCase(DomainEventBus domainEventBus , ActorRepository repository) : base(
            domainEventBus , repository) { }

    #endregion

    #region Public Methods

        public override void Execute(ChangeDirectionInput input) { }

    #endregion
    }
}
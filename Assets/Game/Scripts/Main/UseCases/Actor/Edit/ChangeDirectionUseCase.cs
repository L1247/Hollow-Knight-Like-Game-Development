using DDDCore.Model;
using DDDCore.Usecase;
using Main.UseCases.Repository;

namespace Main.UseCases.Actor.Edit
{
    public class ChangeDirectionInput : DDDCore.Usecase.Input
    {
    #region Public Variables

        public int Direction;

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

        public override void Execute(ChangeDirectionInput input)
        {
            var actor = repository.FindById(input.ActorId);
            actor.ChangeDirection(input.Direction);
            domainEventBus.PostAll(actor);
        }

    #endregion
    }
}
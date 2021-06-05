using DDDCore.Model;
using DDDCore.Usecase;
using Entity.Builder;
using Main.UseCases.Repository;

namespace Main.UseCases.Actor.Create
{
    public class CreateActorInput : Input
    {
    #region Public Variables

        public string ActorDataId;

        // For Unit Test
        public string ActorId;

    #endregion
    }

    public class CreateActorUseCase : UseCase<CreateActorInput , ActorRepository>
    {
    #region Constructor

        public CreateActorUseCase(DomainEventBus domainEventBus , ActorRepository repository) : base(
            domainEventBus , repository) { }

    #endregion

    #region Public Methods

        public override void Execute(CreateActorInput input)
        {
            var actor = ActorBuilder.NewInstance()
                                    .SetActorId(input.ActorId)
                                    .SetActorDataId(input.ActorDataId)
                                    .Build();
            repository.Save(actor);
            domainEventBus.PostAll(actor);
        }

    #endregion
    }
}
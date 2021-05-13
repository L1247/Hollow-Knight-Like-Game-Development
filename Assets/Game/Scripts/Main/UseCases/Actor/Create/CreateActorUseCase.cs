using DDDCore.Model;
using DDDCore.Usecase;
using Main.UseCases.Repository;

namespace Main.UseCases.Actor.Create
{
    public class CreateActorInput : Input
    {
        // For Unit Test
        public string ActorId;
        public string ActorDataId;
    }

    public class CreateActorUseCase : UseCase<CreateActorInput , ActorRepository>
    {
        public CreateActorUseCase(DomainEventBus domainEventBus , ActorRepository repository) : base(
            domainEventBus , repository) { }

        public override void Execute(CreateActorInput input)
        {
            var actor = new Main.Actor.Actor(input.ActorId , input.ActorDataId);
            repository.Save(actor);
            domainEventBus.PostAll(actor);
        }
    }
}
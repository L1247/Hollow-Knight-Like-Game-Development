#region

using DDDCore;
using DDDCore.Usecase;
using Main.UseCases.Repository;
using Utilities.Contract;

#endregion

public class MakeActorDieInput : Input
{
#region Public Variables

    public string ActorId;

#endregion
}

public class MakeActorDieUseCase : UseCase<MakeActorDieInput , ActorRepository>
{
#region Constructor

    public MakeActorDieUseCase(IDomainEventBus domainEventBus , ActorRepository repository) : base(
        domainEventBus , repository) { }

#endregion

#region Public Methods

    public override void Execute(MakeActorDieInput input)
    {
        var actorId = input.ActorId;
        Contract.RequireString(actorId , "actorId");
        var actor = repository.FindById(actorId);
        Contract.RequireNotNull(actor , "actor");
        actor.MakeDie();
        domainEventBus.PostAll(actor);
    }

#endregion
}
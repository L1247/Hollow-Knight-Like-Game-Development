#region

using DDDCore;
using DDDCore.Usecase;
using Entity.Builder;
using Main.UseCases.Repository;
using Utilities.Contract;

#endregion

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
    #region Private Variables

        private readonly IDataRepository dataRepository;

    #endregion

    #region Constructor

        public CreateActorUseCase(IDomainEventBus domainEventBus , ActorRepository repository ,
                                  IDataRepository dataRepository) : base(
            domainEventBus , repository)
        {
            this.dataRepository = dataRepository;
        }

    #endregion

    #region Public Methods

        public override void Execute(CreateActorInput input)
        {
            var actorDataId = input.ActorDataId;
            Contract.RequireString(actorDataId , "actorDataId");
            var actorData = dataRepository.GetActorData(actorDataId);
            Contract.RequireNotNull(actorData , "actorDomainData");

            var actor = ActorBuilder.NewInstance()
                                    .SetActorId(input.ActorId)
                                    .SetActorDataId(actorDataId)
                                    .Build();
            repository.Save(actor);
            domainEventBus.PostAll(actor);
        }

    #endregion
    }
}
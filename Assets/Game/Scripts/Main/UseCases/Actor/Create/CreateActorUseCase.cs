using DDDCore.Model;
using DDDCore.Usecase;
using Entity.Builder;
using Main.UseCases.Repository;
using Utilities.Contract;

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

        private readonly iSoRepository iSoRepository;

    #endregion

    #region Constructor

        public CreateActorUseCase(DomainEventBus domainEventBus , ActorRepository repository , iSoRepository iSoRepository) : base(
            domainEventBus , repository)
        {
            this.iSoRepository = iSoRepository;
        }

    #endregion

    #region Public Methods

        public override void Execute(CreateActorInput input)
        {
            var actorDataId = input.ActorDataId;
            Contract.RequireString(actorDataId , "actorDataId");
            var actorData = iSoRepository.GetActorData(actorDataId);
            Contract.RequireNotNull(actorData , "actorData");

            var health = actorData.Health;
            var actor = ActorBuilder.NewInstance()
                                    .SetActorId(input.ActorId)
                                    .SetActorDataId(actorDataId)
                                    .SetHealth(health)
                                    .Build();
            repository.Save(actor);
            domainEventBus.PostAll(actor);
        }

    #endregion
    }
}
using Main.UseCases.Actor.Create;
using Zenject;

namespace Main.Controller
{
    public class ActorContoller
    {
    #region Private Variables

        [Inject]
        private CreateActorUseCase createActorUseCase;

    #endregion

    #region Public Methods

        public void CreateActor(string actorDataId)
        {
            var input = new CreateActorInput();
            input.ActorDataId = actorDataId;
            createActorUseCase.Execute(input);
        }

    #endregion
    }
}
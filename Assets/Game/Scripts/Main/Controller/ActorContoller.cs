using Main.UseCases.Actor.Create;
using Main.UseCases.Actor.Edit;
using Zenject;

namespace Main.Controller
{
    public class ActorContoller
    {
    #region Private Variables

        [Inject]
        private ChangeDirectionUseCase changeDirectionUseCase;

        [Inject]
        private CreateActorUseCase createActorUseCase;

    #endregion

    #region Public Methods

        public void ChangeDirection(string actorId , int direction)
        {
            var input = new ChangeDirectionInput();
            input.ActorId   = actorId;
            input.Direction = direction;
            changeDirectionUseCase.Execute(input);
        }

        public void CreateActor(string actorDataId)
        {
            var input = new CreateActorInput();
            input.ActorDataId = actorDataId;
            createActorUseCase.Execute(input);
        }

    #endregion
    }
}
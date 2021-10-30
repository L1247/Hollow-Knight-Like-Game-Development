#region

using Main.UseCases.Actor.Create;
using Main.UseCases.Actor.Edit;
using Zenject;

#endregion

namespace Main.Controller
{
    public class ActorController
    {
    #region Private Variables

        [Inject]
        private ChangeDirectionUseCase changeDirectionUseCase;

        [Inject]
        private CreateActorUseCase createActorUseCase;


        [Inject]
        private MakeActorDieUseCase makeActorDieUseCase;

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


        public void MakeActorDie(string actorId)
        {
            var input = new MakeActorDieInput();
            input.ActorId = actorId;
            makeActorDieUseCase.Execute(input);
        }

    #endregion
    }
}
using DDDCore.Adapter.Presenter.Unity;
using DDDCore.Model;
using Main.Actor.Events;
using Main.UseCases.Actor.Create;
using Main.UseCases.Repository;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Main.Presenters
{
    public class ActorPresenter : UnityPresenter
    {
        [SerializeField]
        private Button button_CreateActor;

        [Inject]
        private CreateActorUseCase createActorUseCase;

        private void Start()
        {
            ButtonBinding(button_CreateActor , () => CreateActor());
        }

        private void CreateActor()
        {
            var input = new CreateActorInput();
            input.ActorDataId = "Pikachu";
            createActorUseCase.Execute(input);
        }

        public void OnActorCreated(ActorCreated actorCreated)
        {
            Debug.Log($"OnActorCreated {actorCreated.ActorId} , {actorCreated.ActorDataId}");
        }
    }
}
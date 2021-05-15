using DDDCore.Adapter.Presenter.Unity;
using Main.Controller;
using Main.Entity.Model.Events;
using Main.ViewComponent;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Main.Presenters
{
    public class ActorPresenter : UnityPresenter
    {
    #region Private Variables

        [Inject]
        private ActorContoller actorContoller;

        [Inject]
        private ActorMapper actorMapper;

        private readonly string defaultActorDataId_A = "Pikachu";
        private readonly string defaultActorDataId_B = "Star";

        [SerializeField]
        private Button button_CreateActor_A;

        [SerializeField]
        private Button button_CreateActor_B;

        [SerializeField]
        private GameObject actorPrefab;

        [SerializeField]
        private Sprite sprite_A;

        [SerializeField]
        private Sprite sprite_B;

    #endregion

    #region Unity events

        private void Start()
        {
            ButtonBinding(button_CreateActor_A , () => actorContoller.CreateActor(defaultActorDataId_A));
            ButtonBinding(button_CreateActor_B , () => actorContoller.CreateActor(defaultActorDataId_B));
        }

    #endregion

    #region Events

        public void OnActorCreated(ActorCreated actorCreated)
        {
            var actorId     = actorCreated.ActorId;
            var actorDataId = actorCreated.ActorDataId;
            var sprite      = actorDataId == defaultActorDataId_A ? sprite_A : sprite_B;
            Debug.Log($"OnActorCreated {actorId} , {actorDataId}");
            var actorInstance  = Instantiate(actorPrefab , Random.insideUnitCircle * 5 , Quaternion.identity);
            var actorComponent = actorInstance.GetComponent<ActorComponent>();
            var text           = $"{actorDataId} - {actorId.Substring(actorId.Length - 2 , 2)}";
            actorComponent.SetText(text);
            actorComponent.SetSprite(sprite);
            actorMapper.CreateActorViewData(actorId , actorDataId , actorComponent);
        }

    #endregion
    }
}
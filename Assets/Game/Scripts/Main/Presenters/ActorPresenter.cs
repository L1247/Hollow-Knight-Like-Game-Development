using DDDCore.Adapter.Presenter.Unity;
using Main.Controller;
using Main.Entity.Model.Events;
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

        private readonly string defaultActorDataId = "Pikachu";

        [SerializeField]
        private Button button_CreateActor;

        [SerializeField]
        private GameObject actorPrefab;

    #endregion

    #region Unity events

        private void Start()
        {
            ButtonBinding(button_CreateActor , () => actorContoller.CreateActor(defaultActorDataId));
        }

    #endregion

    #region Events

        public void OnActorCreated(ActorCreated actorCreated)
        {
            var actorId     = actorCreated.ActorId;
            var actorDataId = actorCreated.ActorDataId;
            Debug.Log($"OnActorCreated {actorId} , {actorDataId}");
            var actorInstance = Instantiate(actorPrefab , Random.insideUnitCircle * 5 , Quaternion.identity);
            var textComponent = actorInstance.GetComponentInChildren<Text>();
            textComponent.text = $"{actorDataId} - {actorId.Substring(actorId.Length - 2 , 2)}";
        }

    #endregion
    }
}
#region

using DDDCore.Adapter.Presenter.Unity;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

#endregion

namespace Main.Presenters
{
    public class StatPresenter : UnityPresenter
    {
    #region Private Variables

        [Inject]
        private ActorMapper actorMapper;

        [Required]
        [SerializeField]
        private Button button_DealDamage;

    #endregion

    #region Unity events

        private void Start()
        {
            ButtonBinding(button_DealDamage , () =>
            {
                // todo : modify amount
                // actorController.DealDamage(CacheActorId , 10);
            });
        }

    #endregion

    #region Public Methods

        public void CreateStatText(string actorId , string statName , int amount)
        {
            var actorComponent = actorMapper.GetActorComponent(actorId);
            actorComponent.CreateStat(statName , amount);
        }

    #endregion
    }
}
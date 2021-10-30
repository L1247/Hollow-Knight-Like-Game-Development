#region

using DDDCore.Adapter.Presenter.Unity;
using Main.Controller;
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

        [Inject]
        private StatController statController;

        private string cacheActorId;

        [Required]
        [SerializeField]
        private Button button_DealDamage;

    #endregion

    #region Unity events

        private void Start()
        {
            ButtonBinding(button_DealDamage , () =>
            {
                var statName = "Hp";
                var amount   = -(int)(Random.value * 20);
                statController.ModifyStatAmount(cacheActorId , statName , amount);
            });
        }

    #endregion

    #region Public Methods

        public void CreateStatText(string actorId , string statName , int amount)
        {
            cacheActorId = actorId;
            var actorComponent = actorMapper.GetActorComponent(actorId);
            actorComponent.CreateStat(statName , amount);
        }


        public void ModifyAmountText(string actorId , string statName , int amount)
        {
            var actorComponent = actorMapper.GetActorComponent(actorId);
            actorComponent.SetStatText(statName , amount);
        }

    #endregion
    }
}
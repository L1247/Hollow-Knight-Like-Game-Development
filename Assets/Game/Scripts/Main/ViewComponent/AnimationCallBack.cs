using Main.ViewComponent.Events;
using UnityEngine;
using Zenject;

namespace Main.ViewComponent
{
    public class AnimationCallBack : MonoBehaviour
    {
    #region Private Variables

        [Inject]
        private SignalBus signalBus;

    #endregion

    #region Events

        public void OnAnimationEvent(string eventId)
        {
            signalBus.Fire(new rAnimationEvent(eventId));
        }

    #endregion
    }
}
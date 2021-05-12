using System;
using DDDCore.Adapter.Presenter.Unity;
using UnityEngine;
using UnityEngine.UI;

namespace Main.Presenters
{
    public class ActorPresenter : UnityPresenter
    {
        [SerializeField]
        private Button button_CreateActor;

        private void Start()
        {
            ButtonBinding(button_CreateActor , CreateActor);
        }

        private void CreateActor()
        {
            var actor = new Actor.Actor(Guid.NewGuid().ToString() , "Picachu");
        }
    }
}
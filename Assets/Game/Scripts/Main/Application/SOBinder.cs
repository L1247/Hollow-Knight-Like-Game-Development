using Main.GameDataStructure;
using UnityEngine;
using Zenject;

namespace Main.Application
{
    [CreateAssetMenu(fileName = "SoBinder" , menuName = "HK/SoBinder" , order = 0)]
    public class SOBinder : ScriptableObjectInstaller
    {
    #region Public Variables

        public ActorDataOverView ActorDataOverView;

    #endregion

    #region Public Methods

        public override void InstallBindings()
        {
            Container.BindInstance(ActorDataOverView.ActorDatas);
            Container.BindInstance(ActorDataOverView);
        }

    #endregion
    }
}
using Main.Decoupling;
using UnityEngine;
using Zenject;

public class DecouplingInstaller : MonoInstaller
{
#region Public Methods

    public override void InstallBindings()
    {
        Container.Bind<ActorSpawner>().AsSingle();
        Container.Bind<IDataBaseService>().To<DataBaseService>().AsSingle();
        Container.Bind<DataBaseServer>().AsSingle();

        Container.Bind<DecouplingFlow>().AsSingle().NonLazy();
    }

#endregion
}

public class DecouplingFlow
{
#region Constructor

    [Inject]
    public DecouplingFlow(ActorSpawner actorSpawner)
    {
        for (var i = 1 ; i < 3 ; i++)
        {
            var actor = actorSpawner.Spawn(i);
            Debug.Log($"actor {i} , hp:{actor.Hp} , atk:{actor.Atk}");
        }
    }

#endregion
}
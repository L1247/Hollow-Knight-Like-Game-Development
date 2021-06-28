using UnityEngine.Assertions;
using Zenject;

namespace Main.Decoupling
{
    public class ActorSpawner
    {
    #region Private Variables

        private readonly IDataBaseService dataBaseService;

    #endregion

    #region Constructor

        [Inject]
        public ActorSpawner(IDataBaseService dataBaseService)
        {
            this.dataBaseService = dataBaseService;
        }

    #endregion

    #region Public Methods

        public Actor Spawn(int actorDataId)
        {
            var actorData = dataBaseService.GetActorData(actorDataId);
            Assert.IsNotNull(actorData , $"actorData should not be null , {actorDataId}");
            var hp    = actorData.Hp;
            var atk   = actorData.Atk;
            var actor = new Actor(hp , atk);
            return actor;
        }

    #endregion
    }

    public class Actor
    {
    #region Public Variables

        public int Atk { get; }

        public int Hp { get; }

    #endregion

    #region Constructor

        public Actor(int hp , int atk)
        {
            Hp  = hp;
            Atk = atk;
        }

    #endregion
    }
}
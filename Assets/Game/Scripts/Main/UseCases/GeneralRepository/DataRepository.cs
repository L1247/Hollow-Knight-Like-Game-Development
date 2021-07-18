using Main.ScriptableObjects;
using Zenject;

namespace Main.UseCases.Repository
{
    public class DataRepository : iDataRepository
    {
    #region Private Variables

        [Inject]
        private ActorDataOverView actorDataOverView;

    #endregion

    #region Public Methods

        public ActorDomainData GetActorDomainData(string actorDataId)
        {
            return null;
        }

    #endregion
    }
}
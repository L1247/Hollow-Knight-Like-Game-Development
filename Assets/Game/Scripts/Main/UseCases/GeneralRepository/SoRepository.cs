using Main.ScriptableObjects;
using Zenject;

namespace Main.UseCases.Repository
{
    public class SoRepository : iSoRepository
    {
    #region Private Variables

        [Inject]
        private ActorDataOverView actorDataOverView;

    #endregion

    #region Public Methods

        public ActorData GetActorData(string actorDataId)
        {
            return actorDataOverView.FindActorData(actorDataId);
        }

    #endregion
    }
}
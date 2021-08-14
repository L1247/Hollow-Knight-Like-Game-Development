#region

using Main.DomainData;
using Main.UseCases.Repository;
using Utilities.Contract;
using Zenject;

#endregion

namespace Main.GameDataStructure
{
    public class DataRepository : iDataRepository
    {
    #region Private Variables

        [Inject]
        private ActorDataOverView actorDataOverView;

    #endregion

    #region Public Methods

        public IActorData GetActorData(string actorDataId)
        {
            return null;
        }

        public ActorDomainData GetActorDomainData(string actorDataId)
        {
            var actorData       = actorDataOverView.FindActorData(actorDataId);
            var actorDomainData = actorData.ActorDomainData;
            Contract.EnsureNotNull(actorDomainData , $"actorDataId {actorDataId} , ActorDomainData");
            return actorDomainData;
        }

    #endregion
    }
}
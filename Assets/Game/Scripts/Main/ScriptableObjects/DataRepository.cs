using Main.UseCases.Repository;
using NSubstitute;
using Utilities.Contract;
using Zenject;

namespace Main.GameDataStructure
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
            var actorData       = actorDataOverView.FindActorData(actorDataId);
            var actorDomainData = actorData.ActorDomainData;
            Contract.EnsureNotNull(actorDomainData , $"actorDataId {actorDataId} , ActorDomainData");
            return actorDomainData;
        }

    #endregion
    }
}
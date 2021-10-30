#region

using Main.DomainData;
using Main.UseCases.Repository;
using Utilities.Contract;
using Zenject;

#endregion

namespace Main.GameDataStructure
{
    public class DataRepository : IDataRepository
    {
    #region Private Variables

        [Inject]
        private IActorDataOverView actorDataOverView;

    #endregion

    #region Public Methods

        public IActorData GetActorData(string actorDataId)
        {
            Contract.RequireString(actorDataId , "actorDataId");
            var actorData = actorDataOverView.FindActorData(actorDataId);
            Contract.EnsureNotNull(actorData , $"actorDataId:{actorDataId} , actorData");
            return actorData;
        }

    #endregion
    }
}
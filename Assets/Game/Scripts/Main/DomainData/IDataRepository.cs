#region

using Main.DomainData;

#endregion

namespace Main.UseCases.Repository
{
    public interface IDataRepository
    {
    #region Public Methods

        IActorData GetActorData(string actorDataId);

    #endregion
    }
}